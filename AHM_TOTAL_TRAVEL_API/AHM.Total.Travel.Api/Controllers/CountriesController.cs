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
    public class CountriesController : ControllerBase
    {
        private readonly GeneralService _generalService;
        private readonly IMapper _mapper;
        public CountriesController(GeneralService generalService, IMapper mapper)
        {
            _generalService = generalService;
            _mapper = mapper;
        }

        //[Authorize(Roles = "Cliente")]
        [AllowAnonymous]
        [HttpGet("List")]
        public IActionResult List()
        {
            try
            {
                var list = _generalService.ListCountries();
                return Ok(list);
            }
            catch (Exception)
            {

                ServiceResult serviceResult = new ServiceResult();
                return Ok(serviceResult.Error());
            }
           

        }

        [HttpPost("Insert")]
        public IActionResult Insert(PaisesViewModel paisesViewModel)
        {
            try
            {
                var items = _mapper.Map<tbPaises>(paisesViewModel);
                var result = _generalService.CreateCountry(items);
                return Ok(result);
            }
            catch (Exception)
            {

                ServiceResult serviceResult = new ServiceResult();
                return Ok(serviceResult.Error());
            }
           
        }

        [HttpPut("Update")]
        public IActionResult Update(int id, PaisesViewModel paisesViewModel)
        {

            try
            {
                var item = _mapper.Map<tbPaises>(paisesViewModel);
                var result = _generalService.UpdateCountry(id, item);
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
                var result = _generalService.DeleteCountry(id, Mod);
                return Ok(result);
            }
            catch (Exception)
            {

                ServiceResult serviceResult = new ServiceResult();
                return Ok(serviceResult.Error());
            }
           

        }

        [HttpGet("Find")]
        public IActionResult Details(int Id)
        {
            try
            {
                var result = _generalService.FindCountry(Id);
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
