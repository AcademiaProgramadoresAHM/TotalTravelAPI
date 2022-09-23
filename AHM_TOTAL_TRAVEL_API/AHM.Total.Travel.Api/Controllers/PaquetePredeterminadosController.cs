using AHM.Total.Travel.BusinessLogic.Services;
using AHM.Total.Travel.Common.Models;
using AHM.Total.Travel.Entities.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AHM.Total.Travel.Api.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class PaquetePredeterminadosController : Controller
    {
        private readonly SaleService _saleService;
        private readonly IMapper _mapper;
        public PaquetePredeterminadosController(SaleService saleService, IMapper mapper)
        {
            _saleService = saleService;
            _mapper = mapper;
        }
        [HttpGet("List")]
        public IActionResult List()
        {
            var list = _saleService.Listpackages();
            return Ok(list);

        }

        [HttpPost("Insert")]
        public IActionResult Insert(PaquetePredeterminadosViewModel items)
        {

            var item = _mapper.Map<tbPaquetePredeterminados>(items);
            var result = _saleService.Createpackages(item);
            return Ok(result);

        }


        [HttpPut("Update")]
        public IActionResult Update(int id, PaquetePredeterminadosViewModel items)
        {

            var item = _mapper.Map<tbPaquetePredeterminados>(items);
            var result = _saleService.Updatepackages(id, item);
            return Ok(result);

        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id, int Mod)
        {
            var result = _saleService.Deletepackages(id, Mod);
            return Ok(result);

        }

        [HttpGet("Find")]
        public IActionResult Details(int id)
        {
            var result = _saleService.FindPackage(id);
            return Ok(result);
        }
    }
}
