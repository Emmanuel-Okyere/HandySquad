using HandySquad.dto.Profile;
using HandySquad.Repositories.Implementations;
using HandySquad.Services.Implementations;
using Microsoft.AspNetCore.Mvc;

namespace HandySquad.Controllers;

[Route("api/images")]
[ApiController]
public class ProfileImageController:ControllerBase
{
    private readonly ProfileImageService _profileImageService;

    public ProfileImageController(ProfileImageService profileImageService)
    {
        _profileImageService = profileImageService;
    }

    [HttpPost]
    [Route("upload")]
    public async Task<ActionResult<int>> UploadImage([FromBody] ProfileImageDto profileImageDto)
    {
        var imageId = await _profileImageService.UploadImageAsync(profileImageDto);
        return Ok(imageId);
    }

    [HttpPut]
    [Route("update/{id}")]
    public async Task<IActionResult> UpdateImage(int id, [FromBody] ProfileImageDto profileImageDto)
    {
        await _profileImageService.UpdateImageAsync(id, profileImageDto);
        return Ok();
    }
    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<ProfileImageDto>> GetImage(int id)
    {
        var profileImageDto = await _profileImageService.GetImageAsync(id);
        if (profileImageDto == null)
        {
            return NotFound();
        }

        return Ok(profileImageDto);
    }
}