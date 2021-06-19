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
            var estadoTicket = await _context.Desarrollador.ToListAsync();
            return estadoTicket;
        }

        public async Task<Response> GetById(string nombre)
        {
            var estadoTicket = await _context.Desarrollador.FirstOrDefaultAsync(r => r.Nombre == nombre);
            if (estadoTicket == null)
            {
                return new Response { Mensaje = "Este Desarrollador no existe" };
            }
            return new Response { Datos = estadoTicket };
        }

        public async Task<Response> Post(Desarrollador desarrollador)
        {
            var guardarEstadoTicket = await _context.Desarrollador.FirstOrDefaultAsync(r => r.Nombre == desarrollador.Nombre);
            if (guardarEstadoTicket != null)
            {
                return new Response { Mensaje = "Este desarrollador ya existe en el sistema" };
            }

            _context.Desarrollador.Add(guardarEstadoTicket);
            await _context.SaveChangesAsync();
            return new Response { Mensaje = "Estado de Ticket guardado correctamente" };
        }

        public async Task<Response> Put(EstadoTicket estadoTicket)
        {
            _context.Entry(estadoTicket).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return new Response { Mensaje = $"Estado de Ticket {estadoTicket.Nombre} modificado correctamente" };
        }
    }
}
