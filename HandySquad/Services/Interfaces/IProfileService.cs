using HandySquad.dto.Profile;

namespace HandySquad.Services.Interfaces;

public interface IProfileService
{
    Task<IEnumerable<ProfileDto>> GetAllProfilesAsync();
    Task<ProfileDto> GetProfileByIdAsync(int id);
    Task<int> CreateProfileAsync(CreateProfileDto createProfileDto);
    Task UpdateProfileAsync(int id, CreateProfileDto updateProfileDto);
    Task DeleteProfileAsync(int id);
   // Task SaveChangesAsync();
}