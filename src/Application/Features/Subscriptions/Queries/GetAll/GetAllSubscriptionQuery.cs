using Application.Features.Subscriptions.Dtos;

namespace Application.Features.Subscriptions.Queries.GetAll
{
    public record GetAllSubscriptionQuery : IRequest<IEnumerable<SubscriptionDto>>;
}
