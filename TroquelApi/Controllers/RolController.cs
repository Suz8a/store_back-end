using TroquelApi.Models;
using TroquelApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace TroquelApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private readonly RolService _rolService;

        public RolController(RolService rolService)
        {
            _rolService = rolService;
        }

        [HttpGet]
        public ActionResult<List<Rol>> Get() =>
            _rolService.Get();

        [HttpGet("{id:length(24)}", Name = "GetRol")]
        public ActionResult<Rol> Get(string id)
        {
            var rol = _rolService.Get(id);

            if (rol == null)
            {
                return NotFound();
            }

            return rol;
        }

        [HttpPost]
        public ActionResult<Rol> Create(Rol rol)
        {
            _rolService.Create(rol);

            return CreatedAtRoute("GetRol", new { id = rol.Id.ToString() }, rol);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Rol rolIn)
        {
            var rol = _rolService.Get(id);

            if (rol == null)
            {
                return NotFound();
            }

            _rolService.Update(id, rolIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var rol = _rolService.Get(id);

            if (rol == null)
            {
                return NotFound();
            }

            _rolService.Remove(rol.Id);

            return NoContent();
        }


    }
}
