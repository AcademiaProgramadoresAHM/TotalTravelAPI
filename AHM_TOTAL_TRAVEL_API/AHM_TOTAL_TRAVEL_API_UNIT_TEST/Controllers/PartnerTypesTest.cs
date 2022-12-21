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
    public class PartnerTypesTest
    {
        private GeneralService _generalService;
        private static IMapper _mapper;
        [Test]
        public void PartnerTypesList()
        {
            PartnerTypeController partnertypeController = new PartnerTypeController(_generalService, _mapper);
            var result = partnertypeController.List();
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IActionResult>(result);
        }
        [Test]
        public void PartnerTypesDetails()
        {
            int id = 2;
            PartnerTypeController partnertypeController = new PartnerTypeController(_generalService, _mapper);
            var result = partnertypeController.Details(id);
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IActionResult>(result);
        }
        [Test]
        public void PartnerTypesInsert()
        {
            TiposPartnersViewModel tipospartnersViewModel = new TiposPartnersViewModel();
            PartnerTypeController partnertypeController = new PartnerTypeController(_generalService, _mapper);
            var result = partnertypeController.Insert(tipospartnersViewModel);
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IActionResult>(result);
        }
        [Test]
        public void PartnerTypesUpdate()
        {
            int id = 2;
            TiposPartnersViewModel tipospartnersViewModel = new TiposPartnersViewModel();
            PartnerTypeController partnertypeController = new PartnerTypeController(_generalService, _mapper);
            var result = partnertypeController.Update(id, tipospartnersViewModel);
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IActionResult>(result);
        }

        [Test]
        public void PartnerTypesDelete()
        {
            int id = 2;
            int Mod = 1;
            PartnerTypeController partnertypeController = new PartnerTypeController(_generalService, _mapper);
            var result = partnertypeController.Delete(id, Mod);
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IActionResult>(result);
        }
    }
}
