using AHM.Total.Travel.BusinessLogic.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AHM.Total.Travel.Api.Controllers
{
    [ApiController]
    [Route("API/[controller]")]
    [Authorize(Roles = "Administrador")]
    public class ModulesController : Controller
    {
        private readonly AccessService _AccessService;

        public ModulesController(AccessService AccessService)
        {
            _AccessService = AccessService;
        }

        [AllowAnonymous]
        public IActionResult List()
        {
            var data = _AccessService.ListModules();
            return View(data);
        }
    }
}
