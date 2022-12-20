using AHM.Total.Travel.Api.Controllers;
using AHM.Total.Travel.Api.Extensions;
using AHM.Total.Travel.BusinessLogic;
using AHM.Total.Travel.Common.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AHM.Total.Travel.BusinessLogic.Services;

namespace AHM_TOTAL_TRAVEL_API_UNIT_TEST.Controllers
{
 
    [TestClass]
    public class CitiesTest
    {
        private GeneralService _generalService;
        private static IMapper _mapper;

        public CitiesTest()
        {
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new MappingProfileExtensions());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }
        }
        protected Mock<IMapper> map = new Mock<IMapper>();
        CitiesController _cities;

        [TestInitialize]
        public void Initalize()
        {
            _cities = new CitiesController(_generalService, _mapper);
        }

        [TestMethod]
        public void CitiesList()
        {
            var result = _cities.List();
            //int Code = (int)result.StatusCode;

            Assert.IsInstanceOfType<IActionResult>(result);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CitiesCreate()
        {
            var data = new CiudadesViewModel();
            var result = _cities.Insert(data);
            //int Code = (int)result.StatusCode;

            Assert.IsInstanceOfType<IActionResult>(result);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CitiesUpdate()
        {
            int id = 0;
            var data = new CiudadesViewModel();
            var result = _cities.Update(id, data);
            //int Code = (int)result.StatusCode;

            Assert.IsInstanceOfType<IActionResult>(result);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CitiesDetele()
        {
            int id = 0;
            int mod = 0;
            var result = _cities.Delete(id, mod);
            //int Code = (int)result.StatusCode;
            //ServiceResult Value = (ServiceResult)result.Value;
            Assert.IsInstanceOfType<IActionResult>(result);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CitiesDetails()
        {
            int id = 0;
            var result = _cities.Details(id);
            //int Code = (int)result.StatusCode;
            //ServiceResult Value = (ServiceResult)result.Value;
            Assert.IsInstanceOfType<IActionResult>(result);
            Assert.IsNotNull(result);
        }
    }
}
