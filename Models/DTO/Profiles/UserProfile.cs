using lagalt_web_api.Models.DTO;
using AutoMapper;
using lagalt_web_api.Models;
using lagalt_web_api.Models.DTO.UserDTO;

namespace lagalt_web_api.Models.DTO.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserReadDTO>()
                .ForMember(userDTO => userDTO.SkillNames, opt => opt
                .MapFrom(user => user.Skills.Select(sk => sk.Name)))

                .ForMember(userDTO => userDTO.ApplicationIds, opt => opt
                .MapFrom(user => user.Applications.Select(app => app.Id)));

            CreateMap<User, UserCreateDTO>().ReverseMap();
            CreateMap<User, UserEditDTO>().ReverseMap();
            CreateMap<User, UserHiddenDTO>().ReverseMap();

        }
    }
}
