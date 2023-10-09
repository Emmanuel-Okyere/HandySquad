using HandySquad.Data;
using HandySquad.dto.Profile.SkillSet;
using HandySquad.Models;
using HandySquad.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HandySquad.Repositories.Implementations;

public class SkillSetRepository:ISkillSetReposiotry
{
    private readonly DataContext _dataContext;

    public SkillSetRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<List<SkillSet>> GetAllSkillSetsAsync()
    {
        return await _dataContext.SkillSets.ToListAsync();
    }

    public async Task<SkillSet?> GetSkillSetByIdAync(int id)
    {
        return await _dataContext.SkillSets.FindAsync(id);
    }

    public async Task CreateSkillSetAsync(SkillSet skillSetDto)
    {
        if (skillSetDto == null)
        {
            throw new ArgumentNullException(nameof(skillSetDto));
        }

        _dataContext.SkillSets.Add(skillSetDto);
         await _dataContext.SaveChangesAsync();
    }

    public async  Task UpdateSkillSetAync(int id, SkillSetDto updateSkillSetDto)
    {
        var skillSet = await _dataContext.SkillSets.FindAsync(id);
        if (skillSet == null)
        {
            throw new Exception($"Skillset with {id} not Found");
        }
        skillSet.Skills = updateSkillSetDto.Skills;
        await _dataContext.SaveChangesAsync();
    }

    public async  Task DeleteSkillSetAsync(int id)
    {
        var skillSet = await _dataContext.SkillSets.FindAsync(id);
        if (skillSet == null)
        {
            throw new Exception($"Skillset with {id} not Found");
        }

        _dataContext.SkillSets.Remove(skillSet);
        await _dataContext.SaveChangesAsync();
    }
}