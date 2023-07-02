
using Hotel.Entities.Rooms;
using Hotel.ViewModels.Rooms;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hotel.Interfaces.Rooms
{
    public interface IRoomRepository : IRepository<Room, Room>
    {
        public Task<int> GetIdAsync(long id);
        public Task<int> UpdateStatus(string status, long id);

        public Task<int> UpdatePrice(long id, float price);

        public Task<List<Room>> GetRoomStatus(string status);
    }   
}
