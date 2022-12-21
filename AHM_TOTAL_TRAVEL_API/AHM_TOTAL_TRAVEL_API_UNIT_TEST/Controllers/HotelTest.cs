using AHM.Total.Travel.Api.Controllers;
using AHM.Total.Travel.BusinessLogic.Services;
using AHM.Total.Travel.Common.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace AHM_TOTAL_TRAVEL_API_UNIT_TEST.Controllers
{
    [TestFixture]
    public class HotelTest
    {
        private HotelService _hotelService;
        private static IMapper _mapper;

        [Test]
        public void HotelsList()
        {
            HotelsController hotelsController = new HotelsController(_hotelService, _mapper);
            var result = hotelsController.List();
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IActionResult>(result);
        }
        [Test]
        public void HotelsDetails()
        {
            int id = 2;
            HotelsController hotelsController = new HotelsController(_hotelService, _mapper);
            var result = hotelsController.Details(id);
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IActionResult>(result);
        }
        [Test]
        public void HotelsInsert()
        {
            HotelesViewModel hotelesViewModel = new HotelesViewModel();
            HotelsController hotelsController = new HotelsController(_hotelService, _mapper);
            var result = hotelsController.Insert(hotelesViewModel);
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IActionResult>(result);
        }
        [Test]
        public void HotelsUpdate()
        {
            int id = 2;
            HotelesViewModel hotelesViewModel = new HotelesViewModel();
            HotelsController hotelsController = new HotelsController(_hotelService, _mapper);
            var result = hotelsController.Update(id, hotelesViewModel);
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IActionResult>(result);
        }

        [Test]
        public void HotelsDelete()
        {
            int id = 2;
            int Mod = 1;
            HotelsController hotelsController = new HotelsController(_hotelService, _mapper);
            var result = hotelsController.Delete(id, Mod);
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IActionResult>(result);
        }
    }
}
