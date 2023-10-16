using HandySquad.dto.Profile;

namespace HandySquad.Services.Interfaces;

public interface IProfileImageService
{
    Task<ProfileImageDto> GetProfileImageAsync(int id);
    Task CreateProfileImageAsync(ProfileImageDto profileImageDto);
    Task UpdateProfileImageAsync(int id, ProfileImageDto profileImageDto);
    Task DeleteProfileImageAsync(int id);
}