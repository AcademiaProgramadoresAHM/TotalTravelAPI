using AHM.Total.Travel.BusinessLogic.Services;
using AHM.Total.Travel.Common.Models;
using AHM.Total.Travel.Entities.Entities;
using AutoMapper;
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
    public class PaymentTypesController : Controller
    {
        private readonly SaleService _saleService;
        private readonly IMapper _mapper;
        public PaymentTypesController(SaleService saleService, IMapper mapper)
        {
            _saleService = saleService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet("List")]
        public IActionResult List()
        {
            var list = _saleService.Listpayment();
            return Ok(list);

        }

        [HttpPost("Insert")]
        public IActionResult Insert(TiposPagosViewModel tiposPagosViewModel)
        {
            var items = _mapper.Map<tbTiposPagos>(tiposPagosViewModel);
            var result = _saleService.Createpayment(items);
            return Ok(result);
        }

        [HttpPut("Update")]
        public IActionResult Update(int id, TiposPagosViewModel tiposPagosViewModel)
        {

            var item = _mapper.Map<tbTiposPagos>(tiposPagosViewModel);
            var result = _saleService.Updatepayment(id, item);
            return Ok(result);

        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id, int Mod)
        {
            var result = _saleService.Deletepayment(id, Mod);
            return Ok(result);

        }

        [HttpGet("Find")]
        public IActionResult Details(int Id)
        {
            var result = _saleService.Findpayment(Id);
            return Ok(result);
        }
    }
}
