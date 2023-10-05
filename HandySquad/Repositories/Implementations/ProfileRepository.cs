using HandySquad.Data;
using HandySquad.dto.Profile;
using HandySquad.Models;
using HandySquad.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HandySquad.Repositories.Implementations;

public class ProfileRepository:IProfileRepository
{
    private readonly DataContext _dataContext;

    public ProfileRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    
    public async Task<IEnumerable<ProfileDto>> GetAllProfilesAsync()
    {
        var profiles = await _dataContext.Profiles
            .Select(p => new ProfileDto
            {
                Id = p.Id,
                UserId = p.UserId,
                Occupation = p.Occupation,
                SkillSet = p.SkillSet,
                Location = p.Location,
                FullName = p.FullName,
                Ratings = p.Ratings,
                NumberOfRatings = p.NumberOfRatings,
                
            })
            .ToListAsync();

        return profiles;
    }

    public async Task<ProfileDto> GetProfileByIdAsync(int id)
    {
        var profile = await _dataContext.Profiles
            .Where(p => p.Id == id)
            .Select(p => new ProfileDto
            {
                Id = p.Id,
                UserId = p.UserId,
                Occupation = p.Occupation,
                SkillSet = p.SkillSet,
                Location = p.Location,
                FullName = p.FullName,
                Ratings = p.Ratings,
                NumberOfRatings = p.NumberOfRatings,
              
            })
            .FirstOrDefaultAsync();

        return profile;
    }

    public async Task<int> CreateProfileAsync(CreateProfileDto createProfileDto)
    {
        var profile = new Profile
        {
            UserId = createProfileDto.UserId,
            Occupation = createProfileDto.Occupation,
            SkillSet = createProfileDto.SkillSet,
            Location = createProfileDto.Location,
            FullName = createProfileDto.FullName,
            Ratings = createProfileDto.Ratings,
            NumberOfRatings = createProfileDto.NumberOfRatings,
        };
        _dataContext.Profiles.Add(profile);
        await _dataContext.SaveChangesAsync();
        return profile.Id;
    }

    

    public async Task UpdateProfileAsync(int id, UpdateProfileDto updateProfileDto)
    {
        var profile = await _dataContext.Profiles.FindAsync(id);
        if (profile != null)
        {
            profile.UserId = updateProfileDto.UserId;
            profile.Occupation = updateProfileDto.Occupation;
            profile.SkillSet = updateProfileDto.SkillSet;
            profile.Location = updateProfileDto.Location;
            profile.FullName = updateProfileDto.FullName;
            profile.Ratings = updateProfileDto.Ratings;
            profile.NumberOfRatings = updateProfileDto.NumberOfRatings;
            await _dataContext.SaveChangesAsync();
        }
    }

    public async Task DeleteProfileAsync(int id)
    {
        var profile = await _dataContext.Profiles.FindAsync(id);
        if (profile != null)
        {
            _dataContext.Profiles.Remove(profile);
            await _dataContext.SaveChangesAsync();
        }
    }

    // public async Task SaveChangesAsync()
    // {
    //     await _dataContext.SaveChangesAsync();
    // }
}