using HandySquad.Data;
using HandySquad.dto.Profile;
using HandySquad.Models;
using HandySquad.Repositories.Interfaces;

namespace HandySquad.Repositories.Implementations;

public class ProfileImageRepository:IProfileImageRepository
{
    private readonly DataContext _dataContext;

    public ProfileImageRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    public async Task<int> UploadImageAync(ProfileImageDto profileImageDto)
    {
        var image = new ProfileImage
        {
            FileName = profileImageDto.FileName,
            Data = profileImageDto.Data
        };
        _dataContext.ProfileImages.Add(image);
        await _dataContext.SaveChangesAsync();
        return image.Id;
    }

    public async Task UploadImageAsync(int id, ProfileImageDto profileImageDto)
    {
        var image = await _dataContext.ProfileImages.FindAsync(id);
        if (image != null)
        {
            image.FileName = profileImageDto.FileName;
            image.Data = profileImageDto.Data;

            await _dataContext.SaveChangesAsync();
        }
    }

    public async Task<ProfileImageDto> GetImageAsync(int id)
    {
        var image = await _dataContext.ProfileImages.FindAsync(id);
        if (image != null)
        {
            return new ProfileImageDto
            {
                Id = image.Id,
                FileName = image.FileName,
                Data = image.Data
            };
        }

        return null;
    }
}