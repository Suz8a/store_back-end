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

        public PedidoController(PedidoService pedidoService, ContrasenaGen contrasenaGen)
        {
            _pedidoService = pedidoService;
            _contrasenaGen = contrasenaGen;
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

        [HttpPost]
        public ActionResult<Pedido> Create(Pedido pedido)
        {
            var contrasena = _contrasenaGen.GenerateRandomContrasena().ToString();
            pedido.contrasena = contrasena;
            _pedidoService.Create(pedido);

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


    }
}
