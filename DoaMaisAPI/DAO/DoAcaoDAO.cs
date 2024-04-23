using MySql.Data.MySqlClient;
using DoaMaisAPI.DTO;

namespace DoaMaisAPI.DAO
{
    public class DoAcaoDAO
    {
        public void CadastrarDoAcao(DoAcaoDTO doacao)
        {
            var conexao = ConnectionFactory.Build();
            conexao.Open();

            var query = @"INSERT INTO Doacao (Nome, Descricao, Usuario) VALUES
						(@nome,@descricao,@usuario);
                        SELECT LAST_INSERT_ID();";

            var comando = new MySqlCommand(query, conexao);
            comando.Parameters.AddWithValue("@nome", doacao.Nome);
            comando.Parameters.AddWithValue("@descricao", doacao.Descricao);
            comando.Parameters.AddWithValue("@usuario", doacao.Usuario);
            //  comando.Parameters.AddWithValue("@status", doacao.Status.ID);

            //   int idProdutoCadastrado = Convert.ToInt32(comando.ExecuteScalar());


            //foreach (var imagem in produto.Imagens)
            //{
            //    comando = new MySqlCommand(queryTurno, conexao);
            //    comando.Parameters.AddWithValue("@link", imagem.Link);
            //    comando.Parameters.AddWithValue("@produto", idProdutoCadastrado);

            //    comando.ExecuteNonQuery();
            //}

            conexao.Close();
        }

        public List<DoAcaoDTO> ListarRequisicoesDeDoacoes()
        {
            var conexao = ConnectionFactory.Build();
            conexao.Open();

            var query = "SELECT * FROM Doacao";

            var comando = new MySqlCommand(query, conexao);
            var dataReader = comando.ExecuteReader();

            var doacoes = new List<DoAcaoDTO>();

            while (dataReader.Read())
            {
                var doacao = new DoAcaoDTO();
                doacao.ID = int.Parse(dataReader["ID"].ToString());
                doacao.Nome = dataReader["Nome"].ToString();
                doacao.Descricao = dataReader["Descricao"].ToString();
                doacao.Usuario = dataReader["Usuario"].ToString();
                doacoes.Add(doacao);
            }
            conexao.Close();

            return doacoes;
        }


    }
    }

}
