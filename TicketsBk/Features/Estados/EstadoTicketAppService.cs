using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketsBk.Context;
using TicketsBk.Helpers;

namespace TicketsBk.Features.Estados
{
    public class EstadoTicketAppService
    {
        private readonly MyContext _context;

        public EstadoTicketAppService(MyContext context)
        {
            _context = context;

        }

        public async Task<IEnumerable<EstadoTicket>> GetAll()
        {
            var estadoTicket = await _context.EstadoTicket.ToListAsync();
            return estadoTicket;
        }

        public async Task<EstadoTicket> GetById(int id)
        {
            var estadoTicket = await _context.EstadoTicket.FirstOrDefaultAsync(r => r.Id == id);
            if (estadoTicket == null)
            {
                return new EstadoTicket();
            }
            return estadoTicket;
        }

        public async Task<Response> Post(EstadoTicket estadoTicket)
        {
            var guardarEstadoTicket = await _context.EstadoTicket.FirstOrDefaultAsync(r => r.Nombre == estadoTicket.Nombre);
            if (guardarEstadoTicket != null)
            {
                return new Response { Mensaje = "Este Estado de Ticket ya existe en el sistema" };
            }

            _context.EstadoTicket.Add(estadoTicket);
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
