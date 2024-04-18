using DoaMaisAPI.DTO;
using MySql.Data.MySqlClient;

namespace DoaMaisAPI.DAO
{
    public class PublicadosPanelDAO
    {
        public List<PublicadosPanelDTO> ListarPublicadosPanel()
        {
            var conexao = ConnectionFactory.Build();
            conexao.Open();

            var query = "SELECT*FROM PublicadosPanel";

            var comando = new MySqlCommand(query, conexao);
            var dataReader = comando.ExecuteReader();

            var usuarios = new List<PublicadosPanelDTO>();

            while (dataReader.Read())
            {
                var usuario = new PublicadosPanelDTO();
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
