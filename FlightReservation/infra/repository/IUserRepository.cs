using FlightReservation.infra.data;
using FlightReservation.infra.models;

namespace FlightReservation.infra.repository;

public interface IUserRepository
{
    public void UserExist(string? username);
    Task Create(User user);
    Task<User> FindUser();
    Task<User> FindUserByUserNameOrEmail(string? username, string? email);
}