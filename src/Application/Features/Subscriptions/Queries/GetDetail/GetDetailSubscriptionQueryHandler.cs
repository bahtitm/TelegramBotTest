using Application.Features.Subscriptions.Dtos;

namespace Application.Features.Subscriptions.Queries.GetDetail
{
    internal class GetDetailSubscriptionQueryHandler : IRequestHandler<GetDetailSubscriptionQuery, SubscriptionDto>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;
        public GetDetailSubscriptionQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public async Task<SubscriptionDto> Handle(GetDetailSubscriptionQuery request, CancellationToken cancellationToken)
        {
            var subscription = await dbContext.FindByIdAsync<Subscription>(request.id);
            return mapper.Map<SubscriptionDto>(subscription);
        }
    }
}
