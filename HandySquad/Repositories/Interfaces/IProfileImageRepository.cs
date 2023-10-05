using HandySquad.dto.Profile;

namespace HandySquad.Repositories.Interfaces;

public interface IProfileImageRepository
{
    Task<int> UploadImageAync(ProfileImageDto profileImageDto);
    Task UploadImageAsync(int id, ProfileImageDto profileImageDto);
    Task<ProfileImageDto> GetImageAsync(int id);
}