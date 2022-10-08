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
    public class RoomsController : Controller
    {
        private readonly HotelService _hotelService;
        private readonly IMapper _mapper;
        public RoomsController(HotelService hotelService, IMapper mapper)
        {
            _hotelService = hotelService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet("List")]
        public IActionResult List()
        {
            var list = _hotelService.ListHabitaciones();
            return Ok(list);

        }

        [HttpPost("Insert")]
        public IActionResult Insert(HabitacionesViewModel habitacionesViewModel)
        {
            IFormFile file;
            if (habitacionesViewModel.File != null)
            {
                file = habitacionesViewModel.File;
            }
            else
            {
                string pathdefault = Path.GetFullPath("ImagesAPI/Assets_System_Photos/ImageDefault.jpg");
                byte[] byteFile = System.IO.File.ReadAllBytes(pathdefault);

                var stream = new MemoryStream(byteFile);
                file = new FormFile(stream, 0, stream.Length, "ImageDefault", "ImageDefault.jpg");
            }
            var items = _mapper.Map<tbHabitaciones>(habitacionesViewModel);
            var result = _hotelService.CreateHabitaciones(items, file);
            return Ok(result);
        }

        [HttpPut("Update")]
        public IActionResult Update(int id, HabitacionesViewModel habitacionesViewModel)
        {

            var item = _mapper.Map<tbHabitaciones>(habitacionesViewModel);
            var result = _hotelService.UpdateHabitaciones(id, item);
            return Ok(result);

        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id, int Mod)
        {
            var result = _hotelService.DeleteHabitaciones(id, Mod);
            return Ok(result);

        }

        [Authorize(Roles = "Cliente")]
        [HttpGet("Find")]
        public IActionResult Details(int Id)
        {

            var result = _hotelService.FindHabitaciones(Id);
            return Ok(result);
        }
    }
}
