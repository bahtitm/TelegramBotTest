using Application.Features.Subscriptions.Dtos;

namespace Application.Features.Subscriptions.Queries.GetDetail
{
    public record GetDetailSubscriptionQuery(uint id) : IRequest<SubscriptionDto>;
}
