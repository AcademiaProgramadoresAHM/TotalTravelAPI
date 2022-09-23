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
    public class MenusController : Controller
    {
        private readonly RestaurantService _restaurantService;
        private readonly IMapper _mapper;
        public MenusController(RestaurantService restaurantService, IMapper mapper)
        {
            _restaurantService = restaurantService;
            _mapper = mapper;
        }


        [HttpGet("List")]
        public IActionResult List()
        {
            var list = _restaurantService.ListMenus();
            return Ok(list);

        }

        [HttpPost("Insert")]
        public IActionResult Insert(MenusViewModel menusViewModel)
        {
            var items = _mapper.Map<tbMenus>(menusViewModel);
            var result = _restaurantService.CreateMenus(items);
            return Ok(result);
        }


        [HttpPut("Update")]
        public IActionResult Update(int id, MenusViewModel menusViewModel)
        {

            var item = _mapper.Map<tbMenus>(menusViewModel);
            var result = _restaurantService.UpdateMenus(id, item);
            return Ok(result);

        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id, int Mod)
        {
            var result = _restaurantService.DeleteMenus(id, Mod);
            return Ok(result);

        }

        [HttpGet("Find")]
        public IActionResult Details(int Id)
        {

            var result = _restaurantService.FindMenus(Id);
            return Ok(result);
        }

    }
}
