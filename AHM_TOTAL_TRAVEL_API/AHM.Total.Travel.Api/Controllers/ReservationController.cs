using AHM.Total.Travel.BusinessLogic.Services;
using AHM.Total.Travel.Common.Models;
using AHM.Total.Travel.Entities.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AHM.Total.Travel.Api.Controllers
{
    [ApiController]
    [Route("API/[controller]")]
    [Authorize(Roles = "Administrador, Cliente, Moderador de Transporte")]
    public class ReservationController : Controller
    {
        private readonly ReservationService _reservationService;
        private readonly IMapper _mapper;
        public ReservationController(ReservationService reservationService, IMapper mapper)
        {
            _reservationService = reservationService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet("List")]
        public IActionResult List()
        {
            var list = _reservationService.ListReservation();
            return Ok(list);
        }
        
        [HttpPost("Insert")]
        public IActionResult Insert(ReservacionesViewModel item)
        {
            try
            {
                var items = _mapper.Map<tbReservaciones>(item);
                var result = _reservationService.InsertReservation(items, item);
                return Ok(result);
            }
            catch (Exception)
            {

                return BadRequest("Ha ocurrido un error al momento de realizar la operación");
            }
            
        }

        [HttpPut("Update")]
        public IActionResult Update(int id, ReservacionesViewModel items)
        {
            var item = _mapper.Map<tbReservaciones>(items);
            var result = _reservationService.UpdateReservation(id, item);
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id, int Mod)
        {
            var result = _reservationService.DeleteReservation(id, Mod);
            return Ok(result);
        }

        [HttpGet("Find")]
        public IActionResult Details(int Id)
        {
            var result = _reservationService.FindReservation(Id);
            return Ok(result);
        }

        
        [HttpGet("Find/Timeline")]
        public IActionResult Timeline(int id)
        {
            var result = _reservationService.Timeline(id);
            return Ok(result);
        }
    }
}
