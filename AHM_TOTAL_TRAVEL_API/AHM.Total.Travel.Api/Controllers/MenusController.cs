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
    [Authorize(Roles = "Administrador")]
    public class MenusController : Controller
    {
        private readonly RestaurantService _restaurantService;
        private readonly IMapper _mapper;
        public MenusController(RestaurantService restaurantService, IMapper mapper)
        {
            _restaurantService = restaurantService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet("List")]
        public IActionResult List()
        {
            var list = _restaurantService.ListMenus();
            return Ok(list);

        }
        [HttpPost("Insert")]
        public IActionResult Insert([FromForm]MenusViewModel menusViewModel)
        {
            IFormFile file;
            if (menusViewModel.File != null)
            {
                file = menusViewModel.File;
            }
            else
            {
                string pathdefault = Path.GetFullPath("ImagesAPI/Assets_System_Photos/ImageDefault.jpg");
                byte[] byteFile = System.IO.File.ReadAllBytes(pathdefault);

                var stream = new MemoryStream(byteFile);
                file = new FormFile(stream, 0, stream.Length, "ImageDefault", "ImageDefault.jpg");
            }
            var items = _mapper.Map<tbMenus>(menusViewModel);
            var result = _restaurantService.CreateMenus(items, file);
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
