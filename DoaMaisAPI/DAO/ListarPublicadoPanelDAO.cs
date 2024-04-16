using DoaMaisAPI.DTO;
using MySql.Data.MySqlClient;

namespace DoaMaisAPI.DAO
{
    public class ListarPublicadoPanelDAO
    {
        public List<PublicadosPanelDTO> ListarPublicadosPanel()
        {
            var conexao = ConnectionFactory.Build();
            conexao.Open();

            var query = "SELECT*FROM PublicadosPanel";

            var comando = new MySqlCommand(query, conexao);
            var dataReader = comando.ExecuteReader();

            var usuario = new List<PublicadosPanelDTO>();

            while (dataReader.Read())
            {
                var usuarios = new PublicadosPanelDTO();
                usuarios.ID = int.Parse(dataReader["ID"].ToString());
                usuarios.Nome = dataReader["Nome"].ToString();
                usuarios.Email = dataReader["Email"].ToString();
                usuarios.Telefone = dataReader["Telefone"].ToString();
                usuarios.Descricao = dataReader["Descricao"].ToString();
                usuarios.Quantidade = int.Parse(dataReader["ID"].ToString());
                usuarios.Status = dataReader["Status"].ToString();

                usuario.Add(usuarios);
            }
            conexao.Close();

            return usuario;
        }
    }
}
