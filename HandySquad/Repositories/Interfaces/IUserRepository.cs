using HandySquad.Models;

namespace HandySquad.Repositories.Interfaces;

public interface IUserRepository
{
    Task<User> AddUser(User clientsUser);
    Task<User?> GetUserById(int id);
    Task<User?> GetUserByEmailAddress(string emailAddress);
    void DeleteUserById(User clientsUser);
    void SaveChangesAsync();
}