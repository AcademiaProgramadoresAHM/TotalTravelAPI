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
    public class DestinationsTransportationsTest
    {
        private TransportService _transportService;
        private static IMapper _mapper;
        [Test]
        public void DestinationsTransportationsList()
        {
            DestinationsTransportationsController destinationstransportationsController = new DestinationsTransportationsController(_transportService, _mapper);
            var result = destinationstransportationsController.List();
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IActionResult>(result);
        }
        [Test]
        public void DestinationsTransportationsDetails()
        {
            int id = 2;
            DestinationsTransportationsController destinationstransportationsController = new DestinationsTransportationsController(_transportService, _mapper);
            var result = destinationstransportationsController.Details(id);
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IActionResult>(result);
        }
        [Test]
        public void DestinationsTransportationsInsert()
        {
            DestinosTransporteViewModel destinostransporteViewModel = new DestinosTransporteViewModel();
            DestinationsTransportationsController destinationstransportationsController = new DestinationsTransportationsController(_transportService, _mapper);
            var result = destinationstransportationsController.Insert(destinostransporteViewModel);
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IActionResult>(result);
        }
        [Test]
        public void DestinationsTransportationsUpdate()
        {
            int id = 2;
            DestinosTransporteViewModel destinostransporteViewModel = new DestinosTransporteViewModel();
            DestinationsTransportationsController destinationstransportationsController = new DestinationsTransportationsController(_transportService, _mapper);
            var result = destinationstransportationsController.Update(id, destinostransporteViewModel);
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IActionResult>(result);
        }

        [Test]
        public void DestinationsTransportationsDelete()
        {
            int id = 2;
            int Mod = 1;
            DestinationsTransportationsController destinationstransportationsController = new DestinationsTransportationsController(_transportService, _mapper);
            var result = destinationstransportationsController.Delete(id, Mod);
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IActionResult>(result);
        }
    }
}
