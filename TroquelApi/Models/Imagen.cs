using System;
using Microsoft.AspNetCore.Http;

namespace TroquelApi.Models
{
    public class Imagen
    {
        public string Name { get; set; }
        public IFormFile Image { get; set; }
    }
}
