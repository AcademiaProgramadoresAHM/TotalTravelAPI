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
    [Route("API/[controller]")]
    [Authorize(Roles = "Administrador, Cliente, Moderador de Hotel")]
    public class ReservationHotelsController : Controller
    {
        
        private readonly ReservationService _reservationService;
        private readonly IMapper _mapper;

        public ReservationHotelsController(ReservationService reservationService, IMapper mapper)
        {
            _reservationService = reservationService;
            _mapper = mapper;
        }

        [HttpGet("List")]
        public IActionResult List()
        {
            try
            {
                var list = _reservationService.ListReservationHotel();
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
        public IActionResult Insert(ReservacionesHotelesViewModel item)
        {
            try
            {
                var items = _mapper.Map<tbReservacionesHoteles>(item);
                var result = _reservationService.CreateReservationHotel(items);
                return Ok(result);
            }
            catch (Exception)
            {

                var data = new ServiceResult();
                return Ok(data.Error());
            }

           
        }

        [HttpPut("Update")]
        public IActionResult Update(int id, ReservacionesHotelesViewModel items)
        {
            
            try
            {
                var item = _mapper.Map<tbReservacionesHoteles>(items);
                var result = _reservationService.UpdateReservationHotel(id, item);
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
                var result = _reservationService.DeleteReservationHotel(id, Mod);
                return Ok(result);
            }
            catch (Exception)
            {

                var data = new ServiceResult();
                return Ok(data.Error());
            }
           
        }

        [HttpGet("Find")]
        public IActionResult Find(int id)
        {
            try
            {
                var result = _reservationService.FindReservationHotel(id);
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
