using AHM.Total.Travel.Api.Controllers;
using AHM.Total.Travel.BusinessLogic.Services;
using AHM.Total.Travel.Common.Models;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace AHM_TOTAL_TRAVEL_API_UNIT_TEST.Controllers
{
    [TestFixture]
    public class UsersTest
    {
        private AccessService _accessService;
        private static IMapper _mapper;
        private IWebHostEnvironment _IWebHostEnvironment;
        private ImagesService _imagesService;

        [Test]
        public void UsersList()
        {
            UsersController usersController = new UsersController(_accessService, _mapper, _IWebHostEnvironment, _imagesService);
            var result = usersController.List();
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IActionResult>(result);
        }
        
        [Test]
        public void UsersInsert()
        {
            UsuariosInsertViewModel usuariosInsertViewModel = new UsuariosInsertViewModel();
            UsersController usersController = new UsersController(_accessService, _mapper, _IWebHostEnvironment, _imagesService);
            var result = usersController.Insert(usuariosInsertViewModel);
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IActionResult>(result);
        }

        [Test]
        public void UsersUpdate()
        {
            int id = 2;
            UsuariosUpdateViewModel usuariosUpdateViewModel = new UsuariosUpdateViewModel();
            UsersController usersController = new UsersController(_accessService, _mapper, _IWebHostEnvironment, _imagesService);
            var result = usersController.Update(id, usuariosUpdateViewModel);
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IActionResult>(result);
        }

        [Test]
        public void UsersChangePassword()
        {
            UsuariosPasswordViewModel usuariosPasswordViewModel = new UsuariosPasswordViewModel();
            UsersController usersController = new UsersController(_accessService, _mapper, _IWebHostEnvironment, _imagesService);
            var result = usersController.changePassword(usuariosPasswordViewModel);
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IActionResult>(result);
        }

        [Test]
        public void UsersDelete()
        {
            int id = 2;
            int Mod = 1;
            UsersController usersController = new UsersController(_accessService, _mapper, _IWebHostEnvironment, _imagesService);
            var result = usersController.Delete(id, Mod);
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IActionResult>(result);
        }

        [Test]
        public void UsersDetails()
        {
            int id = 2;
            UsersController usersController = new UsersController(_accessService, _mapper, _IWebHostEnvironment, _imagesService);
            var result = usersController.Details(id);
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IActionResult>(result);
        }
    }
}
