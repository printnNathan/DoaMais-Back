using DoaMaisAPI.Controllers;
using DoaMaisAPI.DTO;
using MySql.Data.MySqlClient;

namespace DoaMaisAPI.DAO
{
    public class PedidosDoacoesDAO
    {
        internal void CadastrarPedidos(PedidoDoacaoDTO Pedidos)
        {
            var conexao = ConnectionFactory.Build();
            conexao.Open();

            var query = @"INSERT INTO PedidosDoacao (Titulo, ID_Tipo, Descricao, ID_ONG, Status) 
                         VALUES (@titulo, @id_tipo, @descricao, @id_ong, @status);
                        SELECT LAST_INSERT_ID();
                        ";

            var comando = new MySqlCommand(query, conexao);
            comando.Parameters.AddWithValue("@titulo", Pedidos.Titulo);
            comando.Parameters.AddWithValue("@id_tipo", Pedidos.ID_Tipo);
            comando.Parameters.AddWithValue("@descricao", Pedidos.Descricao);
            comando.Parameters.AddWithValue("@id_ong", Pedidos.ID_ONG);
            comando.Parameters.AddWithValue("@status", Pedidos.Status);

            var idPedido = Convert.ToInt32(comando.ExecuteScalar());
            conexao.Close();


            CadastrarImagensPedido(idPedido, Pedidos.ImagensPedido); //Pegar o id do pedido que eu inseri e passar ele para cá 
        }

        public List<PedidoDoacaoDTO> ListarPedidosDoacao()
        {
            var conexao = ConnectionFactory.Build();
            conexao.Open();

            var query = "SELECT*FROM PedidosDoacao";

            var comando = new MySqlCommand(query, conexao);
            var dataReader = comando.ExecuteReader();

            var comandos = new List<PedidoDoacaoDTO>();

            while (dataReader.Read())
            {
                var Pedidos = new PedidoDoacaoDTO();
                Pedidos.ID = int.Parse(dataReader["ID"].ToString());
                Pedidos.Titulo = dataReader["Titulo"].ToString();
                Pedidos.Descricao = dataReader["Descricao"].ToString();
                Pedidos.ID_ONG = int.Parse(dataReader["ID_ONG"].ToString());
                Pedidos.Status = Convert.ToInt32(dataReader["Status"]) == 1;

                comandos.Add(Pedidos);
            }
            conexao.Close();

            return comandos;
        }

        public void CadastrarImagensPedido(int idPedido, List<ImagemPedidoDoacaoDTO> imagens)
        {
            var conexao = ConnectionFactory.Build();
            conexao.Open();

            var query = @"INSERT INTO ImagensPedidoDoacao (Link, ID_PedidoDoacao) 
                         VALUES (@link, @pedido);";

            foreach (var imagem in imagens)
            {
                var comando = new MySqlCommand(query, conexao);
                comando.Parameters.AddWithValue("@link", imagem.Link); 
                comando.Parameters.AddWithValue("@pedido", idPedido);

                comando.ExecuteNonQuery();
            }
            conexao.Close();
        }
    }
}
