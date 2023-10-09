using HandySquad.dto.Profile;
using HandySquad.dto.Profile.SkillSet;
using HandySquad.Models;
using Profile = AutoMapper.Profile;

namespace HandySquad.AutoMapper;

public class AutoMapperProfile:Profile
{
    public AutoMapperProfile()
    {
        CreateMap<SkillSetDto, SkillSet>();
        CreateMap<ProfileDto, Profile>();
        CreateMap<ProfileImageDto, ProfileImage>();
    }
}