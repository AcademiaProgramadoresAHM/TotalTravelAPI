using AHM.Total.Travel.BusinessLogic;
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

        //[Authorize(Roles = "Cliente")]
        [AllowAnonymous]
        [HttpGet("List")]
        public IActionResult List()
        {
            try
            {
                var list = _restaurantService.ListRestaurants();
                return Ok(list);
            }
            catch (Exception)
            {

                var data = new ServiceResult();
                return Ok(data.Error());
            }
            
        }
        [HttpPost("Insert")]
        public IActionResult Insert([FromForm]RestaurantesViewModel item)
        {
            try
            {
                var user = _mapper.Map<tbRestaurantes>(item);
                var result = _restaurantService.CreateRestaurants(user, item.File);
                return Ok(result);
            }
            catch (Exception)
            {

                var data = new ServiceResult();
                return Ok(data.Error());
            }
            
        }


        [HttpPut("Update")]
        public IActionResult Update(int id, [FromForm] RestaurantesViewModel items)
        {
            try
            {
                var item = _mapper.Map<tbRestaurantes>(items);
                var result = _restaurantService.UpdateRestaurants(id, item, items.File);
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
                var result = _restaurantService.DeleteRestaurants(id, Mod);
                return Ok(result);
            }
            catch (Exception)
            {

                var data = new ServiceResult();
                return Ok(data.Error());
            }
            

        }

        [Authorize(Roles = "Administrador, Moderador de Restaurante")]
        [HttpGet("Find")]
        public IActionResult Details(int Id)
        {
            try
            {
                var result = _restaurantService.FindRestaurants(Id);
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
