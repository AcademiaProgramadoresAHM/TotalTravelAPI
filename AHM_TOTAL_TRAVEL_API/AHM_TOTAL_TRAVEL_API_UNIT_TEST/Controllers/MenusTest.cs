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
    public class MenusTest
    {
        private RestaurantService _restaurantService;
        private static IMapper _mapper;
        [Test]
        public void MenusList()
        {
            MenusController MenuController = new MenusController(_restaurantService, _mapper);
            var result = MenuController.List();
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IActionResult>(result);
        }
        [Test]
        public void MenusDetails()
        {
            int id = 2;
            MenusController MenuController = new MenusController(_restaurantService, _mapper);
            var result = MenuController.Details(id);
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IActionResult>(result);
        }
        [Test]
        public void MenusInsert()
        {
            MenusViewModel MenuViewModel = new MenusViewModel();
            MenusController MenuController = new MenusController(_restaurantService, _mapper);
            var result = MenuController.Insert(MenuViewModel);
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IActionResult>(result);
        }
        [Test]
        public void MenusUpdate()
        {
            int id = 2;
            MenusViewModel MenuViewModel = new MenusViewModel();
            MenusController MenuController = new MenusController(_restaurantService, _mapper);
            var result = MenuController.Update(id, MenuViewModel);
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IActionResult>(result);
        }

        [Test]
        public void MenusDelete()
        {
            int id = 2;
            int Mod = 1;
            MenusController MenuController = new MenusController(_restaurantService, _mapper);
            var result = MenuController.Delete(id, Mod);
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IActionResult>(result);
        }
    }
}
