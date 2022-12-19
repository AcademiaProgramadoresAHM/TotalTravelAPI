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
    public class RestaurantsTest
    {
        private RestaurantService _restaurantService;
        private static IMapper _mapper;

        public RestaurantsTest()
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
        RestaurantsController Restaurants;

        [TestInitialize]
        public void Initalize()
        {
            Restaurants = new RestaurantsController(_restaurantService, _mapper);
        }
        [TestMethod]
        public void ReservationTransportationList()
        {
            var result = Restaurants.List();
            //int Code = (int)result.StatusCode;

            Assert.IsInstanceOfType<IActionResult>(result);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ReservationTransportationCreate()
        {
            var data = new RestaurantesViewModel();
            var result = Restaurants.Insert(data);
            //int Code = (int)result.StatusCode;

            Assert.IsInstanceOfType<IActionResult>(result);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ReservationTransportationUpdate()
        {
            int id = 0;
            var data = new RestaurantesViewModel();
            var result = Restaurants.Update(id, data);
            //int Code = (int)result.StatusCode;

            Assert.IsInstanceOfType<IActionResult>(result);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ReservationTransportationDetele()
        {
            int id = 0;
            int mod = 0;
            var result = Restaurants.Delete(id, mod);
            //int Code = (int)result.StatusCode;
            //ServiceResult Value = (ServiceResult)result.Value;
            Assert.IsInstanceOfType<IActionResult>(result);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ReservationTransportationDetails()
        {
            int id = 0;
            var result = Restaurants.Details(id);
            //int Code = (int)result.StatusCode;
            //ServiceResult Value = (ServiceResult)result.Value;
            Assert.IsInstanceOfType<IActionResult>(result);
            Assert.IsNotNull(result);
        }
    }
}
