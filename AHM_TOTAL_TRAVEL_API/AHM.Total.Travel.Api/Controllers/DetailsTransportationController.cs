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
    public class DetailsTransportationController : Controller
    {
        private readonly TransportService _transportService;
        private readonly IMapper _mapper;

        public DetailsTransportationController(TransportService transportService, IMapper mapper)
        {
            _transportService = transportService;
            _mapper = mapper;
        }

        //[Authorize(Roles = "Cliente")]
        [AllowAnonymous]
        [HttpGet("List")]
        public IActionResult List()
        {
            
            try
            {
                var list = _transportService.ListDetallesTransports();
                return Ok(list);
            }
            catch (Exception)
            {

                var data = new ServiceResult();
                return Ok(data.Error());
            }

        }
        [HttpPost("Insert")]
        public IActionResult Insert(DetallesTransportesViewModel detallesTransportesViewModel)
        {
            try
            {
                var items = _mapper.Map<tbDetallesTransportes>(detallesTransportesViewModel);
                var result = _transportService.CreateDetallesTransports(items);
                return Ok(result);
            }
            catch (Exception)
            {

                var data = new ServiceResult();
                return Ok(data.Error());
            }
           
        }
        [HttpPut("Update")]
        public IActionResult Update(int id, DetallesTransportesViewModel detallesTransportesViewModel)
        {
            try
            {
                var item = _mapper.Map<tbDetallesTransportes>(detallesTransportesViewModel);
                var result = _transportService.UpdateDetallesTransports(id, item);
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
                var result = _transportService.DeleteDetallesTransports(id, Mod);
                return Ok(result);
            }
            catch (Exception)
            {

                var data = new ServiceResult();
                return Ok(data.Error());
            }
            

        }

        [HttpGet("Find")]
        public IActionResult Details(int Id)
        {
            try
            {
                var result = _transportService.FindDetallesTransports(Id);
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
