using HandySquad.Data;
using HandySquad.dto.Profile;
using HandySquad.Repositories.Interfaces;
using HandySquad.Services.Interfaces;

namespace HandySquad.Services.Implementations;

public class ProfileService:IProfileService
{
    private readonly IProfileRepository _profileRepository;

    public ProfileService(IProfileRepository profileRepository)
    {
        _profileRepository = profileRepository;
    }
    public async Task<IEnumerable<ProfileDto>> GetAllProfilesAsync()
    {
        try
        {
            return await _profileRepository.GetAllProfilesAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw ;
        }
    }

    public async Task<ProfileDto> GetProfileByIdAsync(int id)
    {
        try
        {
            if (id<=0)
            {
                throw new ArgumentException("Invalid Pofile Id");
            }

            return await _profileRepository.GetProfileByIdAsync(id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<int> CreateProfileAsync(CreateProfileDto createProfileDto)
    {
        try
        {
            if (createProfileDto == null)
            {
                throw new ArgumentNullException(nameof(UpdateProfileDto),"Profile is Empty");
            }
        return    await _profileRepository.CreateProfileAsync(createProfileDto);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

       
    }

    public Task UpdateProfileAsync(int id, CreateProfileDto updateProfileDto)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateProfileAsync(int id, UpdateProfileDto updateProfileDto)
    {
        try
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid Profile ID");
            }

            if (updateProfileDto == null)
            {
                throw new ArgumentException(nameof(updateProfileDto), "Profile is null");
            }

            await _profileRepository.UpdateProfileAsync(id, updateProfileDto);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task DeleteProfileAsync(int id)
    {
        try
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid Profile Id");
            }

            await _profileRepository.DeleteProfileAsync(id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

 
}