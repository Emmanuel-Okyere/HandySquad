using HandySquad.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HandySquad.Controllers;

public class ProfileController:ControllerBase
{
   private readonly IProfileService _profileService;

   public ProfileController(IProfileService profileService)
   {
      _profileService = profileService;
   }
}