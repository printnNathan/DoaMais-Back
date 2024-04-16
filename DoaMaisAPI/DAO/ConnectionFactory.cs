using MySql.Data.MySqlClient;

namespace DoaMaisAPI.DAO
{
    public class ConnectionFactory
    {
        public static MySqlConnection Build()
        {
            var connectionString = "Server=localhost;Database=DoaMais;Uid=root;Pwd=root;";
            return new MySqlConnection(connectionString);
        }
    }
}
