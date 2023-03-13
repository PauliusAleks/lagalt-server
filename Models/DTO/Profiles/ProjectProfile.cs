using lagalt_web_api.Models.DTO.ProjectDTO;
using AutoMapper; 

namespace lagalt_web_api.Models.DTO.Profiles
{
    public class ProjectProfile : Profile
    {
        public ProjectProfile()
        {
            CreateMap<Project, ProjectBannerDTO>().ReverseMap();
            CreateMap<ProjectCreateDTO, Project>().ReverseMap(); 
            CreateMap<ProjectCreateDTO, ProjectBannerDTO>().ReverseMap();  
        }
    }
}
