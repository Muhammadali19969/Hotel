using System;

namespace Hotel.ViewModels.Bookings;

public class BookingView
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string PassportSeria { get; set; } = string.Empty;
    public string PhoneNum { get; set; } = string.Empty;
    public float Payme { get; set; }
    public short RoomNo { get; set; }
    public long Id { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool IsBooking { get; set; }
    public string Status { get; set; }
    public long GuestId { get; set; }
    public string RoomType { get; set; }
}
