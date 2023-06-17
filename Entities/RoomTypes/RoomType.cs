
using System.Security.Permissions;

namespace Hotel.Entities.RoomTypes;

public class RoomType:BaseEntity
{
    public string RoomTypes { get; set; }

    public string Description { get; set; } = string.Empty;
}
