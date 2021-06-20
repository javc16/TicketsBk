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
    public class ProductOwnerController : ControllerBase
    {
        private readonly ProductOwnerAppService _productOwnerAppService;

        public ProductOwnerController(ProductOwnerAppService productOwnerAppService)
        {
            _productOwnerAppService = productOwnerAppService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductOwner>>> GetAll()
        {
            var result = await _productOwnerAppService.GetAll();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ProductOwner>> GetById(int id)
        {
            return Ok(await _productOwnerAppService.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult<Response>> Post(ProductOwner item)
        {
            return Ok(await _productOwnerAppService.Post(item));
        }

        [HttpPut]
        public async Task<ActionResult<Response>> Put(ProductOwner item)
        {
            return Ok(await _productOwnerAppService.Put(item));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Response>> DeleteById(int id)
        {
            return Ok(await _productOwnerAppService.Delete(id));
        }

    }
}
