using AHM.Total.Travel.BusinessLogic;
using AHM.Total.Travel.BusinessLogic.Services;
using AHM.Total.Travel.Common.Models;
using AHM.Total.Travel.Entities.Entities;
using AutoMapper;
using ConciertosProyecto.BusinessLogic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AHM.Total.Travel.Api.Controllers
{
    [ApiController] 
    [Route("API/[Controller]")]
    [Authorize(Roles = "Administrador")]
    public class RolesController : Controller
        {
        private readonly AccessService _AccessService;
        private readonly IMapper _mapper;
        public RolesController(AccessService AccessService, IMapper mapper)
        {
            _AccessService = AccessService;
            _mapper = mapper;
        }


        [HttpGet("List")]
        public IActionResult List()
        {
            try
            {
                var list = _AccessService.ListRole();
                return Ok(list);
            }
            catch (Exception)
            {

                var data = new ServiceResult();
                return Ok(data.Error());
            }
            
        }

        [HttpPost("Insert")]
        public IActionResult Insert(RolesViewModel item)
        {
            try
            {
                var items = _mapper.Map<tbRoles>(item);
                var result = _AccessService.CreateRole(items);
                return Ok(result);
            }
            catch (Exception)
            {

                var data = new ServiceResult();
                return Ok(data.Error());
            }
            
        }


        [HttpPut("Update")]
            public IActionResult Update(int id, RolesViewModel items)
            {
                try
                {
                    var item = _mapper.Map<tbRoles>(items);
                    var result = _AccessService.UpdateRole(id, item);
                    return Ok(result);
                }
                catch (Exception)
                {

                    var data = new ServiceResult();
                    return Ok(data.Error());
                }
            

            }

            [HttpDelete("Delete")]
            public IActionResult Delete(int id, int Mod)
            {
                try
                {
                    var result = _AccessService.DeleteRole(id, Mod);
                    return Ok(result);
                }
                catch (Exception)
                {

                    var data = new ServiceResult();
                    return Ok(data.Error());
                }
            

            }

            [HttpGet("Find")]
            public IActionResult Details(int Id)
            {
                try
                {
                    var result = _AccessService.FindRole(Id);
                    return Ok(result);
                }
                catch (Exception)
                {

                    var data = new ServiceResult();
                    return Ok(data.Error());
                }
            
            }
    }
    }

