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

    public class ScheduleTransportationsTest
    {
        private TransportService  _transportService;
        private static IMapper _mapper;

        [Test]
        public void ScheduleTransportationList()
        {
            ScheduleTransportationController scheduleTransportationController = new ScheduleTransportationController(_transportService, _mapper);
            var result = scheduleTransportationController.List();
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IActionResult>(result);
        }

        [Test]
        public void ScheduleTransportationDetails()
        {
            int id = 2;
            ScheduleTransportationController scheduleTransportationController = new ScheduleTransportationController(_transportService, _mapper);
            var result = scheduleTransportationController.Details(id);
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IActionResult>(result);
        }

        [Test]
        public void ScheduleTransportationInsert()
        {
            ScheduleTransportationController scheduleTransportationController = new ScheduleTransportationController(_transportService, _mapper);
            HorariosTransportesViewModel horariosTransportesViewModel = new HorariosTransportesViewModel();
            var result = scheduleTransportationController.Insert(horariosTransportesViewModel);
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IActionResult>(result);
        }

        [Test]
        public void ScheduleTransportationUpdate()
        {
            int id = 2;
            ScheduleTransportationController scheduleTransportationController = new ScheduleTransportationController(_transportService, _mapper);
            HorariosTransportesViewModel horariosTransportesViewModel = new HorariosTransportesViewModel();
            var result = scheduleTransportationController.Update(id, horariosTransportesViewModel);
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IActionResult>(result);
        }

        [Test]
        public void ScheduleTransportationDelete()
        {
            int id = 2;
            int Mod = 1;
            ScheduleTransportationController scheduleTransportationController = new ScheduleTransportationController(_transportService, _mapper);
            var result = scheduleTransportationController.Delete(id, Mod);
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IActionResult>(result);
        }
    }
}
