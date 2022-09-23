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
    public class RestaurantesController : Controller
    {

        private readonly RestaurantService _restaurantService;
        private readonly IMapper _mapper;
        public RestaurantesController(RestaurantService restaurantService, IMapper mapper)
        {
            _restaurantService = restaurantService;
            _mapper = mapper;
        }

        [HttpGet("List")]
        public IActionResult List()
        {
            var list = _restaurantService.ListRestaurants ();
            return Ok(list);
        }

        [HttpPut("Update")]
        public IActionResult Update(int id, RestaurantesViewModel items)
        {

            var item = _mapper.Map<tbRestaurantes>(items);
            var result = _restaurantService.UpdateRestaurants(id, item);
            return Ok(result);

        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id, int Mod)
        {
            var result = _restaurantService.DeleteRestaurants(id, Mod);
            return Ok(result);

        }

        [HttpGet("Find")]
        public IActionResult Details(int Id)
        {

            var result = _restaurantService.FindRestaurants(Id);
            return Ok(result);
        }

    }
}
