using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketsBk.Context;
using TicketsBk.Helpers;

namespace TicketsBk.Features.Proyectos
{
    public class ProductOwnerAppService
    {
        private readonly MyContext _context;

        public ProductOwnerAppService(MyContext context)
        {
            _context = context;

        }

        public async Task<IEnumerable<ProductOwner>> GetAll()
        {
            var productOwners = await _context.ProductOwner.ToListAsync();
            return productOwners;
        }

        public async Task<Response> GetById(int id)
        {
            var productOwner = await _context.ProductOwner.Include(e => e.Proyectos).FirstOrDefaultAsync(r => r.Id == id);
            if (productOwner == null)
            {
                return new Response { Mensaje = "Este Product Owner no existe" };
            }
            return new Response { Datos = productOwner };
        }

        public async Task<Response> Post(ProductOwner productOwner)
        {
            var guardarProductOwner = await _context.ProductOwner.Include(e => e.Proyectos).FirstOrDefaultAsync(r => r.Nombre == productOwner.Nombre);
            if (guardarProductOwner != null)
            {
                return new Response { Mensaje = "Este Product Owner ya existe en el sistema" };
            }
            productOwner.FechaCreacion = DateTime.Now;
            _context.ProductOwner.Add(productOwner);
            await _context.SaveChangesAsync();
            return new Response { Mensaje = "Product Owner guardado correctamente" };
        }

        public async Task<Response> Put(ProductOwner productOwner)
        {
            _context.Entry(productOwner).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return new Response { Mensaje = $"Product Owner {productOwner.Nombre} modificado correctamente" };
        }

        public async Task<Response> Delete(int id)
        {
            var productOwner = await _context.ProductOwner.FirstOrDefaultAsync(x => x.Id == id);
            if (productOwner == null)
            {
                return new Response { Mensaje = $"No tenemos un Product Owner con ese id" }; ;
            }
            productOwner.Estado = 0;
            _context.Entry(productOwner).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return new Response { Mensaje = $"Proyecto {productOwner.Nombre} eliminado correctamente" };
        }
    }
}
