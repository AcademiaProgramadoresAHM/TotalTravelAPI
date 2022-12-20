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
    public class TypeActivitiesTest
    {
        private ActivitiesService _activitiesService;
        private static IMapper _mapper;
        [Test]
        public void TypeActivitiesList()
        {
            TypeActivitiesController typeActivitiesController = new TypeActivitiesController(_activitiesService, _mapper);
            var result = typeActivitiesController.List();
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IActionResult>(result);
        }

        [Test]
        public void TypeActivitiesDetails()
        {
            int id = 2;
            TypeActivitiesController typeActivitiesController = new TypeActivitiesController(_activitiesService, _mapper);
            var result = typeActivitiesController.Details(id);
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IActionResult>(result);
        }

        [Test]
        public void TypeActivitiesInsert()
        {
            TiposActividadesViewModel tiposActividadesViewModel = new TiposActividadesViewModel();
            TypeActivitiesController typeActivitiesController = new TypeActivitiesController(_activitiesService, _mapper);
            var result = typeActivitiesController.Insert(tiposActividadesViewModel);
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IActionResult>(result);
        }

        [Test]
        public void TypeActivitiesUpdate()
        {
            int id = 2;
            TiposActividadesViewModel tiposActividadesViewModel = new TiposActividadesViewModel();
            TypeActivitiesController typeActivitiesController = new TypeActivitiesController(_activitiesService, _mapper);
            var result = typeActivitiesController.Update(id, tiposActividadesViewModel);
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IActionResult>(result);
        }

        [Test]
        public void TypeActivitiesDelete()
        {
            int id = 2;
            int Mod = 1;
            TypeActivitiesController typeActivitiesController = new TypeActivitiesController(_activitiesService, _mapper);
            var result = typeActivitiesController.Delete(id, Mod);
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IActionResult>(result);
        }
    }
}
