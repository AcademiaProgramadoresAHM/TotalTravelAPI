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

    public class RoomsPackagesTest
    {
        private SaleService  _saleService;
        private static IMapper _mapper;

        [Test]
        public void RoomsPackagesList()
        {
            RoomsPackagesController roomsPackagesController = new RoomsPackagesController(_saleService, _mapper);
            var result = roomsPackagesController.List();
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IActionResult>(result);
        }

        [Test]
        public void RoomsPackagesDetails()
        {
            int id = 2;
            RoomsPackagesController roomsPackagesController = new RoomsPackagesController(_saleService, _mapper);
            var result = roomsPackagesController.Find(id);
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IActionResult>(result);
        }

        [Test]
        public void RoomsPackagesInsert()
        {
            RoomsPackagesController roomsPackagesController = new RoomsPackagesController(_saleService, _mapper);
            PaquetesHabitacionesViewModel paquetesHabitacionesViewModel = new PaquetesHabitacionesViewModel();
            var result = roomsPackagesController.Insert(paquetesHabitacionesViewModel);
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IActionResult>(result);
        }

        [Test]
        public void RoomsPackagesUpdate()
        {
            int id = 2;
            RoomsPackagesController roomsPackagesController = new RoomsPackagesController(_saleService, _mapper);
            PaquetesHabitacionesViewModel paquetesHabitacionesViewModel = new PaquetesHabitacionesViewModel();
            var result = roomsPackagesController.Update(id, paquetesHabitacionesViewModel);
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IActionResult>(result);
        }

        [Test]
        public void RoomsPackagesDelete()
        {
            int id = 2;
            int Mod = 1;
            RoomsPackagesController roomsPackagesController = new RoomsPackagesController(_saleService, _mapper);
            var result = roomsPackagesController.Delete(id, Mod);
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IActionResult>(result);
        }
    }
}
