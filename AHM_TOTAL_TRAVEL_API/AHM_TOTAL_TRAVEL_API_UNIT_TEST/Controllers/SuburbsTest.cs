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
    public class SuburbsTest
    {
        private GeneralService _generalService;
        private static IMapper _mapper;

        [Test]
        public void SuburbsList()
        {
            SuburbsController suburbsController = new SuburbsController(_generalService, _mapper);
            var result = suburbsController.List();
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IActionResult>(result);
        }

        [Test]
        public void SuburbsDetails()
        {
            int id = 2;
            SuburbsController suburbsController = new SuburbsController(_generalService, _mapper);
            var result = suburbsController.Details(id);
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IActionResult>(result);
        }

        [Test]
        public void SuburbsInsert()
        {
            SuburbsController suburbsController = new SuburbsController(_generalService, _mapper);
            ColoniasViewModel coloniasViewModel = new ColoniasViewModel();
            var result = suburbsController.Insert(coloniasViewModel);
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IActionResult>(result);
        }

        [Test]
        public void SuburbsUpdate()
        {
            int id = 2;
            SuburbsController suburbsController = new SuburbsController(_generalService, _mapper);
            ColoniasViewModel coloniasViewModel = new ColoniasViewModel();
            var result = suburbsController.Update(id, coloniasViewModel);
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IActionResult>(result);
        }

        [Test]
        public void SuburbsDelete()
        {
            int id = 2;
            int Mod = 1;
            SuburbsController suburbsController = new SuburbsController(_generalService, _mapper);
            var result = suburbsController.Delete(id, Mod);
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IActionResult>(result);
        }
    }
}
    

