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
    [Authorize(Roles = "Administrador, Moderador de Hotel")]
    public class HotelsMenuController : Controller
    {
        private readonly HotelService _hotelService;
        private readonly IMapper _mapper;
        public HotelsMenuController(HotelService hotelService, IMapper mapper)
        {
            _hotelService = hotelService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet("List")]
        public IActionResult List()
        {
            var list = _hotelService.ListHotelsMenu();
            return Ok(list);
        }

        [AllowAnonymous]
        [HttpPost("Insert")]
        public IActionResult Insert([FromForm] HotelesMenusViewModel hotelesMenusViewModel)
        {
            var items = _mapper.Map<tbHotelesMenus>(hotelesMenusViewModel);
            var result = _hotelService.CreateHotelsMenu(items, hotelesMenusViewModel.File);
            return Ok(result);
        }

        [HttpPut("Update")]
        public IActionResult Update(int id,[FromForm] HotelesMenusViewModel hotelesMenusViewModel)
        {

            var item = _mapper.Map<tbHotelesMenus>(hotelesMenusViewModel);
            var result = _hotelService.UpdateHotelsMenu(id, item, hotelesMenusViewModel.File);
            return Ok(result);

        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id, int Mod)
        {
            var result = _hotelService.DeleteHotelsMenu(id, Mod);
            return Ok(result);

        }

        [HttpGet("Find")]
        public IActionResult Details(int Id)
        {

            var result = _hotelService.FindHotelsMenu(Id);
            return Ok(result);
        }
    }
}
