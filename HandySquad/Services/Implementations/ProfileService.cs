using AutoMapper;
using HandySquad.Data;
using HandySquad.dto;
using HandySquad.dto.Profile;
using HandySquad.Exceptions;
using HandySquad.Repositories.Interfaces;
using HandySquad.Services.Interfaces;
using Profile = HandySquad.Models.ProfileModels.Profile;

namespace HandySquad.Services.Implementations;

public class ProfileService:IProfileService
{
    private readonly IProfileRepository _profileRepository;
    private readonly IAuthenticationService _authenticationService;
    private readonly IMapper _mapper;

    public ProfileService(IProfileRepository profileRepository,IMapper mapper, IAuthenticationService authenticationService)
    {
        _profileRepository = profileRepository;
        _mapper = mapper;
        _authenticationService = authenticationService;
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

    public async Task<MessageResponseDto> RateAUserProfile(int profileId, RatingRequestDto rating, string authorizationHeader)
    {
        var currentUser = await _authenticationService.GetUserFromHeader(authorizationHeader);
        var currentUserProfile = await _profileRepository.GetByUserId(currentUser!.Id);
        if (currentUserProfile.Id == profileId)
        {
            throw new BadRequest400Exception("cannot rate yourself");
        }
        var profile = await _profileRepository.GetProfileByIdAsync(profileId);
        if (profile == null)
        {
            throw new NotFound404Exception("profile does not exist");
        }
        profile.TotalRatings += rating.Rating;
        profile.NumberOfUserThatHasRated += 1;
        await _profileRepository.SaveChangesAsync();
        return new MessageResponseDto
        {
            Status = "success",
            Message = "user rated successfully"
        };
    }

    public async Task<Profile?> GetCurrentUserProfile(string authorizationHeader)
    {
        var user = await _authenticationService.GetUserFromHeader(authorizationHeader);
        var profile = await _profileRepository.GetByUserId(user!.Id);
        if (profile == null)
        {
            throw new NotFound404Exception("user profile not found");
        }

        return profile;
    }
}
