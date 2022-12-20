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
    public class DetailsTransportationTest
    {
        private TransportService _transportService;
        private static IMapper _mapper;

        public DetailsTransportationTest()
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
        DetailsTransportationController _DetailsTransportation;

        [TestInitialize]
        public void Initalize()
        {
            _DetailsTransportation = new DetailsTransportationController(_transportService, _mapper);
        }

        [TestMethod]
        public void DetailsTransportationList()
        {
            var result = _DetailsTransportation.List();
            //int Code = (int)result.StatusCode;

            Assert.IsInstanceOfType<IActionResult>(result);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void DetailsTransportationCreate()
        {
            var data = new DetallesTransportesViewModel();
            var result = _DetailsTransportation.Insert(data);
            //int Code = (int)result.StatusCode;

            Assert.IsInstanceOfType<IActionResult>(result);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void DetailsTransportationUpdate()
        {
            int id = 0;
            var data = new DetallesTransportesViewModel();
            var result = _DetailsTransportation.Update(id, data);
            //int Code = (int)result.StatusCode;

            Assert.IsInstanceOfType<IActionResult>(result);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void DetailsTransportationDetele()
        {
            int id = 0;
            int mod = 0;
            var result = _DetailsTransportation.Delete(id, mod);
            //int Code = (int)result.StatusCode;
            //ServiceResult Value = (ServiceResult)result.Value;
            Assert.IsInstanceOfType<IActionResult>(result);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void DetailsTransportationDetails()
        {
            int id = 0;
            var result = _DetailsTransportation.Details(id);
            //int Code = (int)result.StatusCode;
            //ServiceResult Value = (ServiceResult)result.Value;
            Assert.IsInstanceOfType<IActionResult>(result);
            Assert.IsNotNull(result);
        }
    }
}
