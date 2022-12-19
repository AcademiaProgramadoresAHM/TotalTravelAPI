using AHM.Total.Travel.BusinessLogic;
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
    [Route("API/[Controller]")]
    [Authorize(Roles = "Administrador, Cliente, Moderador de Restaurante")]
    public class ReservationRestaurantController : Controller
    {
        private readonly ReservationService  _reservationService;
        private readonly IMapper _mapper;
        public ReservationRestaurantController(ReservationService  reservationService, IMapper mapper)
        {
            _reservationService = reservationService;
            _mapper = mapper;
        }

        [Authorize(Roles = "Administrador, Moderador de Restaurante")]
        [HttpGet("List")]
        public IActionResult List()
        {
            try
            {
                var list = _reservationService.ListReservationRestaurant();
                return Ok(list);
            }
            catch (Exception)
            {

                var data = new ServiceResult();
                return Ok(data.Error());
            }
            

        }

        [Authorize(Roles = "Administrador, Cliente")]
        [HttpPost("Insert")]
        public IActionResult Insert( ReservacionRestaurantesViewModel items)
        {
            try
            {
                var item = _mapper.Map<tbReservacionRestaurantes>(items);
                var result = _reservationService.CreateReservationRestaurant(item);
                return Ok(result);
            }
            catch (Exception)
            {

                var data = new ServiceResult();
                return Ok(data.Error());
            }
            

        }


        [HttpPut("Update")]
        public IActionResult Update(int id, ReservacionRestaurantesViewModel items)
        {
            try
            {
                var item = _mapper.Map<tbReservacionRestaurantes>(items);
                var result = _reservationService.UpdateReservationRestaurant(id, item);
                return Ok(result);
            }
            catch (Exception)
            {

                var data = new ServiceResult();
                return Ok(data.Error());
            }
           

        }


        [HttpDelete("Delete")]
        public IActionResult Delete(int id, int Mod)
        {
            try
            {
                var result = _reservationService.DeleteReservationRestaurant(id, Mod);
                return Ok(result);
            }
            catch (Exception)
            {

                var data = new ServiceResult();
                return Ok(data.Error());
            }
           

        }

        [Authorize(Roles = "Administrador, Moderador de Restaurante")]
        [HttpGet("Find")]
        public IActionResult Details(int Id)
        {
            try
            {
                var result = _reservationService.FindReservationRestaurant(Id);
                return Ok(result);
            }
            catch (Exception)
            {

                var data = new ServiceResult();
                return Ok(data.Error());
            }
            
        }
    }
}
