using Hotel.Entities.Guests;
using Hotel.ViewModels.Guest;
using System.Threading.Tasks;

namespace Hotel.Interfaces.Guests;

public interface IGuestRepository : IRepository<Guest,GuestViewModel>
{
    public Task<Guest> GetByGuest(long id);
}
