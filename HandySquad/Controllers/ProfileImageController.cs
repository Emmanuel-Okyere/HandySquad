using HandySquad.dto.Profile;
using HandySquad.Global_Exceptions;
using HandySquad.Repositories.Implementations;
using HandySquad.Services.Implementations;
using Microsoft.AspNetCore.Mvc;

namespace HandySquad.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class ProfileImageController : ControllerBase
{
    private readonly ProfileImageService _profileImageService;

    public ProfileImageController(ProfileImageService profileImageService)
    {
        _profileImageService = profileImageService;
    }

    [HttpGet("{id}")]
    [ServiceFilter(typeof(ErrorHandlingAttributes))]
    public async Task<ActionResult<ProfileImageDto>> GetProfileImage(int id)
    {
        var profileImage = await _profileImageService.GetProfileImageAsync(id);
        if (profileImage == null)
            return NotFound();
        return Ok(profileImage);
    }

    [HttpPost]
    [ServiceFilter(typeof(ErrorHandlingAttributes))]
    public async Task<IActionResult> CreateProfileImage(ProfileImageDto profileImageDto)
    {
        await _profileImageService.CreateProfileImageAsync(profileImageDto);
        return CreatedAtAction(nameof(GetProfileImage), new { id = profileImageDto.Id }, profileImageDto);
    }

    [HttpPut("{id}")]
    [ServiceFilter(typeof(ErrorHandlingAttributes))]
    public async Task<IActionResult> UpdateProfileImage(int id, ProfileImageDto profileImageDto)
    {
        await _profileImageService.UpdateProfileImageAsync(id, profileImageDto);
        return NoContent();
    }
    [HttpDelete("{id}")]
    [ServiceFilter(typeof(ErrorHandlingAttributes))]
    public async Task<IActionResult> DeleteProfileImage(int id)
    {
        await _profileImageService.DeleteProfileImageAsync(id);
        return NoContent();
    }
}