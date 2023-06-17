
namespace Hotel.Entities;

public abstract class Human : Auditable
{
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string Address { get; set; } = string.Empty;

    public string PassportSeria { get; set; } = string.Empty;

    public string City { get; set; } = string.Empty;

    public string Country { get; set; } = string.Empty;

    public string PhoneNo { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Gender { get; set; } = string.Empty;

}
