

namespace Application.Features.Users.Commands.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
    {
        private readonly IApplicationDbContext dbContext;

        public DeleteUserCommandHandler(IApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await dbContext.FindByIdAsync<User>(request.id);
            dbContext.Set<User>().Remove(user);
            await dbContext.SaveChangesAsync();
        }
    }
}