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
    public class TypeTransportTest
    {
        private TransportService _transportService;
        private static IMapper _mapper;

        [Test]
        public void TypeTransportList()
        {
            TypesTransportController typesTransportController = new TypesTransportController(_transportService, _mapper);
            var result = typesTransportController.List();
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IActionResult>(result);
        }

        [Test]
        public void TypeTransportDetails()
        {
            int id = 2;
            TypesTransportController typesTransportController = new TypesTransportController(_transportService, _mapper);
            var result = typesTransportController.Details(id);
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IActionResult>(result);
        }

        [Test]
        public void TypeTransportInsert()
        {
            TiposTransportesViewModel tiposTransportesViewModel = new TiposTransportesViewModel();
            TypesTransportController typesTransportController = new TypesTransportController(_transportService, _mapper);
            var result = typesTransportController.Insert(tiposTransportesViewModel);
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IActionResult>(result);
        }

        [Test]
        public void TypeTransportUpdate()
        {
            int id = 2;
            TiposTransportesViewModel tiposTransportesViewModel = new TiposTransportesViewModel();
            TypesTransportController typesTransportController = new TypesTransportController(_transportService, _mapper);
            var result = typesTransportController.Update(id, tiposTransportesViewModel);
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IActionResult>(result);
        }

        [Test]
        public void TypeTransportDelete()
        {
            int id = 2;
            int Mod = 1;
            TypesTransportController typesTransportController = new TypesTransportController(_transportService, _mapper);
            var result = typesTransportController.Delete(id, Mod);
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IActionResult>(result);
        }
    }
}
