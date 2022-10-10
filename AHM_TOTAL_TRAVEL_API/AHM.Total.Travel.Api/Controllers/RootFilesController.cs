using AHM.Total.Travel.DataAccess.Repositories;
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
        private readonly UploaderImageRepository _UploaderImageRepository;
        public RootFilesController(UploaderImageRepository UploaderImageRepository)
        {
            _UploaderImageRepository = UploaderImageRepository;
        }

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

        [HttpGet("UploadFile")]
        public IActionResult UploadFile([FromForm] FileModel FileData )
        {
            var result = _UploaderImageRepository.UploaderFile(FileData);
            return Ok(result);
        }
    }

    public class ImagesDetail
    {
        public string FileName { get; set; }
        public string Directory { get; set; }
        public string Extension { get; set; }
    }
}
