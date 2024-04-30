using DoaMaisAPI.DAO;
using DoaMaisAPI.DTO;
using Microsoft.AspNetCore.Mvc;

namespace DoaMaisAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosDoacaoController : ControllerBase
    {
        [HttpPost]
        public IActionResult CadastrarPedidos(PedidoDoacaoDTO Pedidos)
        {
            var dao = new PedidosDoacoesDAO();
            dao.CadastrarPedidos(Pedidos);

            return Ok();
        }

        [HttpGet]
        public IActionResult ListarPedidosDoacao()
        {
            var dao = new PedidosDoacoesDAO();
            var ONG = dao.ListarPedidosDoacao();

            return Ok(ONG);
        }
    }
}
