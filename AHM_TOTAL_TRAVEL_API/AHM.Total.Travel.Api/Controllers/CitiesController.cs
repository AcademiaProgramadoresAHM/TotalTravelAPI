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
    [Authorize(Roles = "Administrador, Moderador de Actividades")]
    public class CitiesController : Controller
    {
        private readonly GeneralService _generalService;
        private readonly IMapper _mapper;
        public CitiesController(GeneralService generalService, IMapper mapper)
        {
            _generalService = generalService;
            _mapper = mapper;
        }
        [AllowAnonymous]
        [HttpGet("List")]
        public IActionResult List()
        {
            try
            {
                var list = _generalService.ListCities();
                return Ok(list);
            }
            catch (Exception)
            {

                var data = new ServiceResult();
                return Ok(data.Error());
            }
           
        }


        [HttpPost("Insert")]
        public IActionResult Insert(CiudadesViewModel ciudadesViewModel)
        {
            try
            {
                var items = _mapper.Map<tbCiudades>(ciudadesViewModel);
                var result = _generalService.CreateCity(items);
                return Ok(result);
            }
            catch (Exception)
            {
                var data = new ServiceResult();
                return Ok(data.Error());

            }
           
        }



        [HttpPut("Update")]
        public IActionResult Update(int id, CiudadesViewModel items)
        {
            try
            {
                var item = _mapper.Map<tbCiudades>(items);
                var result = _generalService.UpdateCity(id, item);
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
                var result = _generalService.DeleteCity(id, Mod);
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
                var result = _generalService.FindCity(Id);
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
