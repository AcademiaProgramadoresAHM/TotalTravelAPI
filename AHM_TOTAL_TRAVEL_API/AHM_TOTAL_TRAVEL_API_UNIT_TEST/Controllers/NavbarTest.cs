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
    class NavbarTest
    {
        private AccessService _accessService;
        private static IMapper _mapper;
        [Test]
        public void NavbarList()
        {
            NavbarController navbarController = new NavbarController(_accessService, _mapper);
            var result = navbarController.List();
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IActionResult>(result);
        }
        [Test]
        public void NavbarDetails()
        {
            int id = 2;
            NavbarController navbarController = new NavbarController(_accessService, _mapper);
            var result = navbarController.Details(id);
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IActionResult>(result);
        }
        [Test]
        public void NavbarInsert()
        {
            NavbarViewModel navbarViewModel = new NavbarViewModel();
            NavbarController navbarController = new NavbarController(_accessService, _mapper);
            var result = navbarController.Insert(navbarViewModel);
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IActionResult>(result);
        }
        [Test]
        public void NavbarUpdate()
        {
            int id = 2;
            NavbarViewModel navbarViewModel = new NavbarViewModel();
            NavbarController navbarController = new NavbarController(_accessService, _mapper);
            var result = navbarController.Update(id, navbarViewModel);
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IActionResult>(result);
        }

        [Test]
        public void NavbarDelete()
        {
            int id = 2;
            int Mod = 1;
            NavbarController navbarController = new NavbarController(_accessService, _mapper);
            var result = navbarController.Delete(id, Mod);
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IActionResult>(result);
        }
    }
}
