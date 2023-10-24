using HandySquad.dto.Profile.SkillSet;
using HandySquad.Models;


namespace HandySquad.Repositories.Interfaces;

public interface ISkillSetReposiotry
{
    Task<List<Skill>> GetAllSkillSetsAsync();
    Task<Skill?> GetSkillSetByIdAync(int id);
    Task CreateSkillSetAsync(Skill skill);
    Task UpdateSkillSetAync(int id, Skill upSkill);
    Task DeleteSkillSetAsync(int id);
}