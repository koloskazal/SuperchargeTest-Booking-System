using DbConnection.db.Supercharge.Model;
using System.ComponentModel.DataAnnotations;

namespace DbConnection.Resources
{
    public record VisitorResource
    {
        public int VisitorId { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(50, ErrorMessage = "Last name cannot be longer than 50 characters.")]
        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string? Phone { get; set; }

        public bool IsActive { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? CreatedOnUtc { get; set; }

        public int? ModifiedBy { get; set; }

        public DateTime? ModifiedOnUtc { get; set; }

        public List<BookingResource>? Bookings { get; set; } 
    }
}
