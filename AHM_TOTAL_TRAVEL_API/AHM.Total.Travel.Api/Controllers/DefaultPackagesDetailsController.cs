using AHM.Total.Travel.BusinessLogic.Services;
using AHM.Total.Travel.Common.Models;
using AHM.Total.Travel.Entities.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AHM.Total.Travel.Api.Controllers
{
    [ApiController]
    [Route("API/[controller]")]
    public class DefaultPackagesDetailsController : Controller
    {
        private readonly SaleService _saleService;
        private readonly IMapper _mapper;
        public DefaultPackagesDetailsController(SaleService saleService, IMapper mapper)
        {
            _saleService = saleService;
            _mapper = mapper;
        }

        [HttpGet("List")]
        public IActionResult List()
        {
            var list = _saleService.ListPackagesdetail();
            return Ok(list);

        }

        [HttpPost("Insert")]
        public IActionResult Insert(PaquetePredeterminadosDetallesViewModel paquetePredeterminadosDetallesViewModel)
        {
            var items = _mapper.Map<tbPaquetePredeterminadosDetalles>(paquetePredeterminadosDetallesViewModel);
            var result = _saleService.CreatePackagesdetail(items);
            return Ok(result);
        }

        [HttpPut("Update")]
        public IActionResult Update(int id, PaquetePredeterminadosDetallesViewModel paquetePredeterminadosDetallesViewModel)
        {

            var item = _mapper.Map<tbPaquetePredeterminadosDetalles>(paquetePredeterminadosDetallesViewModel);
            var result = _saleService.UpdatePackagesdetail(id, item);
            return Ok(result);

        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id, int Mod)
        {
            var result = _saleService.DeletePackagesdetail(id, Mod);
            return Ok(result);

        }

        [HttpGet("Find")]
        public IActionResult Details(int Id)
        {

            var result = _saleService.FindPackagesdetail(Id);
            return Ok(result);
        }
    }
}

