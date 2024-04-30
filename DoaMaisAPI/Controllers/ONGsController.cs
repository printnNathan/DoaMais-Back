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
    public class ONGsController : ControllerBase
    {
        [HttpPost]
        public IActionResult Cadastrar([FromBody] ONGDTO ong)
        {
            var dao = new ONGDAO();
            dao.Cadastrar(ong);
            return Ok();
        }

        [HttpGet]
        public IActionResult ListarInfoONGs()
        {
            var dao = new ONGDAO();
            var ONG = dao.ListarInfoONGs();

            return Ok(ONG);
        }

    }
}
