using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketsBk.Helpers;

namespace TicketsBk.Features.Proyectos
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesarrolladorController : ControllerBase
    {
        private readonly DesarrolladorAppService _desarrolladorAppService;

        public DesarrolladorController(DesarrolladorAppService desarrolladorAppService)
        {
            _desarrolladorAppService = desarrolladorAppService;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Desarrollador>> GetAll()
        {
            var result =  _desarrolladorAppService.GetAll();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Desarrollador>> GetById(int id)
        {
            return Ok(await _desarrolladorAppService.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult<Response>> Post(Desarrollador item)
        {
            return Ok(await _desarrolladorAppService.Post(item));
        }

        [HttpPut]
        public async Task<ActionResult<Response>> Put(Desarrollador item)
        {
            return Ok(await _desarrolladorAppService.Put(item));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Response>> DeleteById(int id)
        {
            return Ok(await _desarrolladorAppService.Delete(id));
        }
    }
}
