using EduCenter.Desktop.Repositories;
using Hotel.Entities.Rooms;
using Hotel.Interfaces;
using Hotel.Interfaces.Rooms;
using Hotel.Utils;
using Hotel.ViewModels.Rooms;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Windows;

namespace Hotel.Repositories.Rooms;

public class RoomRepository : BaseRepository, IRoomRepository
{
    public async Task<int> CreateAsync(Room obj)
    {
        
        try
        {
            await _connection.OpenAsync();
            string query = "INSERT INTO public.rooms(floor, room_no, price_per_day,description, created_at, updated_at, room_type)" +
                "VALUES (@floor,@room_no, @price_per_day, @description, @created_at, @updated_at, @room_type);";
            await using(var command=new NpgsqlCommand(query,_connection))
            {
                command.Parameters.AddWithValue("floor", obj.Floor);
                command.Parameters.AddWithValue("room_no", obj.RoomNo);
                command.Parameters.AddWithValue("price_per_day", obj.PricePerDay);
                command.Parameters.AddWithValue("description", obj.Description);
                command.Parameters.AddWithValue("created_at", obj.CreatedAt);
                command.Parameters.AddWithValue("updated_at", obj.UpdatedAt);
                command.Parameters.AddWithValue("room_type", obj.RoomType);

                var result = await command.ExecuteNonQueryAsync();
                return result;  
            }
            
        }
        catch(Exception ex) 
        {
            MessageBox.Show(ex.Message);
            return 0;
        }
        finally
        {
            await _connection.CloseAsync(); 
        }
    }

    








    public Task<int> DeleteAsync(long id)
    {
        throw new System.NotImplementedException();
    }

    public Task<IList<RoomViewModel>> GetAllAsync(PagenationParams @params)
    {
        throw new System.NotImplementedException();
    }

    public Task<IList<RoomViewModel>> GetAllAsync(long id)
    {
        throw new System.NotImplementedException();
    }

    public Task<int> GetIdAsync(long id)
    {
        throw new System.NotImplementedException();
    }

    public Task<int> UpdateAsync(long id, Room obj)
    {
        throw new System.NotImplementedException();
    }
}
