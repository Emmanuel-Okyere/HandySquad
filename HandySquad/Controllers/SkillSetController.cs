using HandySquad.dto.Profile.SkillSet;
using HandySquad.Models;
using HandySquad.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HandySquad.Controllers;
[Route("api/[controller]")]
[ApiController]
public class SkillSetController:ControllerBase
{
    private readonly ISkillSetService _skillSetService;

    public SkillSetController(ISkillSetService skillSetService)
    {
        _skillSetService = skillSetService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<SkillSetDto>>> GetSkillSets()
    {
        var skillSet = await _skillSetService.GetAllSkillSetsAsync();
        return Ok(skillSet);
    }

    [HttpGet]
    public async Task<ActionResult<SkillSetDto>> GetSkillSet(int id)
    {
        var skillSet = await _skillSetService.GetSkillSetByIdAync(id);
        if (skillSet == null)
        {
            return NotFound();
        }

        return Ok(skillSet);
    }

    
    [HttpPost]
    public async Task<ActionResult<SkillSetDto>> PostOccupation(SkillSet skillSetDto)
    {
        if (skillSetDto == null)
        {
            return BadRequest();
        }

        try
        {
            await _skillSetService.CreateSkillSetAsync(skillSetDto);
            return CreatedAtAction("GetSkillSet", new { id = skillSetDto.Id }, skillSetDto);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> PutSkillSet(int id, SkillSetDto updateSkillSetDto)
    {
        if (updateSkillSetDto == null)
        {
            return BadRequest();
        }

        try
        {
            await _skillSetService.UpdateSkillSetAync(id, updateSkillSetDto);
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // DELETE: api/Occupation/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSkillSet(int id)
    {
        try
        {
            await _skillSetService.DeleteSkillSetAsync(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}