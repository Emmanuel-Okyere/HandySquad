using HandySquad.dto.Profile.SkillSet;
using HandySquad.Models;

namespace HandySquad.Services.Interfaces;

public interface ISkillSetService
{
    Task<List<SkillSet>> GetAllSkillSetsAsync();
    Task<SkillSet?> GetSkillSetByIdAync(int id);
    Task CreateSkillSetAsync(SkillSet skillSet);
    Task UpdateSkillSetAync(int id, SkillSetDto updateSkillSet);
    Task DeleteSkillSetAsync(int id);
}