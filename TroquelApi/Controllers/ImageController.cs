using System;
using TroquelApi.Models;
using TroquelApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace TroquelApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly ImageService _imageService;


        public ImageController(ImageService imageService)
        {
            _imageService = imageService;
        }


        [HttpPost]
        public async Task<IActionResult> Upload([FromForm(Name = "photo")] IFormFile photo)
        {
            var imageUrl = await _imageService.UploadImageAsync(photo);
            return Ok(new { imageUrl = imageUrl });
        }



    }
}
