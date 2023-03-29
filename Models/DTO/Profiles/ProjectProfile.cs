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
            /// <summary>
            /// Mapping from ProjectDomain object to ProjectCreateDTO.
            /// Implicitly defining mapping for each member that will change its datatype.
            /// </summary>
            CreateMap<Project, ProjectCreateDTO>()
                 .ForMember(prDTO => prDTO.Progress, opt => opt
                .MapFrom(pr => pr.Progress.ToString()))

                .ForMember(prDTO => prDTO.Category, opt => opt
                .MapFrom(pr => pr.Category.ToString()));


            /// <summary>
            /// Mapping from ProjectEditDTO object to ProjectDomain.
            /// Implicitly defining mapping for each member that will change its datatype.
            /// </summary>
            CreateMap<ProjectEditDTO, Project>()
                .ForMember(prDTO => prDTO.Progress, opt => opt
                .MapFrom(pr => pr.Progress.ToString()))

                .ForMember(prDTO => prDTO.Category, opt => opt
                .MapFrom(pr => pr.Category.ToString()));

            /// <summary>
            /// Mapping from Project object to ProjectBannerDTO.
            /// Implicitly defining mapping for each member that will change its datatype.
            /// </summary>
            CreateMap<Project, ProjectBannerDTO>()
                .ForMember(prDTO => prDTO.Progress, opt => opt
                .MapFrom(pr => pr.Progress.ToString()))

                .ForMember(prDTO => prDTO.Category, opt => opt
                .MapFrom(pr => pr.Category.ToString()))

                .ForMember(prDTO => prDTO.NeededSkills, opt => opt
                .MapFrom(pr => pr.NeededSkills.Select(sk => sk.Name).ToArray()))

                .ForMember(prDTO => prDTO.BannerImage, opt => opt
                .MapFrom(pr => pr.ImageURLs.FirstOrDefault().Url));

            /// <summary>
            /// Mapping from Project object to ProjectPageDTO.
            /// Implicitly defining mapping for each member that will change its datatype.
            /// </summary>
            CreateMap<Project, ProjectPageDTO>()
                .ForMember(prDTO => prDTO.NeededSkills, opt => opt
                .MapFrom(pr => pr.NeededSkills.Select(sk => sk.Name).ToArray()))

                .ForMember(prDTO => prDTO.ImageUrls, opt => opt
                .MapFrom(pr => pr.ImageURLs.Select(img => img.Url).ToArray()))

                .ForMember(prDTO => prDTO.Contributors, opt => opt
                .MapFrom(pr => pr.Contributors.Select(con => con.Username).ToArray()))

                .ForMember(prDTO => prDTO.Progress, opt => opt
                .MapFrom(pr => pr.Progress.ToString()))

                .ForMember(prDTO => prDTO.Category, opt => opt
                .MapFrom(pr => pr.Category.ToString())
                );

            /// <summary>
            /// Mapping from Project object to ProjectAdminDTO.
            /// Implicitly defining mapping for each member that will change its datatype.
            /// </summary>
            CreateMap<Project, ProjectAdminDTO>()
                .ForMember(prDTO => prDTO.NeededSkills, opt => opt
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
