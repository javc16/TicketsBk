using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketsBk.Helpers;

namespace TicketsBk.Features.Tickets
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly TicketAppService _ticketAppService;

        public TicketController(TicketAppService ticketAppService)
        {
            _ticketAppService = ticketAppService;
        }


        [HttpGet]
        public ActionResult<IEnumerable<TicketDTO>> GetAll()
        {
            var result = _ticketAppService.GetAll();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Response>> GetById(long id)
        {
            return Ok(await _ticketAppService.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult<Response>> Post(TicketDTO item)
        {
            return Ok(await _ticketAppService.Post(item));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Response>> Put(TicketDTO item)
        {
            return Ok(await _ticketAppService.Put(item));
        }

   
    }
}
