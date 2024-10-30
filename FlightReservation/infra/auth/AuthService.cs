using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FlightReservation.infra.models;
using FlightReservation.infra.repository;
using FlightReservation.presentation.auth.dto;
using FlightReservation.presentation.user;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace FlightReservation.infra.auth;

public class AuthService(IConfiguration config, IUserRepository userRepository, IPasswordHasher<User> passwordHasher)
{


    public async Task<string> Register(RegisterRequest register)
    {
        userRepository.UserExist(register.Username);

        var user = new User(register.Email, register.Username, register.Role);
        user.PasswordHash = passwordHasher.HashPassword(user, register.Password);

        await userRepository.Create(user);

        return GenerateJwtToken(user);
    }

    public async Task<string> Login(LoginRequest loginRequest)
    {
        var userFound = await userRepository.FindUserByUserNameOrEmail(loginRequest.Username, loginRequest.Email);
        PasswordValidation(loginRequest.Password, userFound);
        return GenerateJwtToken(userFound);
    }

    private string GenerateJwtToken(User user)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, user.Role.ToString())
        };
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"] ?? string.Empty));
        var creeds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);


        var token = new JwtSecurityToken(
            issuer: config["Jwt:Issuer"],
            audience: config["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddHours(1),
            signingCredentials: creeds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    private void PasswordValidation(string sentPassword, User userFound)
    {
        var isValid = passwordHasher.VerifyHashedPassword(userFound, userFound.PasswordHash, sentPassword)
                      == PasswordVerificationResult.Success;

        if (!isValid)
        {
            throw new UnauthorizedAccessException("Invalid credentials");
        }
    }
}