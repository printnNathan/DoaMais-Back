using DoaMaisAPI.DTO;
using Microsoft.IdentityModel.Tokens;
using MySql.Data.MySqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DoaMaisAPI.DAO
{
    public class ONGDAO
    {
        internal void Cadastrar(ONGDTO ong)
        {
            var conexao = ConnectionFactory.Build();
            conexao.Open();

            var query = @"INSERT INTO ONGs (Email, Senha) 
                        VALUES (@email, @senha)";

            var comando = new MySqlCommand(query, conexao);
            comando.Parameters.AddWithValue("@email", ong.Email);
            comando.Parameters.AddWithValue("@senha", ong.Senha);

            comando.ExecuteNonQuery();
            conexao.Close();
        }

        public List<ONGDTO> ListarInfoONGs()
        {
            var conexao = ConnectionFactory.Build();
            conexao.Open();

            var query = "SELECT*FROM ONGs";

            var comando = new MySqlCommand(query, conexao);
            var dataReader = comando.ExecuteReader();

            var comandos = new List<ONGDTO>();

            while (dataReader.Read())
            {
                var ONG = new ONGDTO();
                ONG.ID = int.Parse(dataReader["ID"].ToString());
                ONG.Celular = dataReader["Celular"].ToString();
                ONG.Email = dataReader["Email"].ToString();
                ONG.Cep = dataReader["Cep"].ToString();
                ONG.Logradouro = dataReader["Logradouro"].ToString();
                ONG.Numero = dataReader["Numero"].ToString();
                ONG.Cidade = dataReader["Cidade"].ToString();
                ONG.Bairro = dataReader["Bairro"].ToString();
                ONG.Complemento = dataReader["Complemento"].ToString();
                ONG.FotoPerfil = dataReader["FotoPerfil"].ToString();
                ONG.Biografia = dataReader["Biografia"].ToString();

                comandos.Add(ONG);
            }
            conexao.Close();

            return comandos;
        }


        public bool VerificarONG(ONGDTO ong)
        {
            var conexao = ConnectionFactory.Build();
            conexao.Open();

            var query = "SELECT * FROM ONGs WHERE email = @email";

            var comando = new MySqlCommand(query, conexao);
            comando.Parameters.AddWithValue("@email", ong.Email);

            var dataReader = comando.ExecuteReader();

            var ongs = new List<ONGDTO>();

            while (dataReader.Read())
            {
                ong = new ONGDTO();
                ong.ID = int.Parse(dataReader["ID"].ToString());
                ong.Email = dataReader["Email"].ToString();
                ong.Senha = dataReader["Senha"].ToString();

                ongs.Add(ong);
            }
            conexao.Close();

            return ongs.Count > 0;
        }

        public ONGDTO Login(ONGDTO ong)
        {
            var conexao = ConnectionFactory.Build();
            conexao.Open();

            var query = "SELECT * FROM ONGs WHERE email = @email and senha = @senha";

            var comando = new MySqlCommand(query, conexao);
            comando.Parameters.AddWithValue("@email", ong.Email);
            comando.Parameters.AddWithValue("@senha", ong.Senha);

            var dataReader = comando.ExecuteReader();

            ong = new ONGDTO();

            while (dataReader.Read())
            {
                ong.ID = int.Parse(dataReader["ID"].ToString());
                ong.Email = dataReader["Email"].ToString();
                ong.Senha = dataReader["Senha"].ToString();
            }
            conexao.Close();

            return ong;
        }
       

    }
}   
               