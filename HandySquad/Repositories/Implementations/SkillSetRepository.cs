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

    public async Task<List<Skill>> GetAllSkillSetsAsync( )
    {
       return await _dataContext.SkillSets
           .OrderBy(s=>s.Name)
           // .Skip((skillsParameters.PageNumber-1)*skillsParameters.PageSize)
           // .Take(skillsParameters.PageSize)
           .ToListAsync();
       // List<Skill> skills = await _dataContext.SkillSets.OrderBy(s=>s.Name)
       //     .ToListAsync();
       // return PagedList<List<Skill>>
       //     .ToPagedList(skills, skillsParameters.PageNumber, skillsParameters.PageSize);

    }

    public async Task<Skill?> GetSkillSetByIdAync(int id)
    {
        return await _dataContext.SkillSets.FindAsync(id);
    }

    public async Task CreateSkillSetAsync(Skill skill)
    {
        if (skill == null)
        {
            throw new ArgumentNullException(nameof(skill));
        }

        _dataContext.SkillSets.Add(skill);
         await _dataContext.SaveChangesAsync();
    }

    public async  Task UpdateSkillSetAync(int id, Skill updatSkill)
    {
        var skillSet = await _dataContext.SkillSets.FindAsync(id);
        //exception handling here
        // if (skillSet == null)
        // {
        //     throw new Exception($"Skillset with {id} not Found");
        // }
         // skillSet.Skills = updateSkillSetDtoRequest.Skills;
         skillSet.Name = updatSkill.Name;
        
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