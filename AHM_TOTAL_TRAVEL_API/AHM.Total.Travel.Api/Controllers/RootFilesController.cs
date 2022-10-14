using AHM.Total.Travel.BusinessLogic.Services;
using AHM.Total.Travel.DataAccess.Repositories;
using Google.Apis.Gmail.v1.Data;
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


        //[HttpPost("UploadImage")]
        //public async Task<IActionResult> UploadImage(List<IFormFile> file, [FromForm] string folderName)
        //{
        //    try
        //    {
        //        return Ok(await _imagesService.saveImages(folderName, file));
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest("Ocurrió un error al subir la imagen");
        //    }
        //}

        [HttpGet("GetImage")]
        public IActionResult GetImage(string path)
        {
            try
            {
                return Ok(_imagesService.getImage(path));
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
                return Ok(_imagesService.getAllImagesFromFolder(folderName, HttpContext));
            }
            catch (Exception ex)
            {
                return NotFound("La ruta no existe");
            }
        }

    }

    
}
