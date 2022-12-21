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
    public class MenuTypesTest
    {
        private RestaurantService _restaurantService;
        private static IMapper _mapper;
        [Test]
        public void MenuTypesList()
        {
            MenuTypesController menutypesController = new MenuTypesController(_restaurantService, _mapper);
            var result = menutypesController.List();
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IActionResult>(result);
        }
        [Test]
        public void MenuTypesDetails()
        {
            int id = 2;
            MenuTypesController menutypesController = new MenuTypesController(_restaurantService, _mapper);
            var result = menutypesController.Details(id);
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IActionResult>(result);
        }
        [Test]
        public void MenuTypesInsert()
        {
            TipoMenusViewModel tipomenuViewModel = new TipoMenusViewModel();
            MenuTypesController menutypesController = new MenuTypesController(_restaurantService, _mapper);
            var result = menutypesController.Insert(tipomenuViewModel);
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IActionResult>(result);
        }
        [Test]
        public void MenuTypesUpdate()
        {
            int id = 2;
            TipoMenusViewModel tipomenuViewModel = new TipoMenusViewModel();
            MenuTypesController menutypesController = new MenuTypesController(_restaurantService, _mapper);
            var result = menutypesController.Update(id, tipomenuViewModel);
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IActionResult>(result);
        }

        [Test]
        public void MenuTypesDelete()
        {
            int id = 2;
            int Mod = 1;
            MenuTypesController menutypesController = new MenuTypesController(_restaurantService, _mapper);
            var result = menutypesController.Delete(id, Mod);
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IActionResult>(result);
        }
    }
}
