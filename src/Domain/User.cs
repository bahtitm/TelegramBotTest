namespace Domain
{
    public class User : BaseEntity
    {
        public string? Login { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? MiddleName { get; set; }
        public string? Phone { get; set; }
        public string? Pasword { get; set; }
        public virtual IEnumerable<Subscription>? Subscriptions { get; set; }
    }
}
