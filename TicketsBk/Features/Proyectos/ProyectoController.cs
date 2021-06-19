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
    public class ProyectoController : ControllerBase
    {
        private readonly ProyectoAppService _proyectoAppService;

        public ProyectoController(ProyectoAppService proyectoAppService)
        {
            _proyectoAppService = proyectoAppService;
        }


        [HttpGet]
        public ActionResult<IEnumerable<ProyectoDTO>> GetAll()
        {
            var result = _proyectoAppService.GetAll();
            return Ok(result);
        }


        [HttpGet("{nombreProyecto}")]
        public async Task<ActionResult<Response>> GetById(string nombreProyecto)
        {
            return Ok(await _proyectoAppService.GetById(nombreProyecto));
        }

        [HttpPost]
        public async Task<ActionResult<Response>> Post(ProyectoDTO item)
        {
            return Ok(await _proyectoAppService.PostProyecto(item));
        }

        [HttpPut]
        public async Task<ActionResult<Response>> PutProyecto(ProyectoDTO item)
        {
            return Ok(await _proyectoAppService.PutProyecto(item));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Response>> DeleteById(int id)
        {
            return Ok(await _proyectoAppService.DeleteProyecto(id));
        }
    }
}
