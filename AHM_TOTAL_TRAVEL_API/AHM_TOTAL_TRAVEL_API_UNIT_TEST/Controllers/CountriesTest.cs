using AHM.Total.Travel.Api.Controllers;
using AHM.Total.Travel.BusinessLogic.Services;
using AHM.Total.Travel.Common.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Assert = NUnit.Framework.Assert;


namespace AHM_TOTAL_TRAVEL_API_UNIT_TEST.Controllers
{
    //[TestClass]
    [TestFixture]
    public class CountriesTest
    {
        private GeneralService _generalService;
        private static IMapper _mapper;

        [Test]
        public void CountriesList()
        {
            CountriesController _countriesController = new CountriesController(_generalService, _mapper);
            var result = _countriesController.List();
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IActionResult>(result);
        }

        [Test]
        public void CountriesDetails()
        {
            int id = 2;
            CountriesController _countriesController = new CountriesController(_generalService, _mapper);
            var result = _countriesController.Details(id);
            Assert.IsInstanceOf<IActionResult>(result);
            Assert.IsNotNull(result);
        }

        [Test]
        public void CountriesInsert()
        {
            PaisesViewModel paisViewModel = new PaisesViewModel();
            CountriesController _countriesController = new CountriesController(_generalService, _mapper);
            var result = _countriesController.Insert(paisViewModel);
            Assert.IsInstanceOf<IActionResult>(result);
            Assert.IsNotNull(result);
        }

        [Test]
        public void CountriesUpdate()
        {
            int id = 2;
            PaisesViewModel paisViewModel = new PaisesViewModel();
            CountriesController _countriesController = new CountriesController(_generalService, _mapper);
            var result = _countriesController.Update(id, paisViewModel);
            Assert.IsInstanceOf<IActionResult>(result);
            Assert.IsNotNull(result);
        }

        [Test]
        public void CountriesDelete()
        {
            int id = 2;
            int Mod = 1;
            CountriesController _countriesController = new CountriesController(_generalService, _mapper);
            var result = _countriesController.Delete(id, Mod);
            Assert.IsInstanceOf<IActionResult>(result);
            Assert.IsNotNull(result);

        }

    }
}
