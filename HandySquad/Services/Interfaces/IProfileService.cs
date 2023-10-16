using HandySquad.dto.Profile;

namespace HandySquad.Services.Interfaces;

public interface IProfileService
{
    Task<ProfileDto> GetProfileAsync(int id);
    Task<IEnumerable<ProfileDto>> GetAllProfilesAsync();
    Task CreateProfileAsync(ProfileDto profileDto);
    Task UpdateProfileAsync(int id, ProfileDto profileDto);
    Task DeleteProfileAsync(int id);
}