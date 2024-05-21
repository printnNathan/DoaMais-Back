using MySql.Data.MySqlClient;

namespace DoaMaisAPI.DAO
{
    public class ConnectionFactory
    {
        public static MySqlConnection Build()
        {
            var connectionString = "Server=ger-doacao-tcc.mysql.database.azure.com;Database=doaMais;Uid=doamais;Pwd=KAKAdt13%;";
            return new MySqlConnection(connectionString);
        }
    }
}
