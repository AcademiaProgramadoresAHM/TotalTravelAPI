using AHM.Total.Travel.BusinessLogic.Services;
using AHM.Total.Travel.DataAccess.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace AHM.Total.Travel.Api.Controllers
{

    [ApiController]
    [Route("API/[controller]")]
    [Authorize]
    [AllowAnonymous]
    public class RootFilesController : ControllerBase
    {
        private readonly ImagesService _imagesService;

        public RootFilesController( ImagesService imagesService)
        {
            _imagesService = imagesService;
        }


        [HttpPost("UploadImage")]
        public IActionResult UploadImage(List<IFormFile> file, string folderName)
        {
            try
            {
                string imagesPaths = (_imagesService.saveImages(file, folderName).Data);
                return Ok(imagesPaths);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetImage")]
        public IActionResult GetImage(string folderName, string imageName)
        {
            try
            {
                return _imagesService.getImage(folderName, imageName);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAllImages")]
        public IActionResult GetAllImages(string folderName)
        {
            try
            {
                var response = _imagesService.getAllImagesAsBase64(folderName);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
    }

    
}
