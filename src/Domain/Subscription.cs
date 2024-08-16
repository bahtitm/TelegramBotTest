namespace Domain
{
    public class Subscription : BaseEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public uint PaymentPeriodId { get; set; }
        public virtual PaymentPeriod? PaymentPeriod { get; set; }
        public virtual IEnumerable<User>? Users { get; set; }

    }
}
