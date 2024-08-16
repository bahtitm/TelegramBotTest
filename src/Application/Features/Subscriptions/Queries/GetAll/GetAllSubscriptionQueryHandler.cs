using Application.Features.Subscriptions.Dtos;

namespace Application.Features.Subscriptions.Queries.GetAll
{
    public class GetAllSubscriptionQueryHandler : IRequestHandler<GetAllSubscriptionQuery, IEnumerable<SubscriptionDto>>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;
        public GetAllSubscriptionQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<SubscriptionDto>> Handle(GetAllSubscriptionQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(dbContext.Set<Subscription>().ProjectTo<SubscriptionDto>(mapper.ConfigurationProvider));
        }
    }
}
