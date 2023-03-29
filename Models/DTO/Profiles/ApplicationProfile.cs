using AutoMapper;
using lagalt_web_api.Models.DTO;
using lagalt_web_api.Models.DTO.ApplicationDTO;

namespace lagalt_web_api.Models.DTO.Profiles
{
    /// <summary>
    /// Simple profile for mapping from domain objects to DTOs and vice versa.
    /// </summary>
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<Application, ApplicationReadDTO>().ReverseMap();
            CreateMap<ApplicationEditDTO, Application>();
            CreateMap<ApplicationCreateDTO, Application>();
        }
    }
}
