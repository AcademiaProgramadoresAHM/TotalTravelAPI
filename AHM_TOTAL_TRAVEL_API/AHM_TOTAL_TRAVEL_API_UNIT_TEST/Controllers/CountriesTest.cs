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
    class CountriesTest
    {
        private GeneralService  GeneralService;
        private static IMapper _mapper;

        [Test]
        public void CountriesList()
        {
            CountriesController _countriesDetails = new CountriesController(GeneralService, _mapper);
            var result = _countriesDetails.List();
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IActionResult>(result);
        }

        [Test]
        public void CountriesDetails()
        {
            int id = 2;
            CountriesController _countriesDetails = new CountriesController(GeneralService, _mapper);
            var result = _countriesDetails.Details(id);
            Assert.IsInstanceOf<IActionResult>(result);
            Assert.IsNotNull(result);
        }

        [Test]
        public void CountriesInsert()
        {
            PaisesViewModel paisesViewModel = new PaisesViewModel();
            CountriesController _countriesDetails = new CountriesController(GeneralService, _mapper);
            var result = _countriesDetails.Insert(paisesViewModel);
            Assert.IsInstanceOf<IActionResult>(result);
            Assert.IsNotNull(result);
        }

        [Test]
        public void CountriesUpdate()
        {
            int id = 2;
            PaisesViewModel paisesViewModel = new PaisesViewModel();
            CountriesController _countriesDetails = new CountriesController(GeneralService, _mapper);
            var result = _countriesDetails.Update(id, paisesViewModel);
            Assert.IsInstanceOf<IActionResult>(result);
            Assert.IsNotNull(result);
        }

        [Test]
        public void CountriesDelete()
        {
            int id = 2;
            int Mod = 1;
            CountriesController _countriesDetails = new CountriesController(GeneralService, _mapper);
            var result = _countriesDetails.Delete(id, Mod);
            Assert.IsInstanceOf<IActionResult>(result);
            Assert.IsNotNull(result);

        }
    }
}
