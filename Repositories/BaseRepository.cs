
using Hotel.Constants;
using Npgsql;

namespace EduCenter.Desktop.Repositories;

public abstract class BaseRepository
{
    protected readonly NpgsqlConnection _connection;

    public BaseRepository()
    {
        _connection = new NpgsqlConnection(DbConstats.DB_CONNECTIONSTRING);
    }
}
