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
    public class HotelsActivitiesController : Controller
    {
        private readonly HotelService _hotelService;
        private readonly IMapper _mapper;
        public HotelsActivitiesController(HotelService hotelService, IMapper mapper)
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
                var list = _hotelService.ListHotelsActivity();
                return Ok(list);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpPost("Insert")]
        public IActionResult Insert([FromForm]HotelesActividadesViewModel hotelesActividadesViewModel)
        {
            try
            {
                var items = _mapper.Map<tbHotelesActividades>(hotelesActividadesViewModel);
                var result = _hotelService.CreateHotelsActivity(items, hotelesActividadesViewModel.File);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("Update")]
        public IActionResult Update(int id, [FromForm] HotelesActividadesViewModel hotelesActividadesViewModel)
        {
            try
            {
                var item = _mapper.Map<tbHotelesActividades>(hotelesActividadesViewModel);
                var result = _hotelService.UpdateHotelsActivity(id, item, hotelesActividadesViewModel.File);
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
                var result = _hotelService.DeleteHotelsActivity(id, Mod);
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
                var result = _hotelService.FindHotelsActivity(Id);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    }
}
