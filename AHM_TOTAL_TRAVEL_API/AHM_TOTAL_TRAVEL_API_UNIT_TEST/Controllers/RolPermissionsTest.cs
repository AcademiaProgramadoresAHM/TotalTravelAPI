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

    public class RolPermissionsTest
    {
        private AccessService  _accessService ;
        private static IMapper _mapper;

        [Test]
        public void RolPermissionsList()
        {
            RolePermissionsController rolePermissionsController = new RolePermissionsController(_accessService, _mapper);
            var result = rolePermissionsController.List();
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IActionResult>(result);
        }

        [Test]
        public void SuburbsDetails()
        {
            int id = 2;
            RolePermissionsController rolePermissionsController = new RolePermissionsController(_accessService, _mapper);
            var result = rolePermissionsController.Details(id);
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IActionResult>(result);
        }

        [Test]
        public void SuburbsInsert()
        {
            RolePermissionsController rolePermissionsController = new RolePermissionsController(_accessService, _mapper);
            RolesPermisosViewModel rolesPermisosViewModel = new RolesPermisosViewModel();
            var result = rolePermissionsController.Insert(rolesPermisosViewModel);
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IActionResult>(result);
        }

        [Test]
        public void SuburbsUpdate()
        {
            int id = 2;
            RolePermissionsController rolePermissionsController = new RolePermissionsController(_accessService, _mapper);
            RolesPermisosViewModel rolesPermisosViewModel = new RolesPermisosViewModel();
            var result = rolePermissionsController.Update(id, rolesPermisosViewModel);
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IActionResult>(result);
        }

        [Test]
        public void SuburbsDelete()
        {
            int id = 2;
            int Mod = 1;
            RolePermissionsController rolePermissionsController = new RolePermissionsController(_accessService, _mapper);
            var result = rolePermissionsController.Delete(id, Mod);
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IActionResult>(result);
        }
    }
}
