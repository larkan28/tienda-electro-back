namespace Back.Models.DTO
{
    public class UserUpdateDto
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string? Password { get; set; }

    }
}
