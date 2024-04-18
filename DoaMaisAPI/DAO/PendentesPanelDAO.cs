using DoaMaisAPI.DTO;
using MySql.Data.MySqlClient;

namespace DoaMaisAPI.DAO
{
    public class PendentesPanelDAO
    {
        public List<PendentesPanelDTO> ListarPendentesPanel()
        {
            var conexao = ConnectionFactory.Build();
            conexao.Open();

            var query = "SELECT*FROM PendentesPanel";

            var comando = new MySqlCommand(query, conexao);
            var dataReader = comando.ExecuteReader();

            var usuarios = new List<PendentesPanelDTO>();

            while (dataReader.Read())
            {
                var usuario = new PendentesPanelDTO();
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
