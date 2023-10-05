using HandySquad.dto.Profile;
using HandySquad.Models;

namespace HandySquad.Repositories.Interfaces;

public interface IProfileRepository
{
    Task<IEnumerable<ProfileDto>> GetAllProfilesAsync();
    Task<ProfileDto> GetProfileByIdAsync(int id);
    Task<int> CreateProfileAsync(CreateProfileDto createProfileDto);
    Task UpdateProfileAsync(int id, UpdateProfileDto updateProfileDto);
    Task DeleteProfileAsync(int id);
    //Task SaveChangesAsync();
}