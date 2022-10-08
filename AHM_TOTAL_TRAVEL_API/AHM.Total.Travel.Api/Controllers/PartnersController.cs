using AHM.Total.Travel.BusinessLogic.Services;
using AHM.Total.Travel.Common.Models;
using AHM.Total.Travel.Entities.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize(Roles = "Administrador")]
    public class PartnersController : Controller
    {
        private readonly GeneralService _generalService;
        private readonly IMapper _mapper;

        public PartnersController(GeneralService generalService, IMapper mapper)
        {
            _generalService = generalService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet("List")]
        public IActionResult List()
        {
            var list = _generalService.ListPartners();
            return Ok(list);

        }

        [HttpPost("Insert")]
        public IActionResult Insert([FromForm] PartnersViewModel partnersViewModel)
        {
            IFormFile file;
            if (partnersViewModel.File != null)
            {
                file = partnersViewModel.File;
            }
            else
            {
                string pathdefault = Path.GetFullPath("ImagesAPI/Assets_System_Photos/ImageDefault.jpg");
                byte[] byteFile = System.IO.File.ReadAllBytes(pathdefault);

                var stream = new MemoryStream(byteFile);
                file = new FormFile(stream, 0, stream.Length, "ImageDefault", "ImageDefault.jpg");
            }
            var items = _mapper.Map<tbPartners>(partnersViewModel);
            var result = _generalService.CreatePartner(items, file);
            return Ok(result);
        }

        [HttpPut("Update")]
        public IActionResult Update(int id, PartnersViewModel partnersViewModel)
        {

            var item = _mapper.Map<tbPartners>(partnersViewModel);
            var result = _generalService.UpdatePartner(id, item);
            return Ok(result);

        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id, int Mod)
        {
            var result = _generalService.DeletePartner(id, Mod);
            return Ok(result);

        }

        [HttpGet("Find")]
        public IActionResult Details(int Id)
        {

            var result = _generalService.FindPartner(Id);
            return Ok(result);
        }
    }
}
