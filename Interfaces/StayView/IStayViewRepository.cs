using Hotel.Entities.Rooms;
using Hotel.ViewModels.Bookings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Interfaces.StayView
{
    interface IStayViewRepository:IRepository<Room,BookingView>
    {
        public void Add(Room room);
        public Task<int> SetGuest(long id);
    }
}
