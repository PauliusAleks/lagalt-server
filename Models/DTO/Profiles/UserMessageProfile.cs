using AutoMapper;
using lagalt_web_api.Models.DTO.UserMessageDTO;

namespace lagalt_web_api.Models.DTO.Profiles
{
    /// <summary>
    /// AutoMapper profile for UserMessage related DTOs
    /// </summary>
    public class UserMessageProfile : Profile
    {
        public UserMessageProfile()
        {
            // Mapping from UserMessage to UserMessageWithUsernameDTO
            CreateMap<UserMessage, UserMessageWithUsernameDTO>()
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.User.Username));

            // Mapping from UserMessageUserWithMessageDTO to UserMessage
            CreateMap<UserMessageUserWithMessageDTO, UserMessage>();
        }
    }
}
