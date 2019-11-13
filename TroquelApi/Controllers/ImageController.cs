using System;
using TroquelApi.Models;
using TroquelApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace TroquelApi.Controllers
{
    public class ImageController : Controller
    {
        private readonly ImageService _imageService;


        public ImageController(ImageService imageService)
        {
            _imageService = imageService;
        }

        // GET: Image
        public ActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Upload(IFormFile photo)
        {
            var imageUrl = await _imageService.UploadImageAsync(photo);
            TempData["LatestImage"] = imageUrl.ToString();
            return RedirectToAction("LatestImage");
        }

        public ActionResult LatestImage()
        {
            var latestImage = string.Empty;
            if (TempData["LatestImage"] != null)
            {
                ViewBag.LatestImage = Convert.ToString(TempData["LatestImage"]);
            }

            return View();
        }

    }
}
