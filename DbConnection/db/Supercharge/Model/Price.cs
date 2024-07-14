using System;
using System.Collections.Generic;

namespace DbConnection.db.Supercharge.Model;

public partial class Price
{
    public int PriceId { get; set; }

    public int HotelId { get; set; }

    public decimal Amount { get; set; }

    public string? PriceType { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public bool IsActive { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedOnUtc { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedOnUtc { get; set; }

    public virtual User? CreatedByNavigation { get; set; }

    public virtual Hotel Hotel { get; set; } = null!;

    public virtual User? ModifiedByNavigation { get; set; }

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
}
