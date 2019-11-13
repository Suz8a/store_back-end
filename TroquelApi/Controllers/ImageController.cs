using System;
using TroquelApi.Models;
using TroquelApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace TroquelApi.Controllers
{
    public class ImageController : ControllerBase
    {
        ImageService imageService = new ImageService();

        // GET: Image
        public ActionResult Upload()
        {
            return View();
        }
    }
}
