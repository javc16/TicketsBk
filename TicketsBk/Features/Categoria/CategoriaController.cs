using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketsBk.Helpers;

namespace TicketsBk.Features.Categorias
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly CategoriaAppService _categoriaAppService;

        public CategoriaController(CategoriaAppService categoriaAppService)
        {
            _categoriaAppService = categoriaAppService;
        }


        [HttpGet]
        public  ActionResult<IEnumerable<Categoria>> GetAll()
        {
            var result = _categoriaAppService.GetAll();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Categoria>> GetById(int id)
        {
            return Ok(await _categoriaAppService.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult<Response>> Post(Categoria item)
        {
            return Ok(await _categoriaAppService.Post(item));
        }

        [HttpPut]
        public async Task<ActionResult<Response>> Put(Categoria item)
        {
            return Ok(await _categoriaAppService.Put(item));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Response>> DeleteById(int id)
        {
            return Ok(await _categoriaAppService.Delete(id));
        }
    }
}
