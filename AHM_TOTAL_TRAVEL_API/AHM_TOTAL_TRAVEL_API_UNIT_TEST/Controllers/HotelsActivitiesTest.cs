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
    public class HotelsActivitiesTest
    {
        private HotelService _hotelService;
        private static IMapper _mapper;
        [Test]
        public void HotelsActivitiesList()
        {
            HotelsActivitiesController hotelactivitiesController = new HotelsActivitiesController(_hotelService, _mapper);
            var result = hotelactivitiesController.List();
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IActionResult>(result);
        }
        [Test]
        public void HotelsActivitiesDetails()
        {
            int id = 2;
            HotelsActivitiesController hotelactivitiesController = new HotelsActivitiesController(_hotelService, _mapper);
            var result = hotelactivitiesController.Details(id);
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IActionResult>(result);
        }
        [Test]
        public void HotelsActivitiesInsert()
        {
            HotelesActividadesViewModel hotelesactividadesViewModel = new HotelesActividadesViewModel();
            HotelsActivitiesController hotelactivitiesController = new HotelsActivitiesController(_hotelService, _mapper);
            var result = hotelactivitiesController.Insert(hotelesactividadesViewModel);
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IActionResult>(result);
        }
        [Test]
        public void HotelsActivitiesUpdate()
        {
            int id = 2;
            HotelesActividadesViewModel hotelesactividadesViewModel = new HotelesActividadesViewModel();
            HotelsActivitiesController hotelactivitiesController = new HotelsActivitiesController(_hotelService, _mapper);
            var result = hotelactivitiesController.Update(id, hotelesactividadesViewModel);
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IActionResult>(result);
        }

        [Test]
        public void HotelsActivitiesDelete()
        {
            int id = 2;
            int Mod = 1;
            HotelsActivitiesController hotelactivitiesController = new HotelsActivitiesController(_hotelService, _mapper);
            var result = hotelactivitiesController.Delete(id, Mod);
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IActionResult>(result);
        }
    }
}
