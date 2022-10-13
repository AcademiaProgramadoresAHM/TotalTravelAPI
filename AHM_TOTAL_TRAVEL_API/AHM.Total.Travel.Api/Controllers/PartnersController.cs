using AHM.Total.Travel.BusinessLogic.Services;
using AHM.Total.Travel.Common.Models;
using AHM.Total.Travel.Entities.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AHM.Total.Travel.Api.Controllers
{
    [ApiController]
    [Route("API/[controller]")]
    [Authorize(Roles = "Administrador")]
    public class PartnersController : Controller
    {
        private readonly GeneralService _generalService;
        private readonly IMapper _mapper;

        public PartnersController(GeneralService generalService, IMapper mapper)
        {
            _generalService = generalService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet("List")]
        public IActionResult List()
        {
            var list = _generalService.ListPartners();
            return Ok(list);

        }

       
        [HttpPost("Insert")]
        public IActionResult Insert([FromForm] PartnersViewModel item)
        {
            var user = _mapper.Map<tbPartners>(item);
            var result = _generalService.CreatePartner(user, item.File);
            return Ok(result);
        }

        [HttpPut("Update")]
        public IActionResult Update(int id, PartnersViewModel items)
        {

            var item = _mapper.Map<tbPartners>(items);
            var result = _generalService.UpdatePartner(id, item, items.File);
            return Ok(result);

        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id, int Mod)
        {
            var result = _generalService.DeletePartner(id, Mod);
            return Ok(result);

        }

        [HttpGet("Find")]
        public IActionResult Details(int Id)
        {

            var result = _generalService.FindPartner(Id);
            return Ok(result);
        }
    }
}
