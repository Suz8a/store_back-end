using TroquelApi.Models;
using TroquelApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace TroquelApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoController : ControllerBase
    {
        private readonly EstadoService _estadoService;

        public EstadoController(EstadoService estadoService)
        {
            _estadoService = estadoService;
        }

        [HttpGet]
        public ActionResult<List<Estado>> Get() =>
            _estadoService.Get();

        [HttpGet("{id:length(24)}", Name = "GetEstado")]
        public ActionResult<Estado> Get(string id)
        {
            var estado = _estadoService.Get(id);

            if (estado == null)
            {
                return NotFound();
            }

            return estado;
        }

        [HttpPost]
        public ActionResult<Estado> Create(Estado estado)
        {
            _estadoService.Create(estado);

            return CreatedAtRoute("GetEstado", new { id = estado.Id.ToString() }, estado);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Estado estadoIn)
        {
            var estado = _estadoService.Get(id);

            if (estado == null)
            {
                return NotFound();
            }

            _estadoService.Update(id, estadoIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var estado = _estadoService.Get(id);

            if (estado == null)
            {
                return NotFound();
            }

            _estadoService.Remove(estado.Id);

            return NoContent();
        }


    }
}
