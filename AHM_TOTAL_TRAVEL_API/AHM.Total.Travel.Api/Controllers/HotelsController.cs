using AHM.Total.Travel.BusinessLogic.Services;
using AHM.Total.Travel.Common.Models;
using AHM.Total.Travel.Entities.Entities;
using AutoMapper;
using ConciertosProyecto.BusinessLogic;
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
    public class HotelsController : Controller
    {
        private readonly HotelService _hotelService;
        private readonly IMapper _mapper;
        public HotelsController(HotelService hotelService, IMapper mapper)
        {
            _hotelService = hotelService;
            _mapper = mapper;
        }


        [HttpGet("List")]
        public IActionResult List()
        {
            var list = _hotelService.ListHotels();
            return Ok(list);

        }

        [AllowAnonymous]
        [HttpPost("Insert")]
        public IActionResult Insert([FromForm]HotelesViewModel hotelesViewModel)
        {

            IFormFile file;
            if (hotelesViewModel.File != null)
            {
                file = hotelesViewModel.File;
            }
            else
            {
                string pathdefault = Path.GetFullPath("ImagesAPI/Assets_System_Photos/ImageDefault.jpg");
                byte[] byteFile = System.IO.File.ReadAllBytes(pathdefault);

                var stream = new MemoryStream(byteFile);
                file = new FormFile(stream, 0, stream.Length, "ImageDefault", "ImageDefault.jpg");
            }
            var items = _mapper.Map<tbHoteles>(hotelesViewModel);
            var result = _hotelService.CreateHotels(items, file);
            return Ok(result);
        }

        [HttpPut("Update")]
        public IActionResult Update(int id, HotelesViewModel hotelesViewModel)
        {

            var item = _mapper.Map<tbHoteles>(hotelesViewModel);
            var result = _hotelService.UpdateHotels(id, item);
            return Ok(result);

        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id, int Mod)
        {
            var result = _hotelService.DeleteHotels(id, Mod);
            return Ok(result);

        }

        [HttpGet("Find")]
        public IActionResult Details(int Id)
        {
            var result = _hotelService.FindHotels(Id);
            return Ok(result);
        }

    }
}
