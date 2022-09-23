using AHM.Total.Travel.BusinessLogic.Services;
using AHM.Total.Travel.Common.Models;
using AHM.Total.Travel.Entities.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AHM.Total.Travel.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecordPaymentController : Controller
    {
        private readonly ReservationService _reservationService;
        private readonly IMapper _mapper;
        public RecordPaymentController(ReservationService reservationService, IMapper mapper)
        {
            _reservationService = reservationService;
            _mapper = mapper;
        }

        [HttpGet("List")]
        public IActionResult List()
        {
            var list = _reservationService.ListRecordPayments();
            return Ok(list);
        }

        [HttpPost("Insert")]
        public IActionResult Insert(RegistrosPagosViewModel item)
        {
            var items = _mapper.Map<tbRegistrosPagos>(item);
            var result = _reservationService.CreateRecordPayments(items);
            return Ok(result);
        }

        [HttpPut("Update")]
        public IActionResult Update(int id, TipoMenusViewModel items)
        {
            var item = _mapper.Map<tbRegistrosPagos>(items);
            var result = _reservationService.UpdateRecordPayments(id, item);
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id, int Mod)
        {
            var result = _reservationService.DeleteRecordPayments(id, Mod);
            return Ok(result);
        }

        [HttpGet("Find")]
        public IActionResult Details(int Id)
        {
            var result = _reservationService.FindRecordPayments(Id);
            return Ok(result);
        }
    }
}
