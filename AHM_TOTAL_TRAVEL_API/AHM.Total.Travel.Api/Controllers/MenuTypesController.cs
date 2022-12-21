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
    [Authorize(Roles = "Administrador, Moderador de Restaurante")]
    public class MenuTypesController : Controller
    {
        private readonly RestaurantService _restaurantService;
        private readonly IMapper _mapper;
        public MenuTypesController(RestaurantService restaurantService, IMapper mapper)
        {
            _restaurantService = restaurantService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet("List")]
        public IActionResult List()
        {
            try
            {
                var list = _restaurantService.ListTipoMenus();
                return Ok(list);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("Insert")]
        public IActionResult Insert(TipoMenusViewModel tipoMenusViewModel)
        {
            try
            {
                var items = _mapper.Map<tbTipoMenus>(tipoMenusViewModel);
                var result = _restaurantService.CreateTipoMenus(items);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("Update")]
        public IActionResult Update(int id, TipoMenusViewModel tipoMenusViewModel)
        {
            try
            {
                var item = _mapper.Map<tbTipoMenus>(tipoMenusViewModel);
                var result = _restaurantService.UpdateTipoMenus(id, item);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id, int Mod)
        {
            try
            {
                var result = _restaurantService.DeleteTipoMenus(id, Mod);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("Find")]
        public IActionResult Details(int Id)
        {
            try
            {
                var result = _restaurantService.FindTipoMenus(Id);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
