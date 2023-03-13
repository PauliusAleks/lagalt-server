using lagalt_web_api.Models.DTO.ProjectDTO;
using AutoMapper; 

namespace lagalt_web_api.Models.DTO.Profiles
{
    public class ProjectProfile : Profile
    {
        public ProjectProfile()
        {

            CreateMap<Project, ProjectReadDTO>()
                .ReverseMap();

            //CreateMap<Project, ProjectCreateDTO>()
            //    .ReverseMap();

            //CreateMap<Project, ProjectEditDTO>()
            //    .ReverseMap();

            CreateMap<Project, ProjectReadDTO>()
                .ForMember(sk => sk.NeededSkillsName, opt => opt
                .MapFrom(pj => pj.NeededSkills.Select(sk => sk.Name).ToArray()))

                .ForMember(img => img.ImageUrls, opt => opt
                .MapFrom(pj => pj.ImageURLs.Select(j => j.Url).ToArray()))

                .ForMember(prDTO => prDTO.Progress, opt => opt
                .MapFrom(project => project.Progress.ToString()))
                
                .ForMember(cat => cat.Category, opt => opt
                .MapFrom(cat => cat.Category.ToString()));

            
             /* 
            CreateMap<Project, ProjectBannerDTO>()
                .ForMember(prDTO => prDTO.NeededSkillsId, opt => opt
                .MapFrom(pr=>pr.NeededSkills.Select(sk=>sk.Id).ToArray()));
            */
        }
    }
}
