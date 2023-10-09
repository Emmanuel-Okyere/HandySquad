using HandySquad.dto.Profile.SkillSet;
using HandySquad.Models;
using HandySquad.Repositories.Interfaces;
using HandySquad.Services.Interfaces;

namespace HandySquad.Services.Implementations;

public class SkillSetService:ISkillSetService
{
    private readonly ISkillSetReposiotry _skillSetReposiotry;

    public SkillSetService(ISkillSetReposiotry skillSetReposiotry)
    {
        _skillSetReposiotry = skillSetReposiotry;
    }

    public async Task<List<SkillSet>> GetAllSkillSetsAsync()
    {
        return await _skillSetReposiotry.GetAllSkillSetsAsync();
    }

    public async Task<SkillSet?> GetSkillSetByIdAync(int id)
    {
        return await _skillSetReposiotry.GetSkillSetByIdAync(id);
    }

    public async Task CreateSkillSetAsync(SkillSet skillSetDto)
    {
        if (skillSetDto == null)
        {
            throw new ArgumentNullException(nameof(skillSetDto));
        }
         await _skillSetReposiotry.CreateSkillSetAsync(skillSetDto);
    }

    public async  Task UpdateSkillSetAync(int id, SkillSetDto updateSkillSet)
    {
        if (updateSkillSet == null)
        {
            throw new ArgumentNullException(nameof(updateSkillSet));
        }

        await _skillSetReposiotry.UpdateSkillSetAync(id, updateSkillSet);
    }

    

    public async Task DeleteSkillSetAsync(int id)
    {
        await _skillSetReposiotry.DeleteSkillSetAsync(id);
    }
}