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
    public class ReservationHotelsTest
    {
        private ReservationService _reservationService;
        private static IMapper _mapper;

        public ReservationHotelsTest()
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
        ReservationHotelsController reservationHotels;

        [TestInitialize]
        public void Initalize()
        {
            reservationHotels = new ReservationHotelsController(_reservationService, _mapper);
        }

        [TestMethod]
        public void ReservationHotelsList()
        {
            var result = reservationHotels.List();
            //int Code = (int)result.StatusCode;

            Assert.IsInstanceOfType<IActionResult>(result);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ReservationHotelsCreate()
        {
            var data = new ReservacionesHotelesViewModel();
            var result = reservationHotels.Insert(data);
            //int Code = (int)result.StatusCode;

            Assert.IsInstanceOfType<IActionResult>(result);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ReservationHotelsUpdate()
        {
            int id = 0;
            var data = new ReservacionesHotelesViewModel();
            var result = reservationHotels.Update(id, data);
            //int Code = (int)result.StatusCode;

            Assert.IsInstanceOfType<IActionResult>(result);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ReservationHotelsDetele()
        {
            int id = 0;
            int mod = 0;
            var result = reservationHotels.Delete(id, mod);
            //int Code = (int)result.StatusCode;
            //ServiceResult Value = (ServiceResult)result.Value;
            Assert.IsInstanceOfType<IActionResult>(result);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ReservationHotelsDetails()
        {
            int id = 0;
            var result = reservationHotels.Find(id);
            //int Code = (int)result.StatusCode;
            //ServiceResult Value = (ServiceResult)result.Value;
            Assert.IsInstanceOfType<IActionResult>(result);
            Assert.IsNotNull(result);
        }
    }
}
