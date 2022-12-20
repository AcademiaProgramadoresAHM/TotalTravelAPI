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
    public class ReservationRestaurantTest
    {
        private ReservationService _reservationService;
        private static IMapper _mapper;

        public ReservationRestaurantTest()
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
        ReservationRestaurantController reservationRestaurant;

        [TestInitialize]
        public void Initalize()
        {
            reservationRestaurant = new ReservationRestaurantController(_reservationService, _mapper);
        }
        [TestMethod]
        public void ReservationRestaurantList()
        {
            var result = reservationRestaurant.List();
            //int Code = (int)result.StatusCode;

            Assert.IsInstanceOfType<IActionResult>(result);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ReservationRestaurantCreate()
        {
            var data = new ReservacionRestaurantesViewModel();
            var result = reservationRestaurant.Insert(data);
            //int Code = (int)result.StatusCode;

            Assert.IsInstanceOfType<IActionResult>(result);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ReservationRestaurantUpdate()
        {
            int id = 0;
            var data = new ReservacionRestaurantesViewModel();
            var result = reservationRestaurant.Update(id, data);
            //int Code = (int)result.StatusCode;

            Assert.IsInstanceOfType<IActionResult>(result);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ReservationRestaurantDetele()
        {
            int id = 0;
            int mod = 0;
            var result = reservationRestaurant.Delete(id, mod);
            //int Code = (int)result.StatusCode;
            //ServiceResult Value = (ServiceResult)result.Value;
            Assert.IsInstanceOfType<IActionResult>(result);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ReservationRestaurantDetails()
        {
            int id = 0;
            var result = reservationRestaurant.Details(id);
            //int Code = (int)result.StatusCode;
            //ServiceResult Value = (ServiceResult)result.Value;
            Assert.IsInstanceOfType<IActionResult>(result);
            Assert.IsNotNull(result);
        }
    }
}
