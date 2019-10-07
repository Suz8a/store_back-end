using TroquelApi.Models;
using TroquelApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace TroquelApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReporteController : ControllerBase
    {
        private readonly ReporteService _reporteService;

        public ReporteController(ReporteService reporteService)
        {
            _reporteService = reporteService;
        }

        [HttpGet]
        public ActionResult<List<Reporte>> Get() =>
            _reporteService.Get();

        [HttpGet("{id:length(24)}", Name = "GetReporte")]
        public ActionResult<Reporte> Get(string id)
        {
            var reporte = _reporteService.Get(id);

            if (reporte == null)
            {
                return NotFound();
            }

            return reporte;
        }

        [HttpPost]
        public ActionResult<Reporte> Create(Reporte reporte)
        {
            _reporteService.Create(reporte);

            return CreatedAtRoute("GetReporte", new { id = reporte.Id.ToString() }, reporte);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Reporte reporteIn)
        {
            var reporte = _reporteService.Get(id);

            if (reporte == null)
            {
                return NotFound();
            }

            _reporteService.Update(id, reporteIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var reporte = _reporteService.Get(id);

            if (reporte == null)
            {
                return NotFound();
            }

            _reporteService.Remove(reporte.Id);

            return NoContent();
        }


    }
}
