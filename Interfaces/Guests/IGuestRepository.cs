using Hotel.Entities.Guests;
using Hotel.Utils;
using Hotel.ViewModels.Guest;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hotel.Interfaces.Guests;

public interface IGuestRepository : IRepository<Guest,GuestViewModel>
{
    public Task<Guest> GetByGuest(long id);
    public Task<IList<Guest>> GetAllOnlyGuest(PagenationParams pagenationParams);

    public Task<int> SetBlackListAsync(long id, bool blackList);

    public Task<IList<Guest>> GetBlackList(PagenationParams pagenationParams);
}
