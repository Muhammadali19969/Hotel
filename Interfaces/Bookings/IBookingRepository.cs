using Hotel.Entities.Bookings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Hotel.Interfaces.Bookings
{
    public interface IBookingRepository: IRepository<Booking,Booking>
    {
        public Task<Booking> GetBookingAsync();
    }
}
