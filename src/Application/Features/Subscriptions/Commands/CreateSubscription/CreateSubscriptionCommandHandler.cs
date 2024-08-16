using Application.Features.Subscriptions.Dtos;

namespace Application.Features.Subscriptions.Commands.CreateSubscription
{
    internal class CreateSubscriptionCommandHandler : IRequestHandler<CreateSubscriptionCommand, SubscriptionDto>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;
        public CreateSubscriptionCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<SubscriptionDto> Handle(CreateSubscriptionCommand request, CancellationToken cancellationToken)
        {
            var subscription = mapper.Map<Subscription>(request);
            await dbContext.AddAsync(subscription);
            await dbContext.SaveChangesAsync();
            return mapper.Map<SubscriptionDto>(subscription);
        }
    }
}
