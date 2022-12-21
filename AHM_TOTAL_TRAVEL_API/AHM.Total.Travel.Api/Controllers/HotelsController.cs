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
    [Authorize(Roles = "Administrador, Moderador de Hotel")]
    public class HotelsController : Controller
    {
        private readonly HotelService _hotelService;
        private readonly IMapper _mapper;
        public HotelsController(HotelService hotelService, IMapper mapper)
        {
            _hotelService = hotelService;
            _mapper = mapper;
        }

        //[Authorize(Roles = "Cliente")]
        [AllowAnonymous]
        [HttpGet("List")]
        public IActionResult List()
        {
            try
            {
            var list = _hotelService.ListHotels();
            return Ok(list);
            }
            catch (Exception)
            {
                return BadRequest();
            }


        }

        [HttpPost("Insert")]
        public IActionResult Insert([FromForm] HotelesViewModel hotelesViewModel)
        {
            try { 
            var items = _mapper.Map<tbHoteles>(hotelesViewModel);
            var result = _hotelService.CreateHotels(items, hotelesViewModel.File);
            return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("Update")]
        public IActionResult Update(int id,[FromForm] HotelesViewModel hotelesViewModel)
        {
            try
            {
                var item = _mapper.Map<tbHoteles>(hotelesViewModel);
                var result = _hotelService.UpdateHotels(id, item, hotelesViewModel.File);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id, int Mod)
        {
            try
            {
                var result = _hotelService.DeleteHotels(id, Mod);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpGet("Find")]
        public IActionResult Details(int Id)
        {
            try
            {
                var result = _hotelService.FindHotels(Id);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    }
}
