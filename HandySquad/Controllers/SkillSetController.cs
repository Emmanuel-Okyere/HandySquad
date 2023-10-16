using HandySquad.dto.Profile.SkillSet;
using HandySquad.Global_Exceptions;
using HandySquad.Models;
using HandySquad.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HandySquad.Controllers;
[Route("api/v1/[controller]")]
[ApiController]
public class SkillSetController:ControllerBase
{
    private readonly ISkillSetService _skillSetService;

    public SkillSetController(ISkillSetService skillSetService)
    {
        _skillSetService = skillSetService;
    }

    [HttpGet]
    [ServiceFilter(typeof(ErrorHandlingAttributes))]
    public async Task<ActionResult<IEnumerable<SkillSetDtoRequest>>> GetSkillSets()
    {
        var skillSet = await _skillSetService.GetAllSkillSetsAsync();
        return Ok(skillSet);
    }

    [HttpGet("{id:int}")]
    [ServiceFilter(typeof(ErrorHandlingAttributes))]
    public async Task<ActionResult<SkillSetDto>> GetSkillSet(int id)
    {
        var skillSetDto = await _skillSetService.GetSkillSetByIdAync(id);
        if (skillSetDto == null)
        {
            return NotFound();
        }
        
        return Ok(skillSetDto);
    }

    [HttpPost]
    [ServiceFilter(typeof(ErrorHandlingAttributes))]
        public ActionResult<SkillSetDto> CreateSkillSetAync([FromBody] SkillSetDto skillSetDto)
        {
            var createdSkillsetDto = _skillSetService.CreateSkillSetAsync(skillSetDto);
            return CreatedAtAction("", new { id = createdSkillsetDto.Id }, createdSkillsetDto);
        }
    
    
    [HttpPut("{id}")]
    [ServiceFilter(typeof(ErrorHandlingAttributes))]
    public async Task<IActionResult> UpdateSkillSetAysnc(int id, [FromBody] SkillSetDto skillsetDto)
    {
        var updatedSkillsetDto = _skillSetService.UpdateSkillSetAync(id, skillsetDto);
        if (updatedSkillsetDto == null)
            return NotFound();
        return NoContent();
    }

    // DELETE: api/SkillSet/5
    [HttpDelete("{id}")]
    [ServiceFilter(typeof(ErrorHandlingAttributes))]
    public async Task<IActionResult> DeleteSkillSet(int id)
    {
        await _skillSetService.DeleteSkillSetAsync(id);
        return NoContent();
    }
}