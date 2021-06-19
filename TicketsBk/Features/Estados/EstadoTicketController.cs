using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketsBk.Helpers;

namespace TicketsBk.Features.Estados
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoTicketController : ControllerBase
    {
        private readonly EstadoTicketAppService _estadoTicketAppService;

        public EstadoTicketController(EstadoTicketAppService estadoTicketAppService)
        {
            _estadoTicketAppService = estadoTicketAppService;
        }


        [HttpGet]
        public ActionResult<IEnumerable<EstadoTicket>> GetAll()
        {
            var result = _estadoTicketAppService.GetAll();
            return Ok(result);
        }


        [HttpGet("{nombre}")]
        public async Task<ActionResult<Response>> GetById(string nombre)
        {
            return Ok(await _estadoTicketAppService.GetById(nombre));
        }

        [HttpPost]
        public async Task<ActionResult<Response>> Post(EstadoTicket item)
        {
            return Ok(await _estadoTicketAppService.Post(item));
        }

        [HttpPut]
        public async Task<ActionResult<Response>> Put(EstadoTicket item)
        {
            return Ok(await _estadoTicketAppService.Put(item));
        }
    }
}
