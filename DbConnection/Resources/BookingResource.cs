using DbConnection.db.Supercharge.Model;
using System.ComponentModel.DataAnnotations;

namespace DbConnection.Resources
{
    public record BookingResource
    {
        
        [Required(ErrorMessage = "First name is required.")]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        public string FirstName { get; set; } = null!;

        public int BookingId { get; set; }

        [Required(ErrorMessage = "VisitorId is required.")]
        public int VisitorId { get; set; }
        
        [Required(ErrorMessage = "RoomId is required.")]
        public int RoomId { get; set; }

        [Required(ErrorMessage = "StartDate is required.")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "StartDate is required.")]
        public DateTime EndDate { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime CreatedOnUtc { get; set; }

        public int? ModifiedBy { get; set; }

        public DateTime? ModifiedOnUtc { get; set; }

        
    }
}
