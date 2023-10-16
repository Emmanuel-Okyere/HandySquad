using HandySquad.dto;
using HandySquad.dto.Profile;
using HandySquad.Models.ProfileModels;

namespace HandySquad.Services.Interfaces;

public interface IProfileService
{
    Task<ProfileDto> GetProfileAsync(int id);
    Task<IEnumerable<ProfileDto>> GetAllProfilesAsync();
    Task<Profile> CreateProfileAsync(ProfileDto profileDto);
    Task UpdateProfileAsync(int id, ProfileDto profileDto);
    Task DeleteProfileAsync(int id);
    Task<MessageResponseDto> RateAUserProfile(int profileId, RatingRequestDto rating, string authorizationHeader);
    Task<Profile?> GetCurrentUserProfile(string authorizationHeader);
}