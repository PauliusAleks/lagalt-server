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

            CreateMap<Project, ProjectCreateDTO>()
                .ReverseMap();

            CreateMap<Project, ProjectEditDTO>()
                .ReverseMap();

            CreateMap<Project, ProjectReadDTO>()
                .ForMember(prDTO => prDTO.NeededSkillsName, opt => opt
                .MapFrom(pr => pr.NeededSkills.Select(sk => sk.Name).ToArray()))

                .ForMember(prDTO => prDTO.ImageUrls, opt => opt
                .MapFrom(pr => pr.ImageURLs.Select(img => img.Url).ToArray()))

                .ForMember(prDTO => prDTO.Admins, opt => opt
                .MapFrom(pr => pr.Admins.Select(ad => ad.Username).ToArray()))

                .ForMember(prDTO => prDTO.Contributors, opt => opt
                .MapFrom(pr => pr.Contributors.Select(con => con.Username).ToArray()))

                .ForMember(prDTO => prDTO.Progress, opt => opt
                .MapFrom(pr => pr.Progress.ToString()))

                .ForMember(prDTO => prDTO.Category, opt => opt
                .MapFrom(pr => pr.Category.ToString()));


            /* 
           CreateMap<Project, ProjectBannerDTO>()
               .ForMember(prDTO => prDTO.NeededSkillsId, opt => opt
               .MapFrom(pr=>pr.NeededSkills.Select(sk=>sk.Id).ToArray()));
           */
        }
    }
}
