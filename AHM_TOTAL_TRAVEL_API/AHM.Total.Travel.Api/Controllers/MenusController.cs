using AHM.Total.Travel.BusinessLogic.Services;
using AHM.Total.Travel.Common.Models;
using AHM.Total.Travel.Entities.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace AHM.Total.Travel.Api.Controllers
{
    [ApiController]
    [Route("API/[controller]")]
    [Authorize(Roles = "Administrador, Moderador de Restaurante")]
    public class MenusController : Controller
    {
        private readonly RestaurantService _restaurantService;
        private readonly IMapper _mapper;
        public MenusController(RestaurantService restaurantService, IMapper mapper)
        {
            _restaurantService = restaurantService;
            _mapper = mapper;
        }

        //[Authorize(Roles = "Cliente")]
        [AllowAnonymous]
        [HttpGet("List")]
        public IActionResult List()
        {
            var list = _restaurantService.ListMenus();
            return Ok(list);

        }
        
        [HttpPost("Insert")]
        public IActionResult Insert([FromForm]MenusViewModel item)
        {
            var menu = _mapper.Map<tbMenus>(item);
            var result = _restaurantService.CreateMenus(menu, item.File);
            return Ok(result);
        }


        [HttpPut("Update")]
        public IActionResult Update(int id, [FromForm] MenusViewModel items)
        {

            var item = _mapper.Map<tbMenus>(items);
            var result = _restaurantService.UpdateMenus(id, item, items.File);
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
