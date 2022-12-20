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
    public class TransportsTest
    {
        private TransportService _transportService;
        private static IMapper _mapper;

        [Test]
        public void TransportsList()
        {
            TransportsController transport = new TransportsController(_transportService, _mapper);
            var result = transport.List();
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IActionResult>(result);
        }

        [Test]
        public void TransportsDetails()
        {
            int id = 2;
            TransportsController transport = new TransportsController(_transportService, _mapper);
            var result = transport.Details(id);
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IActionResult>(result);
        }

        [Test]
        public void TransportsInsert()
        {
            TransportesViewModel transportesViewModel = new TransportesViewModel();
            TransportsController transport = new TransportsController(_transportService, _mapper);
            var result = transport.Insert(transportesViewModel);
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IActionResult>(result);
        }

        [Test]
        public void TransportsUpdate()
        {
            int id = 2;
            TransportesViewModel items = new TransportesViewModel();
            TransportsController transport = new TransportsController(_transportService, _mapper);
            var result = transport.Update(id, items);
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IActionResult>(result);
        }

        [Test]
        public void TransportsDelete()
        {
            int id = 2;
            int Mod = 1;
            TransportsController transport = new TransportsController(_transportService, _mapper);
            var result = transport.Delete(id, Mod);
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IActionResult>(result);
        }

        
    }
}
