using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketsBk.Context;
using TicketsBk.Helpers;

namespace TicketsBk.Features.Categorias
{
    public class CategoriaAppService
    {
        private readonly MyContext _context;

        public CategoriaAppService(MyContext context)
        {
            _context = context;

        }

        public IEnumerable<Categoria> GetAll()
        {
            var categoria = _context.Categoria.Where(x=>x.Estado==Constantes.Activo);
            return categoria;
        }

        public async Task<Categoria> GetById(int id)
        {
            var categoria = await _context.Categoria.FirstOrDefaultAsync(r => r.Id == id);
            if (categoria == null)
            {
                return new Categoria();
            }
            return categoria;
        }

        public async Task<Response> Post(Categoria categoria)
        {
            var guardarCategoria = await _context.Categoria.FirstOrDefaultAsync(r => r.Nombre == categoria.Nombre);
            if (guardarCategoria != null)
            {
                return new Response { Mensaje = "Este categoria ya existe en el sistema" };
            }

            _context.Categoria.Add(categoria);
            await _context.SaveChangesAsync();
            return new Response { Mensaje = "Categoria guardada correctamente" };
        }

        public async Task<Response> Put(Categoria categoria)
        {
            _context.Entry(categoria).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return new Response { Mensaje = $"Categoria {categoria.Nombre} modificada correctamente" };
        }

        public async Task<Response> Delete(int id)
        {
            var categoria = await _context.Categoria.FirstOrDefaultAsync(x => x.Id == id);
            if (categoria == null)
            {
                return new Response { Mensaje = $"No tenemos un departamento con ese id" };
            }
            categoria.Estado = 0;
            _context.Entry(categoria).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return new Response { Mensaje = $"Categoria {categoria.Nombre} eliminado correctamente" };
        }
    }
}
