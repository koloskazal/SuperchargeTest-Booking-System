using System;
using System.Collections.Generic;

namespace DbConnection.db.Supercharge.Model;

public partial class User
{
    public int UserId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public bool IsActive { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedOnUtc { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedOnUtc { get; set; }

    public virtual ICollection<Booking> BookingCreatedByNavigations { get; set; } = new List<Booking>();

    public virtual ICollection<Booking> BookingModifiedByNavigations { get; set; } = new List<Booking>();

    public virtual User? CreatedByNavigation { get; set; }

    public virtual ICollection<Hotel> HotelCreatedByNavigations { get; set; } = new List<Hotel>();

    public virtual ICollection<Hotel> HotelModifiedByNavigations { get; set; } = new List<Hotel>();

    public virtual ICollection<User> InverseCreatedByNavigation { get; set; } = new List<User>();

    public virtual ICollection<User> InverseModifiedByNavigation { get; set; } = new List<User>();

    public virtual User? ModifiedByNavigation { get; set; }

    public virtual ICollection<Price> PriceCreatedByNavigations { get; set; } = new List<Price>();

    public virtual ICollection<Price> PriceModifiedByNavigations { get; set; } = new List<Price>();

    public virtual ICollection<Room> RoomCreatedByNavigations { get; set; } = new List<Room>();

    public virtual ICollection<Room> RoomModifiedByNavigations { get; set; } = new List<Room>();

    public virtual ICollection<Visitor> VisitorCreatedByNavigations { get; set; } = new List<Visitor>();

    public virtual ICollection<Visitor> VisitorModifiedByNavigations { get; set; } = new List<Visitor>();
}
