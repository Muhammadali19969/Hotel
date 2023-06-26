
using System;

namespace Hotel.Entities.Guests;

public sealed class Guest : Human
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public long RoomId { get; set; }
    public bool IsBooking { get; set; }
    public float Payme { get; set; }

}
