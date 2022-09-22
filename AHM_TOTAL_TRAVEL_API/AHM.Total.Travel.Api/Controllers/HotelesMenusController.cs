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
    public class HotelesMenusController : Controller
    {
        private readonly HotelService _hotelService;
        private readonly IMapper _mapper;
        public HotelesMenusController(HotelService hotelService, IMapper mapper)
        {
            _hotelService = hotelService;
            _mapper = mapper;
        }

        [HttpGet("List")]
        public IActionResult List()
        {
            var list = _hotelService.ListHotelesMenus();
            return Ok(list);
        }

        [HttpPut("Update")]
        public IActionResult Update(int id, HotelesMenusViewModel items)
        {

            var item = _mapper.Map<tbHotelesMenus>(items);
            var result = _hotelService.UpdateHotelesMenus(id, item);
            return Ok(result);

        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id, int Mod)
        {
            var result = _hotelService.DeleteHotelesMenus(id, Mod);
            return Ok(result);

        }

        [HttpGet("Find")]
        public IActionResult Details(int Id)
        {

            var result = _hotelService.FindHotelesMenus(Id);
            return Ok(result);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
