using FlightReservation.infra.data;
using FlightReservation.infra.models;
using FlightReservation.presentation.auth.dto;

namespace FlightReservation.infra.repository;

public interface IUserRepository
{
    void UserExist(string? username);
    Task Create(User user);
    Task<User> FindUser();
    Task<User> FindUserByUserNameOrEmail(string? username, string? email);
}