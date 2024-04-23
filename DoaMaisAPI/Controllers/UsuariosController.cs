using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DoaMaisAPI.DAO;
using DoaMaisAPI.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace DoaMaisAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {


        [HttpPost]
        [Route("cadastrar")]
        [AllowAnonymous]
        public IActionResult Cadastrar([FromBody] UsuarioDTO usuario)
        {
            var dao = new UsuarioDAO();

            bool usuarioExiste = dao.VerificarUsuario(usuario);
            if (usuarioExiste)
            {
                var mensagem = "E-mail já existe na base de dados";
                return Conflict(mensagem);
            }

            dao.Cadastrar(usuario);
            return Ok();
        }

        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]
        public IActionResult Login([FromForm] UsuarioDTO usuario)
        {
            var dao = new UsuarioDAO();
            var usuarioLogado = dao.Login(usuario);

            if (usuarioLogado.ID == 0)
            {
                return Unauthorized();
            }
            var token = GenerateJwtToken(usuarioLogado);

            return Ok(new { token });
        }


        [HttpGet]
        [Route("getuserdata")]
        public IActionResult GetUserData()
        {
            var dao = new UsuarioDAO();
            var id = int.Parse(HttpContext.User.FindFirst("id")?.Value);

            var usuario = dao.BuscarUsuarioPorID(id);

            return Ok(usuario);
        }

        private string GenerateJwtToken(UsuarioDTO usuario)
        {
            var secretKey = "PU8a9W4sv2opkqlOwmgsn3w3Innlc4D5";
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
                {
                    new Claim("ID", usuario.ID.ToString()),
                    new Claim("Email", usuario.Email),
                };

            var token = new JwtSecurityToken(
                "APIUsuarios", //Nome da sua api
                "APIUsuarios", //Nome da sua api
                claims, //Lista de claims
                expires: DateTime.UtcNow.AddDays(1), //Tempo de expiração do Token, nesse caso o Token expira em um dia
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}

       