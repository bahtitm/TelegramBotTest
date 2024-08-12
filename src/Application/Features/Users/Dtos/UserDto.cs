namespace Application.Features.Users.Dtos
{
    public class UserDto
    {
        public uint Id { get; set; }
        public string? Login { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? MiddleName { get; set; }
        public string? Phone { get; set; }
        public string? Pasword { get; set; }
    }
}
