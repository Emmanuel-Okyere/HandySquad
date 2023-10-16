using HandySquad.Data;
using HandySquad.dto.Profile;
using HandySquad.Models;
using HandySquad.Models.ProfileModels;
using HandySquad.Repositories.Interfaces;

namespace HandySquad.Repositories.Implementations;

public class ProfileImageRepository : IProfileImageRepository
{
    private readonly DataContext _dataContext;

    public ProfileImageRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }


    public async  Task<ProfileImage> GetProfileImageByIdAsync(int id)
    {
        return await _dataContext.ProfileImages.FindAsync(id);
    }

    public async Task CreateProfileImageAsync(ProfileImage profileImage)
    {
        _dataContext.ProfileImages.Add(profileImage);
        await _dataContext.SaveChangesAsync();
    }

    public async Task UpdateProfileImageAsync(ProfileImage profileImage)
    {
        _dataContext.ProfileImages.Update(profileImage);
        await _dataContext.SaveChangesAsync();
    }

    public async Task DeleteProfileImageAsync(int id)
    {
        var profileImage = await GetProfileImageByIdAsync(id);
        if (profileImage != null)
        {
            _dataContext.ProfileImages.Remove(profileImage);
            await _dataContext.SaveChangesAsync();
        }
    }
}