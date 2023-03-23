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
                .ForMember(userDTO => userDTO.Skills, opt => opt
                .MapFrom(user => user.Skills.Select(sk => sk.Name)));

            CreateMap<User, UserCreateDTO>().ReverseMap();

            //Src  //Dest
            CreateMap<UserEditDTO, User>().ReverseMap();

            //CreateMap<User, UserHiddenDTO>().ReverseMap();

        }
    }
}
