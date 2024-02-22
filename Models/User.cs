using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Back.Models
{
    [Index(nameof(Email), IsUnique = true)]
    public class User
    {
        public int Id { get; set; }
        [StringLength(256)]
        public required string Email { get; set; }
        public required string Password { get; set; }
        [StringLength(128)]
        public required string FirstName { get; set; }
        [StringLength(128)]
        public required string LastName { get; set; }

    }
}
