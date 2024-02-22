using System.ComponentModel.DataAnnotations;

namespace Back.Models
{
    public class Address
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        [StringLength(32)]
        public required string Name { get; set; }

        [StringLength(128)]
        public required string FirstName { get; set; }
        [StringLength(128)]
        public required string LastName { get; set; }
        [StringLength(32)]
        public required string Phone { get; set; }

        [StringLength(128)]
        public required string Street { get; set; }
        public required int StreetNumber { get; set; }
        [StringLength(8)]
        public string? Department { get; set; }
        public int DepartmentFloor { get; set; }
        [StringLength(8)]
        public string? DepartmentTower { get; set; }
        [StringLength(8)]
        public required string ZipCode { get; set; }
        [StringLength(128)]
        public required string State { get; set; }
        [StringLength(128)]
        public required string City { get; set; }
    }
}
