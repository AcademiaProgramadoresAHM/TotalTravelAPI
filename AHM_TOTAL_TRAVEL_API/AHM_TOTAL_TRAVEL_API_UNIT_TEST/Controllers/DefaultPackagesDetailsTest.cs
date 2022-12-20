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
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace AHM_TOTAL_TRAVEL_API_TEST.Controllers
{
    //[TestClass]
    [TestFixture]
    public class DefaultPackagesDetailsTest
    {
        private SaleService saleService;
        private static IMapper _mapper;

        [Test]
        public void DefaultPackagesList()
        {
            DefaultPackagesDetailsController _defaultPackagesDetails = new DefaultPackagesDetailsController(saleService, _mapper);
            var result = _defaultPackagesDetails.List();
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IActionResult>(result);
        }

        [Test]
        public void DefaultPackagesDetails()
        {
            int id = 2;
            DefaultPackagesDetailsController _defaultPackagesDetails = new DefaultPackagesDetailsController(saleService, _mapper);
            var result = _defaultPackagesDetails.Details(id);
            Assert.IsInstanceOf<IActionResult>(result);
            Assert.IsNotNull(result);
        }

        [Test]
        public void DefaultPackagesInsert()
        {
            PaquetePredeterminadosDetallesViewModel paquetePredeterminadosDetallesViewModel = new PaquetePredeterminadosDetallesViewModel();
            DefaultPackagesDetailsController _defaultPackagesDetails = new DefaultPackagesDetailsController(saleService, _mapper);
            var result = _defaultPackagesDetails.Insert(paquetePredeterminadosDetallesViewModel);
            Assert.IsInstanceOf<IActionResult>(result);
            Assert.IsNotNull(result);
        }

        [Test]
        public void DefaultPackagesUpdate()
        {
            int id = 2;
            PaquetePredeterminadosDetallesViewModel paquetePredeterminadosDetallesViewModel = new PaquetePredeterminadosDetallesViewModel();
            DefaultPackagesDetailsController _defaultPackagesDetails = new DefaultPackagesDetailsController(saleService, _mapper);
            var result = _defaultPackagesDetails.Update(id, paquetePredeterminadosDetallesViewModel);
            Assert.IsInstanceOf<IActionResult>(result);
            Assert.IsNotNull(result);
        }

        [Test]
        public void TestDelete()
        {
            int id = 2;
            int Mod = 1;
            DefaultPackagesDetailsController _defaultPackagesDetails = new DefaultPackagesDetailsController(saleService, _mapper);
            var result = _defaultPackagesDetails.Delete(id, Mod);
            Assert.IsInstanceOf<IActionResult>(result);
            Assert.IsNotNull(result);

        }

        //public DefaultPackagesDetailsTest()
        //{
        //    if (_mapper == null)
        //    {
        //        var mappingConfig = new MapperConfiguration(mc =>
        //        {
        //            mc.AddProfile(new MappingProfileExtensions());
        //        });
        //        IMapper mapper = mappingConfig.CreateMapper();
        //        _mapper = mapper;
        //    }
        //}

        //protected Mock<IMapper> map = new Mock<IMapper>();
        //DefaultPackagesDetailsController _defaultPackagesDetails;

        //[TestInitialize]
        //public void Initalize()
        //{
        //    _defaultPackagesDetails = new DefaultPackagesDetailsController(saleService, _mapper);
        //}

        //[TestMethod]
        //public void DefaultPackagesList()
        //{
        //    var result = _defaultPackagesDetails.List();
        //    //int Code = (int)result.StatusCode;

        //    Assert.IsInstanceOfType<IActionResult>(result);
        //    Assert.IsNotNull(result);
        //}

        //[TestMethod]
        //public void DefaultPackagesDetails()
        //{
        //    int id = 2;
        //    var result = _defaultPackagesDetails.Details(id);
        //    //int Code = (int)result.StatusCode;
        //    //ServiceResult Value = (ServiceResult)result.Value;
        //    Assert.IsInstanceOfType<IActionResult>(result);
        //    Assert.IsNotNull(result);
        //}


    }
}
