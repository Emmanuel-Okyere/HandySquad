using HandySquad.dto.Profile;
using HandySquad.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HandySquad.Controllers;

[ApiController]
[Route("api/profiles")]
public class ProfileController:ControllerBase
{
   private readonly IProfileService _profileService;

   public ProfileController(IProfileService profileService)
   {
      _profileService = profileService;
   }

   [HttpGet]
   public async Task<IActionResult> GetAllProfiles()
   {
      try
      {
         var profiles = await _profileService.GetAllProfilesAsync();
         return Ok(profiles);
      }
      catch (Exception ex)
      {
         return StatusCode(500, "Internal Server Error");
      }
   }

   [HttpGet("{id}")]
   public async Task<IActionResult> GetProfileById(int id)
   {
      try
      {
         var profile = await _profileService.GetProfileByIdAsync(id);
         if (profile == null)
         {
            return NotFound();
         }

         return Ok(profile);
      }
      catch (Exception ex)
      {
         return StatusCode(500, "Internet Server Error");
      }
   }

   [HttpPost]
   public async Task<IActionResult> CreateProfile([FromBody] CreateProfileDto createProfileDto)
   {
      try
      {
         var id = await _profileService.CreateProfileAsync(createProfileDto);
         return CreatedAtAction(nameof(GetProfileById), new { id }, null);
      }
      catch (Exception e)
      {
         return StatusCode(500, "Internal Server Error");
      }
   }

   [HttpPut("{id}")]
   public async Task<IActionResult> UpdateProfile(int id, [FromBody] UpdateProfileDto updateProfileDto)
   {
      try
      {
         await _profileService.UpdateProfileAsync(id, updateProfileDto);
         return NoContent();
      }
      catch (Exception )
      {
         return StatusCode(500, "Internal Server Error");
         throw;
      }
   }

   [HttpDelete]
   public async Task<IActionResult> DeleteProfile(int id)
   {
      try
      {
         await _profileService.DeleteProfileAsync(id);
         return NoContent();
      }
      catch (Exception e)
      {
         return StatusCode(500, "Internal Server Error");
      }
   }
}