using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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

        [HttpGet("GetFile")]
        public async Task<IActionResult> GetFile(string fileRoute)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "ImagesAPI", fileRoute);
            if (System.IO.File.Exists(path))
            {
                byte[] b = System.IO.File.ReadAllBytes(path);
                //return Ok(b);
                return File(b, "image/jpg");
            }
            return Ok();
        }

        [HttpGet("GetDirectoryImageFile")]
        public IActionResult GetDirectoryImageFile(string directory)
        {
            List<ImagesDetail> fileNames = new List<ImagesDetail>();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "ImagesAPI", directory);

            if (Directory.Exists(path))
            {
                string[] fileEntries = Directory.GetFiles(path);
                foreach (var item in fileEntries)
                {
                    string[] imagePath = item.Split("\\");
                    string fileName = imagePath[imagePath.Length - 1];
                    string[] fileExtension = fileName.Split(".");
                    string fileDirectory = $"ImagesAPI/{directory}/{fileName}".Replace("\\", "/");
                    ImagesDetail fileDetail = new ImagesDetail
                    {
                        FileName = fileName,
                        Directory = fileDirectory,
                        Extension = fileExtension[fileExtension.Length - 1]
                    };
                    fileNames.Add(fileDetail);

                }
            }
            return Ok(fileNames);
        }
    }

    public class ImagesDetail
    {
        public string FileName { get; set; }
        public string Directory { get; set; }
        public string Extension { get; set; }
    }
}
