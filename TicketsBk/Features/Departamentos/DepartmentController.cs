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
        public ActionResult<IEnumerable<Departamento>> GetAll()
        {
            var result = _departamentoAppService.GetAll();
            return Ok(result);
        }


        [HttpGet("{nombre}")]
        public async Task<ActionResult<Response>> GetById(string nombre)
        {
            return Ok(await _departamentoAppService.GetById(nombre));
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
