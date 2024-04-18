using DoaMaisAPI.DTO;
using MySql.Data.MySqlClient;

namespace DoaMaisAPI.DAO
{
    public class ExpiradosPanelDAO
    {
        public List<ExpiradosPanelDTO> ListarExpiradosPanelDAO()
        {
            var conexao = ConnectionFactory.Build();
            conexao.Open();

            var query = "SELECT*FROM ExpiradosPanel";

            var comando = new MySqlCommand(query, conexao);
            var dataReader = comando.ExecuteReader();

            var usuarios = new List<ExpiradosPanelDTO>();

            while (dataReader.Read())
            {
                var usuario = new ExpiradosPanelDTO();
                usuario.ID = int.Parse(dataReader["ID"].ToString());
                usuario.Nome = dataReader["Nome"].ToString();
                usuario.Telefone = dataReader["Telefone"].ToString();
                usuario.Descricao = dataReader["Descricao"].ToString();
                usuario.Quantidade = int.Parse(dataReader["ID"].ToString());

                usuarios.Add(usuario);
            }
            conexao.Close();

            return usuarios;
        }
    }
}
