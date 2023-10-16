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
    
    // public async Task<List<SkillSet>> GetAllSkillSetsAsync()
    // {
    //     return await _skillSetReposiotry.GetAllSkillSetsAsync();
    // }
    //
    // public async Task<SkillSet?> GetSkillSetByIdAync(int id)
    // {
    //     return await _skillSetReposiotry.GetSkillSetByIdAync(id);
    // }
    //
    // public async Task CreateSkillSetAsync(SkillSet skillSetDto)
    // {
    //     if (skillSetDto == null)
    //     {
    //         throw new ArgumentNullException(nameof(skillSetDto));
    //     }
    //      await _skillSetReposiotry.CreateSkillSetAsync(skillSetDto);
    // }
    //
    // public async  Task UpdateSkillSetAync(int id, SkillSetDtoRequest updateSkillSet)
    // {
    //     if (updateSkillSet == null)
    //     {
    //         throw new ArgumentNullException(nameof(updateSkillSet));
    //     }
    //
    //     await _skillSetReposiotry.UpdateSkillSetAync(id, updateSkillSet);
    // }
    //
    //
    //
    // public async Task DeleteSkillSetAsync(int id)
    // {
    //     await _skillSetReposiotry.DeleteSkillSetAsync(id);
    // }


    public async  Task<List<SkillSetDto>> GetAllSkillSetsAsync()
    {
        var skillsets = _skillSetReposiotry.GetAllSkillSetsAsync();
        return await _mapper.Map<Task<List<SkillSetDto>>>(skillsets);
    }

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