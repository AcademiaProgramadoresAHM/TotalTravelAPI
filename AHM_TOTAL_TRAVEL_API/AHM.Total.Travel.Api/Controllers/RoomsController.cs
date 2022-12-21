using AHM.Total.Travel.BusinessLogic;
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
    public class RoomsController : Controller
    {
        private readonly HotelService _hotelService;
        private readonly IMapper _mapper;
        public RoomsController(HotelService hotelService, IMapper mapper)
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
                var list = _hotelService.ListHabitaciones();
                return Ok(list);
            }
            catch (Exception)
            {
                ServiceResult serviceResult = new ServiceResult();
                return Ok(serviceResult.Error());
            }
           

        }

        [AllowAnonymous]
        [HttpPost("Insert")]
        public IActionResult Insert([FromForm]HabitacionesViewModel habitacionesViewModel)
        {
            try
            {
                var items = _mapper.Map<tbHabitaciones>(habitacionesViewModel);
                var result = _hotelService.CreateHabitaciones(items, habitacionesViewModel.File);
                return Ok(result);
            }
            catch (Exception)
            {

                ServiceResult serviceResult = new ServiceResult();
                return Ok(serviceResult.Error());
            }
            
        }

        [HttpPut("Update")]
        public IActionResult Update(int id, [FromForm] HabitacionesViewModel habitacionesViewModel)
        {
            try
            {
                var item = _mapper.Map<tbHabitaciones>(habitacionesViewModel);
                var result = _hotelService.UpdateHabitaciones(id, item, habitacionesViewModel.File);
                return Ok(result);
            }
            catch (Exception)
            {

                ServiceResult serviceResult = new ServiceResult();
                return Ok(serviceResult.Error());
            }
           

        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id, int Mod)
        {
            try
            {
                var result = _hotelService.DeleteHabitaciones(id, Mod);
                return Ok(result);
            }
            catch (Exception)
            {

                ServiceResult serviceResult = new ServiceResult();
                return Ok(serviceResult.Error());
            }
           

        }

        [Authorize(Roles = "Cliente, Administrador")]
        [HttpGet("Find")]
        public IActionResult Details(int Id)
        {

            try
            {
                var result = _hotelService.FindHabitaciones(Id);
                return Ok(result);
            }
            catch (Exception)
            {

                ServiceResult serviceResult = new ServiceResult();
                return Ok(serviceResult.Error());
            }
           
        }
    }
}
