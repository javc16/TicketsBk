using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketsBk.Context;
using TicketsBk.Helpers;

namespace TicketsBk.Features.Proyectos
{
    public class DesarrolladorAppService
    {
        private readonly MyContext _context;

        public DesarrolladorAppService(MyContext context)
        {
            _context = context;

        }

        public async Task<IEnumerable<Desarrollador>> GetAll()
        {
            var desarrollador = await _context.Desarrollador.Include(e => e.Proyecto).ToListAsync();
            return desarrollador;
        }

        public async Task<Desarrollador> GetById(int id)
        {
            var desarrollador = await _context.Desarrollador.Include(e => e.Proyecto).FirstOrDefaultAsync(r => r.Id == id);
            if (desarrollador == null)
            {
                return new Desarrollador();
            }
            return desarrollador;
        }

        public async Task<Response> Post(Desarrollador desarrollador)
        {
            var guardarDesarrollador = await _context.Desarrollador.FirstOrDefaultAsync(r => r.Nombre == desarrollador.Nombre);
            if (guardarDesarrollador != null)
            {
                return new Response { Mensaje = "Este desarrollador ya existe en el sistema" };
            }

            _context.Desarrollador.Add(desarrollador);
            await _context.SaveChangesAsync();
            return new Response { Mensaje = "Estado de Ticket guardado correctamente" };
        }

        public async Task<Response> Put(Desarrollador desarrollador)
        {
            _context.Entry(desarrollador).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return new Response { Mensaje = $"Desarrollador {desarrollador.Nombre} modificado correctamente" };
        }

        public async Task<Response> Delete(int id)
        {
            var desarrollador = await _context.Desarrollador.FirstOrDefaultAsync(x => x.Id == id);
            if (desarrollador == null)
            {
                return new Response { Mensaje = $"No tenemos un Desarrollador con ese id" }; ;
            }
            desarrollador.Estado = 0;
            _context.Entry(desarrollador).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return new Response { Mensaje = $"Desarrollador {desarrollador.Nombre} eliminado correctamente" };
        }
    }
}
