using AutoMapper;
using HandySquad.Data;
using HandySquad.dto.Profile;
using HandySquad.Repositories.Interfaces;
using HandySquad.Services.Interfaces;
using Profile = HandySquad.Models.ProfileModels.Profile;

namespace HandySquad.Services.Implementations;

public class ProfileService:IProfileService
{
    private readonly IProfileRepository _profileRepository;
    private readonly IMapper _mapper;

    public ProfileService(IProfileRepository profileRepository,IMapper mapper)
    {
        _profileRepository = profileRepository;
        _mapper = mapper;
    }
    public async Task<ProfileDto> GetProfileAsync(int id)
    {
        var profile = await _profileRepository.GetProfileByIdAsync(id);
        return _mapper.Map<ProfileDto>(profile);
    }

    public async Task<IEnumerable<ProfileDto>> GetAllProfilesAsync()
    {
        var profiles = await _profileRepository.GetAllProfilesAsync();
        return _mapper.Map<IEnumerable<ProfileDto>>(profiles);
    }

    public  async Task<Profile> CreateProfileAsync(ProfileDto profileDto)
    {
        var profile = _mapper.Map<Profile>(profileDto);
        
        return await _profileRepository.CreateProfileAsync(profile);
    }

    public async Task UpdateProfileAsync(int id, ProfileDto profileDto)
    {
        var existingProfile = await _profileRepository.GetProfileByIdAsync(id);
        if (existingProfile != null)
        {
            _mapper.Map(profileDto, existingProfile);
            await _profileRepository.UpdateProfileAsync(existingProfile);
        }
    }
    public async Task DeleteProfileAsync(int id)
    {
        await _profileRepository.DeleteProfileAsync(id);
    }
}