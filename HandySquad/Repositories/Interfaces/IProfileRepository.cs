using HandySquad.dto.Profile;
using HandySquad.Models;
using HandySquad.Models.ProfileModels;
using HandySquad.Pagination;


namespace HandySquad.Repositories.Interfaces;

public interface IProfileRepository
{
    Task<Profile> GetProfileByIdAsync(int id);
    Task<Profile> GetByUserId(int id);
    Task<IEnumerable<Profile>> GetAllProfilesAsync(); 
    
    Task<IEnumerable<Profile>> SearchProfilesAsync(ProfileSearchParameters profileSearchParameters, int page, int pageSize);
    Task<int> GetTotalProfileCountAsync(ProfileSearchParameters profileSearchParameters);
    Task<Profile> CreateProfileAsync(Profile profile);
    Task UpdateProfileAsync(Profile profile);
    Task DeleteProfileAsync(int id);
    Task SaveChangesAsync();
}