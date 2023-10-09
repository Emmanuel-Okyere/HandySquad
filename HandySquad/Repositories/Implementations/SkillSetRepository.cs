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

    public async Task CreateSkillSetAsync(SkillSet skillSet)
    {
        if (skillSet == null)
        {
            throw new ArgumentNullException(nameof(skillSet));
        }

        _dataContext.SkillSets.Add(skillSet);
         await _dataContext.SaveChangesAsync();
    }

    public async  Task UpdateSkillSetAync(int id, SkillSet updatSkillSet)
    {
        var skillSet = await _dataContext.SkillSets.FindAsync(id);
        //exception handling here
        // if (skillSet == null)
        // {
        //     throw new Exception($"Skillset with {id} not Found");
        // }
         // skillSet.Skills = updateSkillSetDtoRequest.Skills;
         skillSet.Skills = updatSkillSet.Skills;
        
        await _dataContext.SaveChangesAsync();
    }

    public async  Task DeleteSkillSetAsync(int id)
    {
        var skillSet = await _dataContext.SkillSets.FindAsync(id);
        ///exception to be handled priperly
        if (skillSet == null)
        {
            throw new Exception($"Skillset with {id} not Found");
        }

        _dataContext.SkillSets.Remove(skillSet);
        await _dataContext.SaveChangesAsync();
    }
}