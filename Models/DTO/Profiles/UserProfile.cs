using lagalt_web_api.Models.DTO;
using AutoMapper;
using lagalt_web_api.Models;
using lagalt_web_api.Models.DTO.UserDTO;

namespace lagalt_web_api.Models.DTO.Profiles
{
    public class UserProfile : Profile
    {
        /// <summary>
        /// Configures the AutoMapper profile for the User model.
        /// </summary>
        public UserProfile()
        {
            CreateMap<User, UserReadDTO>()
                .ForMember(userDTO => userDTO.Skills, opt => opt
                .MapFrom(user => user.Skills.Select(sk => sk.Name)))
                .ForMember(userDTO => userDTO.AdminProjects, opt => opt
                .MapFrom(user => user.AdminProjects.Select(ad => ad.Id)))
                .ForMember(userDTO => userDTO.ContributorProjects, opt => opt
                .MapFrom(user => user.ContributorProjects.Select(con => con.Id)));

            CreateMap<User, UserCreateDTO>().ReverseMap();

            // Maps properties from UserEditDTO to User and vice versa.
            CreateMap<UserEditDTO, User>().ReverseMap();

            //CreateMap<User, UserHiddenDTO>().ReverseMap();
        }
    }
}
