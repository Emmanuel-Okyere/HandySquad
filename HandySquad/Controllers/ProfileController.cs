using HandySquad.dto.Profile;
using HandySquad.Global_Exceptions;
using HandySquad.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HandySquad.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class ProfileController:ControllerBase
{
   private readonly IProfileService _profileService;

   public ProfileController(IProfileService profileService)
   {
      _profileService = profileService;
   }
   [HttpGet("{id}")]
   [ServiceFilter(typeof(ErrorHandlingAttributes))]
   public async Task<ActionResult<ProfileDto>> GetProfile(int id)
   {
      var profile = await _profileService.GetProfileAsync(id);
      if (profile == null)
         return NotFound();
      return Ok(profile);
   }

   [HttpGet]
   [ServiceFilter(typeof(ErrorHandlingAttributes))]
   public async Task<ActionResult<IEnumerable<ProfileDto>>> GetAllProfiles()
   {
      var profiles = await _profileService.GetAllProfilesAsync();
      return Ok(profiles);
   }

   // [HttpPost]
   // [ServiceFilter(typeof(ErrorHandlingAttributes))]
   //
   // public async Task<IActionResult> CreateProfile(ProfileDto profileDto)
   // {
   //    await _profileService.CreateProfileAsync(profileDto);
   //    return CreatedAtAction(nameof(GetProfile), new { id = profileDto.Id }, profileDto);
   // }

   [HttpPut("{id}")]
   [ServiceFilter(typeof(ErrorHandlingAttributes))]
   public async Task<IActionResult> UpdateProfile(int id, ProfileDto profileDto)
   {
      await _profileService.UpdateProfileAsync(id, profileDto);
      return NoContent();
   }

   [HttpDelete("{id}")]
   [ServiceFilter(typeof(ErrorHandlingAttributes))]
   public async Task<IActionResult> DeleteProfile(int id)
   {
      await _profileService.DeleteProfileAsync(id);
      return NoContent();
   }
}
