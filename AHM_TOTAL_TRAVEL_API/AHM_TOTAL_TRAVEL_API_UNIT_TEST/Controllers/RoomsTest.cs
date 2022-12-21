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
    public class RoomsTest
    {
        private HotelService _hotelService ;
        private static IMapper _mapper;

        [Test]
        public void RoomsList()
        {
            RoomsController  roomsController = new RoomsController(_hotelService, _mapper);
            var result = roomsController.List();
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IActionResult>(result);
        }

        [Test]
        public void RoomsDetails()
        {
            int id = 2;
            RoomsController roomsController = new RoomsController(_hotelService, _mapper);
            var result = roomsController.Details(id);
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IActionResult>(result);
        }

        [Test]
        public void RoomsInsert()
        {
            RoomsController roomsController = new RoomsController(_hotelService, _mapper);
            HabitacionesViewModel  habitacionesViewModel = new HabitacionesViewModel();
            var result = roomsController.Insert(habitacionesViewModel);
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IActionResult>(result);
        }

        [Test]
        public void RoomsUpdate()
        {
            int id = 2;
            RoomsController roomsController = new RoomsController(_hotelService, _mapper);
            HabitacionesViewModel habitacionesViewModel = new HabitacionesViewModel();
            var result = roomsController.Update(id, habitacionesViewModel);
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IActionResult>(result);
        }

        [Test]
        public void RoomsDelete()
        {
            int id = 2;
            int Mod = 1;
            RoomsController roomsController = new RoomsController(_hotelService, _mapper);
            var result = roomsController.Delete(id, Mod);
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IActionResult>(result);
        }
    }
}
