using DoaMaisAPI.Controllers;
using DoaMaisAPI.DTO;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

namespace DoaMaisAPI.DAO
{
    public class PedidosDoacoesDAO
    {
        public void CadastrarPedidos(PedidoDoacaoDTO Pedidos)
        {
            var conexao = ConnectionFactory.Build();
            conexao.Open();

            var query = @"INSERT INTO PedidosDoacao (Titulo, ID_Tipo, Descricao, ID_ONG, Status, Ativo) 
                 VALUES (@titulo, @id_tipo, @descricao, @id_ong, @status, @ativo);
                 SELECT LAST_INSERT_ID();
                 ";

            var comando = new MySqlCommand(query, conexao);
            comando.Parameters.AddWithValue("@titulo", Pedidos.Titulo);
            comando.Parameters.AddWithValue("@id_tipo", Pedidos.ID_Tipo);
            comando.Parameters.AddWithValue("@descricao", Pedidos.Descricao);
            comando.Parameters.AddWithValue("@id_ong", Pedidos.ID_ONG);
            comando.Parameters.AddWithValue("@status", Pedidos.Status);
            comando.Parameters.AddWithValue("@ativo", true);

            var idPedido = Convert.ToInt32(comando.ExecuteScalar());
            conexao.Close();

            CadastrarImagensPedido(idPedido, Pedidos.ImagensPedido);
        }


        public List<PedidoDoacaoDTO> ListarPedidosDoacao()
        {
            var conexao = ConnectionFactory.Build();
            conexao.Open();

            var query = "SELECT * FROM PedidosDoacao WHERE Ativo = 1";

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

                // Listar imagens para este pedido
                pedido.ImagensPedido = ListarImagensPedido(pedido.ID);

                pedidos.Add(pedido);
            }

            conexao.Close();

            return pedidos;
        }
        public void InativarPedidoDoacao(int idPedido)
        {
            var conexao = ConnectionFactory.Build();
            conexao.Open();

            var query = "UPDATE PedidosDoacao SET Ativo = 0 WHERE ID = @idPedido";
            var comando = new MySqlCommand(query, conexao);
            comando.Parameters.AddWithValue("@idPedido", idPedido);

            comando.ExecuteNonQuery();
            conexao.Close();
        }
        public void ReativarPedidoDoacao(int idPedido)
        {
            var conexao = ConnectionFactory.Build();
            conexao.Open();

            var query = "UPDATE PedidosDoacao SET Ativo = 1 WHERE ID = @idPedido";
            var comando = new MySqlCommand(query, conexao);
            comando.Parameters.AddWithValue("@idPedido", idPedido);

            comando.ExecuteNonQuery();
            conexao.Close();
        }

        private List<ImagemPedidoDoacaoDTO> ListarImagensPedido(int idPedido)
        {
            var conexao = ConnectionFactory.Build();
            conexao.Open();

            var imagens = new List<ImagemPedidoDoacaoDTO>();

            var query = "SELECT Link FROM ImagensPedidoDoacao WHERE ID_PedidoDoacao = @idPedido";
            var comando = new MySqlCommand(query, conexao);
            comando.Parameters.AddWithValue("@idPedido", idPedido);
            var dataReader = comando.ExecuteReader();

            while (dataReader.Read())
            {
                var imagem = new ImagemPedidoDoacaoDTO();
                imagem.Link = dataReader["Link"].ToString();
                imagens.Add(imagem);    
            }

            conexao.Close();

            return imagens;
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


        public PedidoDoacaoDTO ListarRequisicaoPorID(int id)
        {
            var conexao = ConnectionFactory.Build();
            conexao.Open();

            var query = "SELECT*FROM pedidosdoacao Where ID =@id";

            var comando = new MySqlCommand(query, conexao);
            comando.Parameters.AddWithValue("@id", id);

            var dataReader = comando.ExecuteReader();

            var ong = new PedidoDoacaoDTO();

            while (dataReader.Read())
            {
                ong.ID = int.Parse(dataReader["ID"].ToString());
                ong.Titulo = dataReader["Titulo"].ToString();
                ong.ID_Tipo = int.Parse(dataReader["ID_Tipo"].ToString());
                ong.Descricao = dataReader["Descricao"].ToString();
                ong.ID_ONG = int.Parse(dataReader["ID_ONG"].ToString());
                ong.Status = Convert.ToInt32(dataReader["Status"]) == 1;

                //if (dataReader["ImagensPedido"] != DBNull.Value)
                //{
                //    var imagensJson = dataReader["ImagensPedido"].ToString();
                //    ong.ImagensPedido = JsonConvert.DeserializeObject<List<ImagemPedidoDoacaoDTO>>(imagensJson);
                //}
                //else
                //{
                //    ong.ImagensPedido = new List<ImagemPedidoDoacaoDTO>();
                //}

            }
            conexao.Close();

            return ong;
        }
    }
}
