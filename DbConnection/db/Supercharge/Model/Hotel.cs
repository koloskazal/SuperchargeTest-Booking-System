using System;
using System.Collections.Generic;

namespace DbConnection.db.Supercharge.Model;

public partial class Hotel
{
    public int HotelId { get; set; }

    public string Name { get; set; } = null!;

    public string? Address { get; set; }

    public bool IsActive { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedOnUtc { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedOnUtc { get; set; }

    public virtual User? CreatedByNavigation { get; set; }

    public virtual User? ModifiedByNavigation { get; set; }

    public virtual ICollection<Price> Prices { get; set; } = new List<Price>();

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
}
