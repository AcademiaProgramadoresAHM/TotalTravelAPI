using AHM.Total.Travel.BusinessLogic.Services;
using AHM.Total.Travel.Common.Models;
using AHM.Total.Travel.Entities.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AHM.Total.Travel.Api.Controllers
{
    [ApiController]
    [Route("API/[controller]")]
    [Authorize(Roles = "Administrador, Cliente, Moderador de Restaurante")]
    public class RestaurantsController : Controller
    {

        private readonly RestaurantService _restaurantService;
        private readonly IMapper _mapper;
        public RestaurantsController(RestaurantService restaurantService, IMapper mapper)
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
        [HttpPost("Insert")]
        public IActionResult Insert([FromForm]RestaurantesViewModel item)
        {
            var user = _mapper.Map<tbRestaurantes>(item);
            var result = _restaurantService.CreateRestaurants(user, item.File);
            return Ok(result);
        }


        [HttpPut("Update")]
        public IActionResult Update(int id, [FromForm] RestaurantesViewModel items)
        {

            var item = _mapper.Map<tbRestaurantes>(items);
            var result = _restaurantService.UpdateRestaurants(id, item, items.File);
            return Ok(result);

        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id, int Mod)
        {
            var result = _restaurantService.DeleteRestaurants(id, Mod);
            return Ok(result);

        }

        [Authorize(Roles = "Administrador, Moderador de Restaurante")]
        [HttpGet("Find")]
        public IActionResult Details(int Id)
        {

            var result = _restaurantService.FindRestaurants(Id);
            return Ok(result);
        }

    }
}
