using Application.Features.Subscriptions.Dtos;

namespace Application.Features.Subscriptions.Commands.UpdateSubscription
{
    public class UpdateSubscriptionCommand : IRequest<SubscriptionDto>
    {
        public uint Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public uint PaymentPeriodId { get; set; }
    }
}
