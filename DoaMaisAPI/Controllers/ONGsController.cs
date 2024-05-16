using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DoaMaisAPI.Azure;
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

        //[HttpPost]
        //public IActionResult Cadastrar([FromBody] ONGDTO ong)
        //{
        //    var dao = new ONGDAO();


        //    bool OngExiste = dao.VerificarONG(ong);
        //    if (OngExiste)
        //    {
        //        var mensagem = "E-mail já existe na base de dados";
        //        return Conflict(mensagem);
        //    }

        //    if (ong.Base64 is not null)
        //    {
        //        var azureBlobStorage = new AzureBlobStorage();
        //        ong.FotoPerfil = azureBlobStorage.UploadImage(ong.Base64);
        //    }

        //    dao.Cadastrar(ong);
        //    return Ok();
        //}

        //[HttpPost]
        //public IActionResult ListarInfoONGs()
        //{
        //    var dao = new ONGDAO();
        //    var ong = dao.ListarInfoONGs();

        //    return Ok(ong);
        //}


        [HttpGet]
        [Route("listarPorID")]
        [Authorize]
        public IActionResult ListarOngsPorID()
        {
            //Pegando ID do token
            int id = int.Parse(HttpContext.User.FindFirst("id")?.Value);

            var dao = new ONGDAO();
            var ong = dao.ListarOngsPorID(id);

            return Ok(ong);

        }

        [HttpGet]
        [Route("listarONGs")]

        public IActionResult ListarInfoONGs()
        {
            var dao = new ONGDAO();
            var ONGs = dao.ListarInfoONGs();

            return Ok(ONGs);
        }

    }
}
