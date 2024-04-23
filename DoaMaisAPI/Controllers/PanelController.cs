using DoaMaisAPI.DAO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoaMaisAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PanelController : ControllerBase
    {
        [HttpGet]
        [Route("listar")]
        public IActionResult Listar()
        {
            var dao = new UsuarioDAO();
            var usuarios = dao.ListarUsuarios();
            return Ok(usuarios);
        }

        [HttpGet]
        [Route("listarprodutospanel")]
        public IActionResult ListarProdutosPanel()
        {
            var dao = new PublicadosPanelDAO();
            var usuarios = dao.ListarPublicadosPanel();
            return Ok(usuarios);
        }

        [HttpGet]
        [Route("listarexpiradospanel")]
        public IActionResult ListarExpiradosPanelDAO()
        {
            var dao = new ExpiradosPanelDAO();
            var usuarios = dao.ListarExpiradosPanelDAO();
            return Ok(usuarios);
        }

        [HttpGet]
        [Route("listarinativosPanel")]
        public IActionResult ListarInativosPanelDAO()
        {
            var dao = new InativosPanelDAO();
            var usuarios = dao.ListarInativosPanelDAO();
            return Ok(usuarios);
        }

        [HttpGet]
        [Route("listarprodutospendentes")]
        public IActionResult ListarPendentesPanel()
        {
            var dao = new PendentesPanelDAO();
            var usuarios = dao.ListarPendentesPanel();
            return Ok(usuarios);
        }

    }
}
