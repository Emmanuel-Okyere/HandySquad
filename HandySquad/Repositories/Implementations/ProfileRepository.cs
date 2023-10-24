using HandySquad.Data;
using HandySquad.dto.Profile;
using HandySquad.Models;
using HandySquad.Models.ProfileModels;
using HandySquad.Pagination;
using HandySquad.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HandySquad.Repositories.Implementations;

public class ProfileRepository : IProfileRepository
{
    private readonly DataContext _dataContext;

    public ProfileRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<Profile?> GetProfileByIdAsync(int id)
    {
        return await _dataContext
            .Profiles
            .Include(a=>a.ProfileImage)
            .FirstOrDefaultAsync(a=>a.Id==id);
    }

    public async Task<Profile?> GetByUserId(int id)
    {
        return await _dataContext.
            Profiles
            .Include(a=>a.ProfileImage)
            .FirstOrDefaultAsync(a => a.User.Id == id);
    }

    public async Task<IEnumerable<Profile>> GetAllProfilesAsync( )
    {
        return await _dataContext.Profiles
            .OrderBy(p=>p.FullName)
            .ToListAsync();
    }

    

    public async Task<IEnumerable<Profile>> SearchProfilesAsync(ProfileSearchParameters profileSearchParameters, int page, int pageSize)
    {
        var query = _dataContext.Profiles.AsQueryable();
        if (!string.IsNullOrEmpty(profileSearchParameters.SearchTerm))
        {
            query = query.Where(s => s.Occupation != null && s.FullName != null && (s.FullName.Contains(profileSearchParameters.SearchTerm) || s.Occupation.Contains(profileSearchParameters.SearchTerm)));

        }
        
        var totalCount = await query.CountAsync(); //total count before paging
        //applying pagination
        var profiles = await query
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        return profiles;
    }

    public async Task<int> GetTotalProfileCountAsync(ProfileSearchParameters profileSearchParameters)
    {
        var query = _dataContext.Profiles.AsQueryable();
        if (!string.IsNullOrEmpty(profileSearchParameters.SearchTerm))
        {
            query = query.Where(p =>
                p.FullName.Contains(profileSearchParameters.SearchTerm) ||
                p.Occupation.Contains(profileSearchParameters.SearchTerm));
        }

        return await query.CountAsync();
    }

    public async Task<Profile> CreateProfileAsync(Profile profile)
    {
        var userProfile =await _dataContext.Profiles.AddAsync(profile);
        await _dataContext.SaveChangesAsync();
        return userProfile.Entity;
    }

    public async Task UpdateProfileAsync(Profile profile)
    {
        _dataContext.Profiles.Update(profile);
        await _dataContext.SaveChangesAsync();
    }

    public async Task DeleteProfileAsync(int id)
    {
        var profile = await GetProfileByIdAsync(id);
        if (profile != null)
        {
            _dataContext.Profiles.Remove(profile);
            await _dataContext.SaveChangesAsync();
        }
    }

    public async Task SaveChangesAsync()
    {
        await _dataContext.SaveChangesAsync();
    }
}
