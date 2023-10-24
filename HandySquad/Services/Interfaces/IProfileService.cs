using HandySquad.dto;
using HandySquad.dto.Profile;
using HandySquad.Models.ProfileModels;
using HandySquad.Pagination;


namespace HandySquad.Services.Interfaces;

public interface IProfileService
{
    Task<ProfileDto> GetProfileAsync(int id);
    Task<IEnumerable<ProfileDto>> GetAllProfilesAsync();
    Task<PaginatedResultDto<ProfileDto>> SearchProfilesAsync(ProfileSearchParameters profileSearchParameters, int page , int pageSize);
    Task<Profile> CreateProfileAsync(ProfileDto profileDto);
    Task UpdateProfileAsync(int id, ProfileDto profileDto);
    Task DeleteProfileAsync(int id);
    Task<MessageResponseDto> RateAUserProfile(int profileId, RatingRequestDto rating, string authorizationHeader);
    Task<Profile?> GetCurrentUserProfile(string authorizationHeader);
}