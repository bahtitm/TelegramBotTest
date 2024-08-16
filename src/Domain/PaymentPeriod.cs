namespace Domain
{
    public class PaymentPeriod : BaseEntity
    {
        public decimal Payment { get; set; }
        public Period Period { get; set; }

        public virtual Subscription? Subscription { get; set; }

    }
     public enum Period
    {
        None = 0,
        Week = 1,
        TwoWeek = 2,
        Month= 3,
        ThreeMonth = 4,
        SixMonth = 5,  

    }
}
