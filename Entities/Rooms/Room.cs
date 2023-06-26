
using System.Windows.Controls.Ribbon;

namespace Hotel.Entities.Rooms;

public sealed class Room: Auditable
{
    public short Floor { get; set; }

    public string RoomType { get; set; } = string.Empty;

    public short RoomNo { get; set; }

    public string Status { get; set; } = string.Empty;

    public float PricePerDay { get; set; }

    public string Description { get; set; } = string.Empty;
}
