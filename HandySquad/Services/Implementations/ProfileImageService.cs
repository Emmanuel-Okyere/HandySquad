using AutoMapper;
using HandySquad.dto.Profile;
using HandySquad.Models;
using HandySquad.Models.ProfileModels;
using HandySquad.Repositories.Implementations;
using HandySquad.Repositories.Interfaces;
using HandySquad.Services.Interfaces;

namespace HandySquad.Services.Implementations;

public class ProfileImageService:IProfileImageService
{
    private readonly IProfileImageRepository _profileImageRepository;
    private readonly IMapper _mapper;

    public ProfileImageService(IProfileImageRepository profileImageRepository,IMapper mapper)
    {
        _profileImageRepository = profileImageRepository;
        _mapper = mapper;
    }

    public async Task<ProfileImageDto> GetProfileImageAsync(int id)
    {
        var profileImage = await _profileImageRepository.GetProfileImageByIdAsync(id);
        return _mapper.Map<ProfileImageDto>(profileImage);
    }

    public async Task CreateProfileImageAsync(ProfileImageDto profileImageDto)
    {
        var profileImage = _mapper.Map<ProfileImage>(profileImageDto);
        await _profileImageRepository.CreateProfileImageAsync(profileImage);
    }

    public async Task UpdateProfileImageAsync(int id, ProfileImageDto profileImageDto)
    {
        var existingProfileImage = await _profileImageRepository.GetProfileImageByIdAsync(id);
        if (existingProfileImage != null)
        {
            _mapper.Map(profileImageDto, existingProfileImage);
            await _profileImageRepository.UpdateProfileImageAsync(existingProfileImage);
        }
    }

    public async Task DeleteProfileImageAsync(int id)
    {
        await _profileImageRepository.DeleteProfileImageAsync(id);

    }

   
}