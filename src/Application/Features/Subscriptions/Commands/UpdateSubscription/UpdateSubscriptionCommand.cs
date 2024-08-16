using Application.Features.Subscriptions.Dtos;

namespace Application.Features.Subscriptions.Commands.UpdateSubscription
{
    public class UpdateSubscriptionCommand : IRequest<SubscriptionDto>
    {
        public uint Id { get; set; }
    }
}
