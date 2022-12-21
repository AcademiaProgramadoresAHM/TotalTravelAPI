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

    public class RootFilesTest
    {
        private  ImagesService _imagesService;



        [Test]
        public void RootFilesGetImage()
        {
            string id = "";
            RootFilesController rootFilesController = new RootFilesController(_imagesService);
            var result = rootFilesController.GetImage(id);
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IActionResult>(result);
        }

        [Test]
        public void RootFilesGetAllImages()
        {
            string id = "";
            RootFilesController rootFilesController = new RootFilesController(_imagesService);
            var result = rootFilesController.GetImage(id);
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IActionResult>(result);
        }



    }
}
