using System.Reflection.PortableExecutable;

namespace Hotel.Entities;

public sealed class Staffs : Human
{
    public string Role { get; set; } = string.Empty;

    public string PasswordHash { get; set; } = string.Empty;

    public string Salt { get; set; } = string.Empty;

}