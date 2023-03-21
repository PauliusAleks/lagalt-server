using AutoMapper;
using lagalt_web_api.Models.DTO.ProjectDTO.ProjectReadDTO;
using lagalt_web_api.Models.DTO.ProjectDTO.ProjectEditDTO;
using lagalt_web_api.Models.DTO.ProjectDTO.ProjectCreateDTO;

namespace lagalt_web_api.Models.DTO.Profiles
{
    public class ProjectProfile : Profile
    {
        public ProjectProfile()
        {

            //MapperReceiver mapperReceiver = new MapperReceiver();

            CreateMap<Project, ProjectCreateDTO>()
                .ForMember(projectCreateDto => projectCreateDto.NeededSkills, opt => opt.MapFrom(project => project.NeededSkills))
                .ReverseMap();

            CreateMap<ProjectEditDTO, Project>();
            /*.ForMember(pr => pr.Progress, opt => opt
            .MapFrom(prDTO => prDTO.Progress))

            .ForMember(pr => pr.Category, opt => opt
            .MapFrom(prDTO => prDTO.Category)*/


            CreateMap<Project, ProjectBannerDTO>()
                .ForMember(prDTO => prDTO.Progress, opt => opt
                .MapFrom(pr => pr.Progress.ToString()))

                .ForMember(prDTO => prDTO.Category, opt => opt
                .MapFrom(pr => pr.Category.ToString()))

                .ForMember(prDTO => prDTO.NeededSkillsName, opt => opt
                .MapFrom(pr => pr.NeededSkills.Select(sk => sk.Name).ToArray()))

                .ForMember(prDTO => prDTO.BannerImage, opt => opt
                .MapFrom(pr => pr.ImageURLs.FirstOrDefault().Url));

            CreateMap<Project, ProjectPageDTO>()
                .ForMember(prDTO => prDTO.NeededSkillsName, opt => opt
                .MapFrom(pr => pr.NeededSkills.Select(sk => sk.Name).ToArray()))

                .ForMember(prDTO => prDTO.ImageUrls, opt => opt
                .MapFrom(pr => pr.ImageURLs.Select(img => img.Url).ToArray()))

                //.ForMember(prDTO => prDTO.Contributors, opt => opt
                //.MapFrom(pr => pr.Contributors.Select(con => con.Username).ToArray()))

                .ForMember(prDTO => prDTO.Progress, opt => opt
                .MapFrom(pr => pr.Progress.ToString()))

                .ForMember(prDTO => prDTO.Category, opt => opt
                .MapFrom(pr => pr.Category.ToString())
                );

            CreateMap<Project, ProjectAdminDTO>()
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
                .MapFrom(pr => pr.Category.ToString())
                );
        }
    }
}
