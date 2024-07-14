using System;
using System.Collections.Generic;

namespace DbConnection.db.Supercharge.Model;

public partial class Booking
{
    public int BookingId { get; set; }

    public int VisitorId { get; set; }

    public int RoomId { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedOnUtc { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedOnUtc { get; set; }

    public virtual User? CreatedByNavigation { get; set; }

    public virtual User? ModifiedByNavigation { get; set; }

    public virtual Room Room { get; set; } = null!;

    public virtual Visitor Visitor { get; set; } = null!;
}
