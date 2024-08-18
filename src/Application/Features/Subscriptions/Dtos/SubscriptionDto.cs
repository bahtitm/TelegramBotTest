namespace Application.Features.Subscriptions.Dtos
{
    public class SubscriptionDto
    {
        public uint Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public uint PaymentPeriodId { get; set; }
    }
}
