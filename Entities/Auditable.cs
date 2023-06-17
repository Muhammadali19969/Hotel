
using Hotel.Helpers;
using System;

namespace Hotel.Entities;

public abstract class Auditable:BaseEntity
{
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public Auditable()
    {
        CreatedAt = TimeHalper.GetDateTime();
        UpdatedAt = TimeHalper.GetDateTime();
    }
}
