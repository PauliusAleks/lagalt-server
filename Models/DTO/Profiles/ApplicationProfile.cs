using AutoMapper;
using lagalt_web_api.Models.DTO;
using lagalt_web_api.Models.DTO.ApplicationDTO;

namespace lagalt_web_api.Models.DTO.Profiles
{
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
