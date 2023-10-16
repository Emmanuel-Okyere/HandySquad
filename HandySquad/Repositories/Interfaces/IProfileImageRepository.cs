using HandySquad.dto.Profile;
using HandySquad.Models;
using HandySquad.Models.ProfileModels;

namespace HandySquad.Repositories.Interfaces;

public interface IProfileImageRepository
{
    
    Task<ProfileImage> GetProfileImageByIdAsync(int id);
    Task CreateProfileImageAsync(ProfileImage profileImage);
    Task UpdateProfileImageAsync(ProfileImage profileImage);
    Task DeleteProfileImageAsync(int id);
}