using System.Data.Entity;
using HandySquad.Data;
using HandySquad.Models;
using HandySquad.Repositories.Interfaces;

namespace HandySquad.Repositories.Implementations;

public class UserRepository: IUserRepository
{
    private readonly DataContext _dataContext;

    public UserRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<User> AddUser(User user)
    {
        var newUser =await _dataContext.AddAsync(user);
        await _dataContext.SaveChangesAsync();
        return newUser.Entity;
    }

    public async Task<User?> GetUserById(int id)
    {
        return await _dataContext.Users.FirstOrDefaultAsync(a=>a.Id== id);
    }

    public async Task<User> GetUserByEmailAddress(string emailAddress)
    {
        return await _dataContext.Users.FirstOrDefaultAsync(a => a.EmailAddress == emailAddress);
    }

    public void DeleteUserById(User user)
    {
        _dataContext.Users.Remove(user);
        _dataContext.SaveChangesAsync();
    }

    public void SaveChangesAsync()
    {
        _dataContext.SaveChangesAsync();
    }
}