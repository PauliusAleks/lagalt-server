using lagalt_web_api.Models.DTO;
using AutoMapper;
using lagalt_web_api.Models;
using lagalt_web_api.Models.DTO.UserDTO;

namespace lagalt_web_api.Models.DTO.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile() { 
            CreateMap<User, UserReadDTO>()
                .ReverseMap();

        /* 
         * CreateMap<Movie, MovieReadDTO>()
            .ForMember(mvDTO => mvDTO.CharacterIds, opt => opt // maps from List with Character objects to an array with Character PKs.
            .MapFrom(mv => mv.Characters.Select(ch => ch.Id).ToArray()));
        CreateMap<MovieEditDTO, Movie>();
        CreateMap<MovieCreateDTO, Movie>();
        */
        }
    }
}
