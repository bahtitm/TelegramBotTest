namespace Application.Features.Users.Commands.DeleteUser
{
    public record DeleteUserCommand(uint id) : IRequest;
}