using HandySquad.dto.Profile.SkillSet;
using HandySquad.Models;

namespace HandySquad.Repositories.Interfaces;

public interface ISkillSetReposiotry
{
    Task<List<SkillSet>> GetAllSkillSetsAsync();
    Task<SkillSet?> GetSkillSetByIdAync(int id);
    Task CreateSkillSetAsync(SkillSet skillSet);
    Task UpdateSkillSetAync(int id, SkillSet upSkillSet);
    Task DeleteSkillSetAsync(int id);
}