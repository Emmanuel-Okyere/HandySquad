using AutoMapper;
using HandySquad.dto.Profile.SkillSet;
using HandySquad.Models;
using HandySquad.Repositories.Interfaces;
using HandySquad.Services.Interfaces;

namespace HandySquad.Services.Implementations;

public class SkillSetService:ISkillSetService
{
    private readonly ISkillSetReposiotry _skillSetReposiotry;
    private readonly IMapper _mapper;

    public SkillSetService(ISkillSetReposiotry skillSetReposiotry,IMapper mapper)
    {
        _skillSetReposiotry = skillSetReposiotry;
        _mapper = mapper;
    }
    
    public async  Task<IEnumerable<SkillSetDto>> GetAllSkillSetsAsync()
    {
        var skillsets = _skillSetReposiotry.GetAllSkillSetsAsync();
        return await _mapper.Map<Task<List<SkillSetDto>>>(skillsets);
    }

    //to make adjustment here

    public async Task<SkillSetDto?> GetSkillSetByIdAync(int id)
    {
        var getSkillSetbyId = await _skillSetReposiotry.GetSkillSetByIdAync(id);
        return  _mapper.Map<SkillSetDto>(getSkillSetbyId);
    }

    public  Task<SkillSetDto> CreateSkillSetAsync(SkillSetDto skillSetDto)
    {
        var skillSet =  _mapper.Map<Skill>(skillSetDto);
        
       return   (Task<SkillSetDto>)_skillSetReposiotry.CreateSkillSetAsync(skillSet);
          
    }

    public async Task UpdateSkillSetAync(int id, SkillSetDto skillSetDto)
    {
        var existingSkillset = _skillSetReposiotry.GetSkillSetByIdAync(id);
        if (existingSkillset != null)
        {
            _mapper.Map(skillSetDto, existingSkillset);
            _skillSetReposiotry.UpdateSkillSetAync(id,await existingSkillset);
        }
    }

    public async Task DeleteSkillSetAsync(int id)
    {
        await _skillSetReposiotry.DeleteSkillSetAsync(id);
    }
}