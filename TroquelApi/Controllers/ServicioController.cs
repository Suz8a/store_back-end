using TroquelApi.Models;
using TroquelApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace TroquelApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicioController : ControllerBase
    {
        private readonly ServicioService _servicioService;

        public ServicioController(ServicioService servicioService)
        {
            _servicioService = servicioService;
        }

        [HttpGet]
        public ActionResult<List<Servicio>> Get() =>
            _servicioService.Get();

        [HttpGet("{id:length(24)}", Name = "GetServicio")]
        public ActionResult<Servicio> Get(string id)
        {
            var servicio = _servicioService.Get(id);

            if (servicio == null)
            {
                return NotFound();
            }

            return servicio;
        }

        [HttpPost]
        public ActionResult<Servicio> Create(Servicio servicio)
        {
            _servicioService.Create(servicio);

            return CreatedAtRoute("GetServicio", new { id = servicio.Id.ToString() }, servicio);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Servicio servicioIn)
        {
            var servicio = _servicioService.Get(id);

            if (servicio == null)
            {
                return NotFound();
            }

            _servicioService.Update(id, servicioIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var servicio = _servicioService.Get(id);

            if (servicio == null)
            {
                return NotFound();
            }

            _servicioService.Remove(servicio.Id);

            return NoContent();
        }


    }
}
