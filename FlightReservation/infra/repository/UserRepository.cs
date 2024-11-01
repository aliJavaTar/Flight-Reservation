using System.Net;
using System.Security.Claims;
using FlightReservation.infra.data;
using FlightReservation.infra.models;
using FlightReservation.presentation.auth.dto;
using Microsoft.EntityFrameworkCore;

namespace FlightReservation.infra.repository;

public class UserRepository(DataBase dataBase) : IUserRepository
{
    public async void UserExist(string? username)
    {
        ArgumentNullException.ThrowIfNull(username);


        var userExist = await dataBase.Users.FirstOrDefaultAsync(user => user.Username == username);


        if (userExist is not null)
        {
            throw new InvalidOperationException($"User with username {username} already exists.");
        }
        
    }

    public async Task Create(User user)
    {
        await dataBase.Users.AddAsync(user);

        if (await dataBase.SaveChangesAsync() == 0)
        {
            throw new Exception($"User with username {user.Username} cannot be created.");
        }
    }

    public async Task<User> FindUserByUserNameOrEmail(string? username, string? email)
    {
        User? userFound;
        if (username is null && email is null)
        {
            throw new Exception($"Username or email address cannot be null.");
        }

        if (username is not null)
        {
            userFound = await dataBase.Users.FirstOrDefaultAsync(user => user.Username == username);
            Exist(username, userFound);
            return userFound;
        }

        userFound = await dataBase.Users.FirstOrDefaultAsync(user => user.Email == email);
        Exist(email, userFound);
        return userFound;
    }

    public async Task<User> FindUser()
    {
        return await dataBase.Users.FindAsync(ClaimTypes.NameIdentifier) ??
               throw new Exception($"User with this information  cannot be found.");
    }

    private void Exist(string usernameOrEmail, User? userFound)
    {
        if (userFound is null)
        {
            throw new Exception($"User with this {usernameOrEmail} does not exist.");
        }
    }
}