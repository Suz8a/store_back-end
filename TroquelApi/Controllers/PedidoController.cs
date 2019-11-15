using TroquelApi.Models;
using TroquelApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace TroquelApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly PedidoService _pedidoService;
        private readonly ContrasenaGen _contrasenaGen;
        private readonly FolioService _folioService;

        public PedidoController(PedidoService pedidoService, ContrasenaGen contrasenaGen, FolioService folioService)
        {
            _pedidoService = pedidoService;
            _contrasenaGen = contrasenaGen;
            _folioService = folioService;
        }

        [HttpGet]
        public ActionResult<List<Pedido>> Get() =>
            _pedidoService.Get();

        [HttpGet("{id:length(24)}", Name = "GetPedido")]
        public ActionResult<Pedido> Get(string id)
        {
            var pedido = _pedidoService.Get(id);

            if (pedido == null)
            {
                return NotFound();
            }

            return pedido;
        }

        [HttpGet("search")]
        public ActionResult<Pedido> GetByName([FromQuery(Name = "folio")] string folio)
        {

            if (_pedidoService.GetByFolio(folio) == null)
                return NotFound();

            return _pedidoService.GetByFolio(folio);
        }

        [HttpPost]
        public ActionResult<Pedido> Create(Pedido pedido)
        {
            var contrasena = _contrasenaGen.GenerateRandomContrasena().ToString();
            var folio = _contrasenaGen.GenerateRandomFolio().ToString();

            pedido.contrasena = contrasena;
            pedido.folio = folio;

            Folio newFolio = new Folio();
            newFolio.folio = folio;

            _pedidoService.Create(pedido);
            _folioService.Create(newFolio);

            return CreatedAtRoute("GetPedido", new { id = pedido.Id.ToString() }, pedido);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Pedido pedidoIn)
        {
            var pedido = _pedidoService.Get(id);

            if (pedido == null)
            {
                return NotFound();
            }

            _pedidoService.Update(id, pedidoIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var pedido = _pedidoService.Get(id);

            if (pedido == null)
            {
                return NotFound();
            }

            _pedidoService.Remove(pedido.Id);

            return NoContent();
        }

        // Authentication

        // [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]Pedido userParam)
        {
            var pedido = _pedidoService.Authenticate(userParam.folio, userParam.contrasena);

            if (pedido == null)
                return BadRequest(new { message = "folio or password is incorrect" });

            return Ok(pedido);
        }


    }
}
