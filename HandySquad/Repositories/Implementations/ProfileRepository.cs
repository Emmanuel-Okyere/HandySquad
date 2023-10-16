using HandySquad.Data;
using HandySquad.dto.Profile;
using HandySquad.Models;
using HandySquad.Models.ProfileModels;
using HandySquad.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HandySquad.Repositories.Implementations;

public class ProfileRepository : IProfileRepository
{
    private readonly DataContext _dataContext;

    public ProfileRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<Profile> GetProfileByIdAsync(int id)
    {
        return await _dataContext.Profiles.FindAsync(id);
    }

    public async Task<IEnumerable<Profile>> GetAllProfilesAsync()
    {
        return await _dataContext.Profiles.ToListAsync();
    }

    public async Task<Profile> CreateProfileAsync(Profile profile)
    {
        var userProfile =await _dataContext.Profiles.AddAsync(profile);
        await _dataContext.SaveChangesAsync();
        return userProfile.Entity;
    }

    public async Task UpdateProfileAsync(Profile profile)
    {
        _dataContext.Profiles.Update(profile);
        await _dataContext.SaveChangesAsync();
    }

    public async Task DeleteProfileAsync(int id)
    {
        var profile = await GetProfileByIdAsync(id);
        if (profile != null)
        {
            _dataContext.Profiles.Remove(profile);
            await _dataContext.SaveChangesAsync();
        }
    }
}
