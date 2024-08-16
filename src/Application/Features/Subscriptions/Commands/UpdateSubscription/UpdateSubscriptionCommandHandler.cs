using Application.Features.Subscriptions.Dtos;

namespace Application.Features.Subscriptions.Commands.UpdateSubscription
{
    internal class UpdateSubscriptionCommandHandler : IRequestHandler<UpdateSubscriptionCommand, SubscriptionDto>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;
        public UpdateSubscriptionCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<SubscriptionDto> Handle(UpdateSubscriptionCommand request, CancellationToken cancellationToken)
        {
            var subscription = await dbContext.FindByIdAsync<Subscription>(request.Id);
            mapper.Map(request, subscription);
            await dbContext.SaveChangesAsync();
            return mapper.Map<SubscriptionDto>(subscription);
        }
    }
}
