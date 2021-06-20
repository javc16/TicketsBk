using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketsBk.Helpers;

namespace TicketsBk.Features.Departamentos
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly DepartamentoAppService _departamentoAppService;

        public DepartmentController(DepartamentoAppService departamentoAppService)
        {
            _departamentoAppService = departamentoAppService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Departamento>>> GetAll()
        {
            var result = await _departamentoAppService.GetAll();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Departamento>> GetById(int id)
        {
            return Ok(await _departamentoAppService.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult<Response>> Post(Departamento item)
        {
            return Ok(await _departamentoAppService.Post(item));
        }

        [HttpPut]
        public async Task<ActionResult<Response>> Put(Departamento item)
        {
            return Ok(await _departamentoAppService.Put(item));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Response>> DeleteById(int id)
        {
            return Ok(await _departamentoAppService.Delete(id));
        }
    }
}
