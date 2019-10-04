using TroquelApi.Models;
using TroquelApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace TroquelApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JoyaController : ControllerBase
    {
        private readonly JoyaService _joyaService;

        public JoyaController(JoyaService joyaService)
        {
            _joyaService = joyaService;
        }

        [HttpGet]
        public ActionResult<List<Joya>> Get() =>
            _joyaService.Get();

        [HttpGet("{id:length(24)}", Name = "GetJoya")]
        public ActionResult<Joya> Get(string id)
        {
            var joya = _joyaService.Get(id);

            if (joya == null)
            {
                return NotFound();
            }

            return joya;
        }

        [HttpPost]
        public ActionResult<Joya> Create(Joya joya)
        {
            _joyaService.Create(joya);

            return CreatedAtRoute("GetJoya", new { id = joya.Id.ToString() }, joya);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Joya joyaIn)
        {
            var joya = _joyaService.Get(id);

            if (joya == null)
            {
                return NotFound();
            }

            _joyaService.Update(id, joyaIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var joya = _joyaService.Get(id);

            if (joya == null)
            {
                return NotFound();
            }

            _joyaService.Remove(joya.Id);
             
            return NoContent();
        }


    }
}
