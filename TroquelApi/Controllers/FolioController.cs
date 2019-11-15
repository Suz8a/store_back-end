using TroquelApi.Models;
using TroquelApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace TroquelApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class FolioController : ControllerBase
    {
        private readonly FolioService _folioService;

        public FolioController(FolioService folioService)
        {
            _folioService = folioService;
        }

        [HttpGet]
        public ActionResult<List<Folio>> Get() =>
            _folioService.Get();

    }
}
