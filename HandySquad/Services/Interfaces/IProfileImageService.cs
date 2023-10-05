using HandySquad.dto.Profile;

namespace HandySquad.Services.Interfaces;

public interface IProfileImageService
{
    Task<int> UploadImageAsync(ProfileImageDto profileImageDto);
    Task UpdateImageAsync(int id, ProfileImageDto profileImageDto);
    Task<ProfileImageDto> GetImageAsync(int id);
}