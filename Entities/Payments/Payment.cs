using Hotel.Enums.PaymentType;

namespace Hotel.Entities.Payments;

public sealed class Payment:Auditable
{
    public long BookingId { get; set; }
    public long GuestId { get; set; }

    public float Paymentt { get; set; }

    public int MyProperty { get; set; }

    public PaymentType Type { get; set; }

}
