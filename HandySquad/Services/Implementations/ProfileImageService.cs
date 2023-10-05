using HandySquad.dto.Profile;
using HandySquad.Repositories.Implementations;
using HandySquad.Services.Interfaces;

namespace HandySquad.Services.Implementations;

public class ProfileImageService:IProfileImageService
{
    private readonly ProfileImageRepository _profileImageRepository;

    public ProfileImageService(ProfileImageRepository profileImageRepository)
    {
        _profileImageRepository = profileImageRepository;
    }
    public async Task<int> UploadImageAsync(ProfileImageDto profileImageDto)
    {
        //Validate the ImageDto
        if (profileImageDto == null)
        {
            throw new ArgumentNullException(nameof(profileImageDto), "Image data is null");
        }

        if (string.IsNullOrWhiteSpace(profileImageDto.FileName))
        {
            throw new ArgumentException("FileName must not be empty", nameof(profileImageDto.FileName));
        }

        if (profileImageDto.Data == null || profileImageDto.Data.Length == 0)
        {
            throw new ArgumentException("Image Data must not be null or empty", nameof(profileImageDto.Data));
        }

        return await _profileImageRepository.UploadImageAync(profileImageDto);
     
    }

    public async Task UpdateImageAsync(int id, ProfileImageDto profileImageDto)
    {
        //id validation
        if (id <= 0)
        {
            throw new ArgumentException("invlaid Image Id", nameof(id));
        }
        //validate the profile image dto
        if (profileImageDto == null)
        {
            throw new ArgumentNullException(nameof(profileImageDto), "Image data is null");
        }

        if (string.IsNullOrWhiteSpace(profileImageDto.FileName))
        {
            throw new ArgumentException("FileName must not be empty", nameof(profileImageDto.FileName));
        }

        if (profileImageDto==null|| profileImageDto.Data.Length==0)
        {
            throw new ArgumentException("image data must not be null or empty", nameof(profileImageDto.Data));
        }

        await _profileImageRepository.UploadImageAsync(id, profileImageDto);
    }

    public async Task<ProfileImageDto> GetImageAsync(int id)
    {
        return await _profileImageRepository.GetImageAsync(id);
    }
}