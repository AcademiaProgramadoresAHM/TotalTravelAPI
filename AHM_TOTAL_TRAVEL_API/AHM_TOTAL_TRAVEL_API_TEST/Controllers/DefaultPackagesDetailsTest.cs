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
using System;
using System.Collections.Generic;
using System.Text;
using AHM.Total.Travel.BusinessLogic.Services;

namespace AHM_TOTAL_TRAVEL_API_TEST.Controllers
{
    [TestClass]
    public class DefaultPackagesDetailsTest
    {
        private SaleService saleService;
        private static IMapper _mapper;

        public DefaultPackagesDetailsTest()
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
        DefaultPackagesDetailsController _defaultPackagesDetails;

        [TestInitialize]
        public void Initalize()
        {
            _defaultPackagesDetails = new DefaultPackagesDetailsController(saleService, _mapper);
        }

        [TestMethod]
        public void DefaultPackagesList()
        {
            var result = _defaultPackagesDetails.List();
            //int Code = (int)result.StatusCode;

            Assert.IsInstanceOfType<IActionResult>(result);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void DefaultPackagesDetails()
        {
            int id = 2;
            var result = _defaultPackagesDetails.Details(id);
            //int Code = (int)result.StatusCode;
            //ServiceResult Value = (ServiceResult)result.Value;
            Assert.IsInstanceOfType<IActionResult>(result);
            Assert.IsNotNull(result);
        }
    }
}
