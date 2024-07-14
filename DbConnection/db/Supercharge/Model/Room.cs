using System;
using System.Collections.Generic;

namespace DbConnection.db.Supercharge.Model;

public partial class Room
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

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual User? CreatedByNavigation { get; set; }

    public virtual Hotel Hotel { get; set; } = null!;

    public virtual User? ModifiedByNavigation { get; set; }

    public virtual Price Price { get; set; } = null!;
}
