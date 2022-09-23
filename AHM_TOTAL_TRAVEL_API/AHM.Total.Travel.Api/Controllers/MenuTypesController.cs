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
    [Route("[controller]")]
    public class MenuTypesController : Controller
    {
        private readonly RestaurantService _restaurantService;
        private readonly IMapper _mapper;
        public MenuTypesController(RestaurantService restaurantService, IMapper mapper)
        {
            _restaurantService = restaurantService;
            _mapper = mapper;
        }

        [HttpGet("List")]
        public IActionResult List()
        {
            var list = _restaurantService.ListTipoMenus();
            return Ok(list);
        }

        [HttpPost("Insert")]
        public IActionResult Insert(TipoMenusViewModel tipoMenusViewModel)
        {
            var items = _mapper.Map<tbTipoMenus>(tipoMenusViewModel);
            var result = _restaurantService.CreateTipoMenus(items);
            return Ok(result);
        }

        [HttpPut("Update")]
        public IActionResult Update(int id, TipoMenusViewModel tipoMenusViewModel)
        {
            var item = _mapper.Map<tbTipoMenus>(tipoMenusViewModel);
            var result = _restaurantService.UpdateTipoMenus(id, item);
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id, int Mod)
        {
            var result = _restaurantService.DeleteTipoMenus(id, Mod);
            return Ok(result);
        }

        [HttpGet("Find")]
        public IActionResult Details(int Id)
        {
            var result = _restaurantService.FindTipoMenus(Id);
            return Ok(result);
        }
    }
}
