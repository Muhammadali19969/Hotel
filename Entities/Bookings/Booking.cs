
using Hotel.Enums.BookingStatus;
using System;
using System.Security.Permissions;

namespace Hotel.Entities.Bookings;

public sealed class Booking : Auditable
{
    public long GuestId { get; set; }
    public long RoomId { get; set; }

    public DateOnly DateFrom { get; set; }

    public DateOnly DateTo { get; set; }

    public short Night { get; set; }

    public BookingStatus Status { get; set; }

    public string Description { get; set; } = string.Empty;
}
