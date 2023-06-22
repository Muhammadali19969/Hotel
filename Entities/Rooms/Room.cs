
using System.Windows.Controls.Ribbon;

namespace Hotel.Entities.Rooms;

public sealed class Room: Auditable
{
    public short Floor { get; set; }

    public string RoomType{ get; set; }

    public short RoomNo { get; set; }

    // Room status

    public float PricePerDay { get; set; }

    public string Description { get; set; } = string.Empty;
}
