namespace Application.Features.Users.Queries.GetDetail
{
    public record GetDetailUserQuery(uint id) : IRequest<UserDto>;
}
