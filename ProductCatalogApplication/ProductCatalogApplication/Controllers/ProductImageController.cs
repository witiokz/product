using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProductCatalogApplication.Controllers
{
    [Produces("application/json")]
    [Route("api/ProductImage")]
    public class ProductImageController : Controller
    {
        private readonly string ImagesFolderName = "Upload";
        private readonly string ImagePath;


        private IHostingEnvironment hostingEnvironment;

        public ProductImageController(IHostingEnvironment hostingEnvironment)
        {
            this.hostingEnvironment = hostingEnvironment;

            ImagePath = Path.Combine(hostingEnvironment.WebRootPath, ImagesFolderName);

            if (!Directory.Exists(ImagePath))
            {
                Directory.CreateDirectory(ImagePath);
            }
        }

        [HttpGet]
        public IActionResult Get(string id)
        {
            return PhysicalFile(Path.Combine(ImagePath, id), "image/jpeg");
        }

        [HttpPost]
        public IActionResult Post(IFormFile file)
        {
            if (file.Length > 0)
            {
                using (var fileStream = new FileStream(Path.Combine(ImagePath, file.FileName), FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var filePath = Path.Combine(ImagePath, id);

            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }

            return Ok();
        }
    }
}