using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketsBk.Context;
using TicketsBk.Helpers;

namespace TicketsBk.Features.Tickets
{
    public class TicketAppService
    {
        private readonly MyContext _context;

        public TicketAppService(MyContext context)
        {
            _context = context;

        }

        public async Task<IEnumerable<TicketDTO>> GetAll()
        {
            var ticket = await _context.Ticket.Include(e => e.Departamento).Include(e => e.Categoria).Include(e => e.Desarrollador).Include(e => e.EstadoTicket).ToListAsync();
            var ticketDTO = TicketDTO.DeModeloADTO(ticket);
            return ticketDTO;
        }

        public async Task<Response> GetById(long id)
        {
            var ticket = await _context.Ticket.Include(e => e.Departamento).Include(e => e.Categoria).Include(e => e.Desarrollador).Include(e => e.EstadoTicket).FirstOrDefaultAsync(r => r.Id == id);
            if (ticket == null)
            {
                return new Response { Mensaje = "Este Ticket no existe" };
            }
            var data = TicketDTO.DeModeloADTO(ticket);
            return new Response { Datos = data };
        }

        public async Task<Response> Post(TicketDTO ticketDTO)
        {
            var guardarTicket = await _context.Ticket.FirstOrDefaultAsync(r => r.Nombre == ticketDTO.Nombre);
            if (guardarTicket != null)
            {
                return new Response { Mensaje = "Este Ticket ya existe en el sistema" };
            }

            _context.Ticket.Add(guardarTicket);
            await _context.SaveChangesAsync();
            return new Response { Mensaje = "Ticket guardado correctamente" };
        }

        public async Task<Response> Put(TicketDTO ticketDTO)
        {
            var ticket = TicketDTO.DeDTOAModelo(ticketDTO);
            _context.Entry(ticket).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return new Response { Mensaje = $"Ticket {ticketDTO.Nombre} modificado correctamente" };
        }

      
    }
}
