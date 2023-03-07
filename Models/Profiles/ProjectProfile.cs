using lagalt_back_end.Models.DTO;
using AutoMapper;

namespace lagalt_back_end.Models.Profiles
{
    public class ProjectProfile : Profile
    {
        public ProjectProfile()
        {
            CreateMap<Project, ProjectDTO>();
        }
    }
}
