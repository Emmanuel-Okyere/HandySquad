using HandySquad.dto.Profile;
using HandySquad.Models;
using HandySquad.Models.ProfileModels;

namespace HandySquad.Repositories.Interfaces;

public interface IProfileRepository
{
    Task<Profile> GetProfileByIdAsync(int id);
    Task<IEnumerable<Profile>> GetAllProfilesAsync();
    Task<Profile> CreateProfileAsync(Profile profile);
    Task UpdateProfileAsync(Profile profile);
    Task DeleteProfileAsync(int id);
}