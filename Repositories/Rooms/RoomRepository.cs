using EduCenter.Desktop.Repositories;
using Hotel.Entities.Rooms;
using Hotel.Interfaces;
using Hotel.Interfaces.Rooms;
using Hotel.Utils;
using Hotel.ViewModels.Rooms;
using Npgsql;
using System;
using System.Collections.Generic;
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
            string query = "INSERT INTO public.rooms(floor, room_no,room_status, price_per_day,description, created_at, updated_at, room_type)" +
                "VALUES (@floor,@room_no,@room_status, @price_per_day, @description, @created_at, @updated_at, @room_type);";
            await using(var command=new NpgsqlCommand(query,_connection))
            {
                command.Parameters.AddWithValue("floor", obj.Floor);
                command.Parameters.AddWithValue("room_no", obj.RoomNo);
                command.Parameters.AddWithValue("room_status", "Void");
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

    public async Task<IList<Room>> GetAllAsync(PagenationParams @params)
    {
        try
        {
            var list = new List<Room>();
            await _connection.OpenAsync();
            string query = $"select * from rooms order by id offset {(@params.PageNumber-1)*@params.PageSize} limit {@params.PageSize}";
            await using (var command=new NpgsqlCommand(query,_connection))
            {
                await using(var reader= await command.ExecuteReaderAsync())
                {
                      while(await  reader.ReadAsync())
                    {
                        var room = new Room();
                        room.Id = reader.GetInt64(0);
                        room.Floor = reader.GetInt16(1);
                        room.RoomNo=reader.GetInt16(2);
                        room.Status=reader.GetString(3);
                        room.PricePerDay = reader.GetFloat(4);
                        room.Description= reader.GetString(5);
                        room.CreatedAt=reader.GetDateTime(6);
                        room.UpdatedAt=reader.GetDateTime(7);   
                        room.RoomType=reader.GetString(8);
                        list.Add(room);
                    }
                }
            }
            return list;
        }
        catch
        {
            return new List<Room>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
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

    public async Task<int> UpdateStatus(string status, long id)
    {
        try
        {
            var list = new List<Room>();
            await _connection.OpenAsync();
            string query = $"UPDATE public.rooms SET room_status= '{status}' WHERE id={id};";
            await using (var command = new NpgsqlCommand(query, _connection))
            {
                
                var result=command.ExecuteNonQuery();
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

    Task<IList<Room>> IRepository<Room, Room>.GetAllAsync(long id)
    {
        throw new NotImplementedException();
    }
}
