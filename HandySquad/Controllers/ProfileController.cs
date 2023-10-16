using System.Security.Claims;
using HandySquad.dto;
using HandySquad.dto.Profile;
using HandySquad.Global_Exceptions;
using HandySquad.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HandySquad.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
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
   [ProducesResponseType(StatusCodes.Status200OK)]
   [ProducesResponseType(StatusCodes.Status404NotFound)]
   [ProducesResponseType(StatusCodes.Status400BadRequest)]
   public async Task<ActionResult> GetUserProfile([FromHeader(Name = "Authorization")] string authorizationHeader)
   {
      return Ok(await _profileService.GetCurrentUserProfile(authorizationHeader));
   }

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

   [HttpPatch("{id:int}/rate")]
   [ProducesResponseType(StatusCodes.Status200OK)]
   [ProducesResponseType(StatusCodes.Status404NotFound)]
   [ProducesResponseType(StatusCodes.Status400BadRequest)]
   public async Task<IActionResult> RateAUserProfile([FromRoute]int id, [FromBody] RatingRequestDto rating
      ,[FromHeader(Name = "Authorization")] string authorizationHeader )
   {
      return Ok(await _profileService.RateAUserProfile(id, rating, authorizationHeader));
   }
}
