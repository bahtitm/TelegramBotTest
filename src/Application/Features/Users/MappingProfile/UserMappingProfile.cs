using Application.Features.Users.Commands.CreateUser;
using Application.Features.Users.Commands.UpdateUser;

namespace Application.Features.Users.MappingProfile
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<CreateUserCommand, User>();
            CreateMap<UpdateUserCommand, User>();
            CreateMap<User, UserDto>();
        }
    }
}
