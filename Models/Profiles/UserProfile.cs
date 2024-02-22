using AutoMapper;
using Back.Models.DTO;

namespace Back.Models.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserSignupDto>();
            CreateMap<UserSignupDto, User>();

            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
        }
    }
}
