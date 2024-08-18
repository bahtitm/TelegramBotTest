using Application.Features.Subscriptions.Dtos;

namespace Application.Features.Subscriptions.Commands.CreateSubscription
{
    public class CreateSubscriptionCommand : IRequest<SubscriptionDto>
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public uint PaymentPeriodId { get; set; }
    }
}
