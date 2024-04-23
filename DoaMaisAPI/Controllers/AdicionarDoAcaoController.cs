using DoaMaisAPI.DAO;
using DoaMaisAPI.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoaMaisAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdicionarDoAcaoController : ControllerBase
    {
        [HttpPost]
        [Route("CadastrarDoAcao")]
        public IActionResult CadastrarDoAcao([FromBody] DoAcaoDTO doacao)
        {

            var dao = new DoAcaoDAO();
            dao.CadastrarDoAcao(doacao);

            return Ok();
        }

        [HttpGet]
        [Route("ListarRequisicoesDeDoAcoes")]
        public IActionResult ListarRequisicoesDeDoacoes()
        {
            var dao = new DoAcaoDAO();
            var doacoes = dao.ListarRequisicoesDeDoacoes();
            return Ok(doacoes);
        }


    }
}
