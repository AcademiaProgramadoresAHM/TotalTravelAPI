using AHM.Total.Travel.BusinessLogic.Services;
using AHM.Total.Travel.Common.Models;
using AHM.Total.Travel.Entities.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AHM.Total.Travel.Api.Controllers
{
    [ApiController]
    [Route("API/[controller]")]
    [Authorize(Roles = "Administrador")]
    public class CategoriesRoomsController : Controller
    {
        private readonly HotelService _hotelService;
        private readonly IMapper _mapper;
        public CategoriesRoomsController(HotelService hotelService, IMapper mapper)
        {
            _hotelService = hotelService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet("List")]
        public IActionResult List()
        {
            var list = _hotelService.ListCategoriesRooms();
            return Ok(list);

        }

        [HttpPost("Insert")]
        public IActionResult Insert(CategoriasHabitacionesViewModel categoriasHabitacionesViewModel)
        {
            var items = _mapper.Map<tbCategoriasHabitaciones>(categoriasHabitacionesViewModel);
            var result = _hotelService.CreateCategoriesRooms(items);
            return Ok(result);
        }

        [HttpPut("Update")]
        public IActionResult Update(int id, CategoriasHabitacionesViewModel categoriasHabitacionesViewModel)
        {

            var item = _mapper.Map<tbCategoriasHabitaciones>(categoriasHabitacionesViewModel);
            var result = _hotelService.UpdateCategoriesRooms(id, item);
            return Ok(result);

        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id, int Mod)
        {
            var result = _hotelService.DeleteCategoriesRooms(id, Mod);
            return Ok(result);

        }

        [HttpGet("Find")]
        public IActionResult Details(int Id)
        {
            var result = _hotelService.FindCategoriesRooms(Id);
            return Ok(result);
        }
    }
}
