using DoaMaisAPI.DTO;
using MySql.Data.MySqlClient;

namespace DoaMaisAPI.DAO
{
    public class PedidosDoacoesDAO
    {
        internal int CadastrarPedidos(PedidoDoacaoDTO pedido)
        {
            var conexao = ConnectionFactory.Build();
            conexao.Open();

            var query = @"INSERT INTO PedidosDoacao (Titulo, ID_Tipo, Descricao, ID_ONG, Status) 
                      VALUES (@titulo, @id_tipo, @descricao, @id_ong, @status);
                      SELECT LAST_INSERT_ID();
                    ";

            var comando = new MySqlCommand(query, conexao);
            comando.Parameters.AddWithValue("@titulo", pedido.Titulo);
            comando.Parameters.AddWithValue("@id_tipo", pedido.ID_Tipo);
            comando.Parameters.AddWithValue("@descricao", pedido.Descricao);
            comando.Parameters.AddWithValue("@id_ong", pedido.ID_ONG);
            comando.Parameters.AddWithValue("@status", pedido.Status ? 1 : 1);

            // Executar a query e obter o ID inserido
            int pedidoID = Convert.ToInt32(comando.ExecuteScalar());

            conexao.Close();

            return pedidoID; // Retornar o ID do pedido inserido
        }

        public List<PedidoDoacaoDTO> ListarPedidosDoacao()
        {
            var conexao = ConnectionFactory.Build();
            conexao.Open();

            var query = "SELECT ID, Titulo, Descricao, ID_ONG, Status FROM PedidosDoacao";

            var comando = new MySqlCommand(query, conexao);
            var dataReader = comando.ExecuteReader();

            var pedidos = new List<PedidoDoacaoDTO>();

            while (dataReader.Read())
            {
                var pedido = new PedidoDoacaoDTO();
                pedido.ID = int.Parse(dataReader["ID"].ToString());
                pedido.Titulo = dataReader["Titulo"].ToString();
                pedido.Descricao = dataReader["Descricao"].ToString();
                pedido.ID_ONG = int.Parse(dataReader["ID_ONG"].ToString());
                pedido.Status = Convert.ToInt32(dataReader["Status"]) == 1;

                pedidos.Add(pedido);
            }
            conexao.Close();

            return pedidos;
        }
    }

}

