using DoaMaisAPI.Azure;
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
            //CadastrarUrls de imgs

            var azureBlobStorag = new AzureBlobStorage();

            foreach (var imagem in Pedidos.ImagensPedido)
            {
                var linkDaImagem = azureBlobStorag.UploadImage(imagem.Link);
                imagem.Link = linkDaImagem;
            }

            var statusPendente = new PedidoDoacaoDTO();
            //statusPendente.ID = 1; // Tive que alterar por que a minha variavel status é bool

            Pedidos.Status = true;

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
