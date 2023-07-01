using EduCenter.Desktop.Repositories;
using Hotel.Entities.Rooms;
using Hotel.Interfaces.StayView;
using Hotel.Utils;
using Hotel.ViewModels.Bookings;
using Npgsql;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hotel.Repositories.StayViewRepository;

public class StayViewRepository : BaseRepository, IStayViewRepository
{
    public void Add(Room room)
    {
        throw new System.NotImplementedException();
    }

    public Task<int> CreateAsync(Room obj)
    {
        throw new System.NotImplementedException();
    }

    public async Task<int> DeleteAsync(long id)
    {
        try
        {
            var list = new List<Room>();
            await _connection.OpenAsync();
            string query = $"UPDATE rooms SET room_status='Void' WHERE id={id};";
            await using (var command = new NpgsqlCommand(query, _connection))
            {

                var result = command.ExecuteNonQuery();
                return result;
            }

        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<IList<BookingView>> GetAllAsync(PagenationParams @params)
    {
        try
        {
            var list = new List<BookingView>();
            await _connection.OpenAsync();
            string query = $"select * from booking_view where is_booking='true' order by id offset {(@params.PageNumber - 1) * @params.PageSize} limit {@params.PageSize}";
            await using (var command = new NpgsqlCommand(query, _connection))
            {
                await using (var reader = await command.ExecuteReaderAsync())
                {
                    
                    while(await reader.ReadAsync())
                    {
                        var booking = new BookingView();

                        booking.FirstName=reader.GetString(0);
                        booking.LastName=reader.GetString(1);
                        booking.Address=reader.GetString(2);
                        booking.PassportSeria=reader.GetString(3);
                        booking.PhoneNum=reader.GetString(4);
                        booking.Payme=reader.GetFloat(5);
                        booking.RoomNo = reader.GetInt16(6);
                        booking.Id=reader.GetInt64(7);
                        booking.StartDate=reader.GetDateTime(8);
                        booking.EndDate=reader.GetDateTime(9);
                        booking.IsBooking=reader.GetBoolean(10);
                        booking.Status=reader.GetString(11);
                        booking.GuestId=reader.GetInt64(12);
                        booking.RoomType=reader.GetString(13);
                        list.Add(booking);
                    }

                    
                }
            }
            return list;
        }
        catch
        {
            return new List<BookingView>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public Task<IList<BookingView>> GetAllAsync(long id)
    {
        throw new System.NotImplementedException();
    }

    public async Task<int> SetGuest(long guestId)
    {
        try
        {
            var list = new List<Room>();
            await _connection.OpenAsync();
            string query = $"UPDATE guests SET is_booking='false' WHERE id={guestId};";
            await using (var command = new NpgsqlCommand(query, _connection))
            {

                var result = command.ExecuteNonQuery();
                return result;
            }

        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public Task<int> UpdateAsync(long id, Room obj)
    {
        throw new System.NotImplementedException();
    }
}
