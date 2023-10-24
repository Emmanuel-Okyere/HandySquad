using HandySquad.dto.Profile.SkillSet;
using HandySquad.Models;


namespace HandySquad.Services.Interfaces;

public interface ISkillSetService
{
    Task<IEnumerable<SkillSetDto>> GetAllSkillSetsAsync();
    Task<SkillSetDto?> GetSkillSetByIdAync(int id);
    Task<SkillSetDto> CreateSkillSetAsync(SkillSetDto skillSetDto);
    Task UpdateSkillSetAync(int id, SkillSetDto skillSetDto);
    Task DeleteSkillSetAsync(int id);
}