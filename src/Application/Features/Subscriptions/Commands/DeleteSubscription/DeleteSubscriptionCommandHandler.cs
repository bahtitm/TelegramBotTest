namespace Application.Features.Subscriptions.Commands.DeleteSubscription
{
    public class DeleteSubscriptionCommandHandler : IRequestHandler<DeleteSubscriptionCommand>
    {
        private readonly IApplicationDbContext dbContext;

        public DeleteSubscriptionCommandHandler(IApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task Handle(DeleteSubscriptionCommand request, CancellationToken cancellationToken)
        {
            var subscription = await dbContext.FindByIdAsync<Subscription>(request.id);
            dbContext.Set<Subscription>().Remove(subscription);
            await dbContext.SaveChangesAsync();
        }
    }
}
