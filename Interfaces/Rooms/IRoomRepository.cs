
using Hotel.Entities.Rooms;
using Hotel.ViewModels.Rooms;
using System.Threading.Tasks;

namespace Hotel.Interfaces.Rooms
{
    public interface IRoomRepository : IRepository<Room, RoomViewModel>
    {
        public Task<int> GetIdAsync(long id);
    }   
}
