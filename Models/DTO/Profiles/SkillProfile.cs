using AutoMapper;
using lagalt_web_api.Models.DTO.SkillDTO;
using lagalt_web_api.Models.DTO.UserDTO;

namespace lagalt_web_api.Models.DTO.Profiles
{
    public class SkillProfile : Profile
    {
        public SkillProfile()
        {
            CreateMap<Skill, SkillReadDTO>();

        }
    }
}
