using AutoMapper;
using lagalt_web_api.Models.DTO.UserMessageDTO;

namespace lagalt_web_api.Models.DTO.Profiles
{
    public class UserMessageProfile : Profile
    {
        public UserMessageProfile()
        {
            CreateMap<UserMessage, UserMessageWithUsernameDTO>()
            .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.User.Username));

            CreateMap<UserMessageUserWithMessageDTO, UserMessage>();
        }
    }
}
