using lagalt_back_end.Models.DTO;
using AutoMapper;
using lagalt_back_end.Models;

namespace lagalt_web_api.Models.DTO.Profiles
{
    public class ProjectProfile : Profile
    {
        public ProjectProfile()
        {
            CreateMap<Project, ProjectDTO>();
        }
    }
}
