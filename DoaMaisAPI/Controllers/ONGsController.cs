using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DoaMaisAPI.Azure;
using DoaMaisAPI.DAO;
using DoaMaisAPI.DTO;
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

        [HttpGet]
        public IActionResult ListarInfoONGs()
        {
            var dao = new ONGDAO();
            var ong = dao.ListarInfoONGs();

            return Ok(ong);
        }


        [HttpGet]
        [Route("listarPorID")] 
        public IActionResult ListarOngsPorID(int id)
        {
            var dao = new ONGDAO();
            var ong = dao.ListarOngsPorID(id);

            return Ok(ong);

        }

    }
}
