using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AHM.Total.Travel.Api.Controllers
{

    [ApiController]
    [Route("API/[controller]")]
    [Authorize]
    [AllowAnonymous]
    public class RootFilesController : Controller
    {
        private readonly IWebHostEnvironment _IWebHostEnvironment;
        public RootFilesController(IWebHostEnvironment IWebHostEnvironment)
        {
            _IWebHostEnvironment = IWebHostEnvironment;
        }

        [HttpGet("GetFile")]
        public async Task<IActionResult> GetFile(string fileRoute)
        {
            string path = Path.Combine(_IWebHostEnvironment.ContentRootPath, "ImagesAPI", fileRoute);
            if (System.IO.File.Exists(path))
            {
                byte[] b = System.IO.File.ReadAllBytes(path);
                //return Ok(b);
                return File(b, "image/jpg");
            }
            return null;
        }

        [HttpGet("GetAllFiles")]
        public IActionResult GetAllFiles(string directory)
        {
            string path = Path.Combine(_IWebHostEnvironment.ContentRootPath, "ImagesAPI", directory);
            List<string> filesDirectory = Directory.GetFiles(path, "*", SearchOption.AllDirectories).ToList();
            List<FileContentResult> DataAccess = new List<FileContentResult>();
            foreach (var item in filesDirectory)
            {
                byte[] byteFile = System.IO.File.ReadAllBytes(item);
                DataAccess.Add(File(byteFile, "image/jpg"));
            }

            return Ok(DataAccess);
            
        }
    }
}
