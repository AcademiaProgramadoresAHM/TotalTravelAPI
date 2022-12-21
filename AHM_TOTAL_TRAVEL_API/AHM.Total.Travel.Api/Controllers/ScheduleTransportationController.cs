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
    [Authorize(Roles = "Administrador, Moderador de Transporte")]
    public class ScheduleTransportationController : Controller
    {
        private readonly TransportService _transportService;
        private readonly IMapper _mapper;
        public ScheduleTransportationController(TransportService transportService, IMapper mapper)
        {
            _transportService = transportService;
            _mapper = mapper;
        }
        [AllowAnonymous]
        [HttpGet("List")]
        public IActionResult List()
        {
            try
            {
                var list = _transportService.ListHorariosTransports();
                return Ok(list);
            }
            catch (Exception)
            {

                ServiceResult serviceResult = new ServiceResult();
                return Ok(serviceResult.Error());
            }
           

        }

        [HttpPost("Insert")]
        public IActionResult Insert(HorariosTransportesViewModel item)
        {
            try
            {
                var items = _mapper.Map<tbHorariosTransportes>(item);
                var result = _transportService.CreateHorariosTransports(items);
                return Ok(result);
            }
            catch (Exception)
            {

                ServiceResult serviceResult = new ServiceResult();
                return Ok(serviceResult.Error());
            }
         
        }

        [HttpPut("Update")]
        public IActionResult Update(int id, HorariosTransportesViewModel items)
        {
            try
            {
                var item = _mapper.Map<tbHorariosTransportes>(items);
                var result = _transportService.UpdateHorariosTransports(id, item);
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
                var result = _transportService.DeleteHorariosTransports(id, Mod);
                return Ok(result);
            }
            catch (Exception)
            {

                ServiceResult serviceResult = new ServiceResult();
                return Ok(serviceResult.Error());
            }
           

        }
        [AllowAnonymous]
        [HttpGet("Find")]
        public IActionResult Details(int Id)
        {
            try
            {
                var result = _transportService.FindHorariosTransports(Id);
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
