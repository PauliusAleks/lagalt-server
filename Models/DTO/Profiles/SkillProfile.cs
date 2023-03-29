using AutoMapper;
using lagalt_web_api.Models.DTO.SkillDTO;
using lagalt_web_api.Models.DTO.UserDTO;

namespace lagalt_web_api.Models.DTO.Profiles
{
    /// <summary>
    /// AutoMapper profile for Skill entity and DTOs
    /// </summary>
    public class SkillProfile : Profile
    {
        /// <summary>
        /// Configures mappings between Skill entity and DTOs
        /// </summary>
        public SkillProfile()
        {
            CreateMap<Skill, SkillReadDTO>();
        }
    }
}
