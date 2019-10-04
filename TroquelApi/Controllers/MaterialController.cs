using TroquelApi.Models;
using TroquelApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace TroquelApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialController : ControllerBase
    {
        private readonly MaterialService _materialService;

        public MaterialController(MaterialService materialService)
        {
            _materialService = materialService;
        }

        [HttpGet]
        public ActionResult<List<Material>> Get() =>
            _materialService.Get();

        [HttpGet("{id:length(24)}", Name = "GetMaterial")]
        public ActionResult<Material> Get(string id)
        {
            var material = _materialService.Get(id);

            if (material == null)
            {
                return NotFound();
            }

            return material;
        }

        [HttpPost]
        public ActionResult<Material> Create(Material material)
        {
            _materialService.Create(material);

            return CreatedAtRoute("GetMaterial", new { id = material.Id.ToString() }, material);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Material materialIn)
        {
            var material = _materialService.Get(id);

            if (material == null)
            {
                return NotFound();
            }

            _materialService.Update(id, materialIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var material = _materialService.Get(id);

            if (material == null)
            {
                return NotFound();
            }

            _materialService.Remove(material.Id);

            return NoContent();
        }


    }
}
