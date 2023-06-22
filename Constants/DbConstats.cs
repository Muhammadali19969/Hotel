

namespace Hotel.Constants;

public class DbConstats
{
    public const string DB_HOST = "localhost";
    public const string DB_PORT = "5432";
    public const string DB_DATABASE = "hotel-db";
    public const string DB_USER = "postgres";
    public const string DB_PASSWORD = "19969";

    public const string DB_CONNECTIONSTRING =
        $"Host={DB_HOST};" +
        $"Port={DB_PORT};" +
        $"Database={DB_DATABASE};" +
        $"User Id={DB_USER};" +
        $"Password={DB_PASSWORD};";

}
