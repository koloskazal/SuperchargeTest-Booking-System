using DbConnection.db.Supercharge.Model;
using System.ComponentModel.DataAnnotations;

namespace DbConnection.Resources
{
    public record RoomResource
    {
        public int RoomId { get; set; }

        public int HotelId { get; set; }

        public int PriceId { get; set; }

        public string? RoomNumber { get; set; }

        public string? Type { get; set; }

        public int NumberOfPlaces { get; set; }

        public string? Description { get; set; }

        public bool IsActive { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? CreatedOnUtc { get; set; }

        public int? ModifiedBy { get; set; }

        public DateTime? ModifiedOnUtc { get; set; }

        public List<BookingResource>? Bookings { get; set; } 
    }
}
