using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketsBk.Features.Categorias;
using TicketsBk.Features.Departamentos;
using TicketsBk.Features.Estados;
using TicketsBk.Features.Proyectos;

namespace TicketsBk.Features.Tickets
{
    public class TicketDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string DescripcionIncidente { get; set; }
        public string DescripcionSolucion { get; set; }
        public DateTime FechaCreacion { get; set; }

        public DateTime FechaInicial { get; set; }
        public DateTime FechaFinal { get; set; }
        public int DiasTranscurridos { get; set; }
        public Departamento Departamento { get; set; }
        public Categoria Categoria { get; set; }
        public Desarrollador Desarrollador { get; set; }
        public EstadoTicket EstadoTicket { get; set; }
        public int IdDepartamento { get; set; }
        public int IdCategoria { get; set; }
        public int IdDesarrollador { get; set; }
        public int IdEstadoTicket { get; set; }
        public static TicketDTO DeModeloADTO(Ticket ticket)
        {
            return ticket != null ? new TicketDTO
            {
                Id=ticket.Id,
                Nombre = ticket.Nombre,
                DescripcionIncidente = ticket.DescripcionIncidente,
                DescripcionSolucion = ticket.DescripcionSolucion,
                FechaCreacion = ticket.FechaCreacion,
                FechaInicial = ticket.FechaInicial,
                FechaFinal = ticket.FechaFinal,
                DiasTranscurridos = ticket.DiasTranscurridos,
                Departamento = ticket.Departamento,
                Categoria = ticket.Categoria,
                Desarrollador = ticket.Desarrollador,
                EstadoTicket = ticket.EstadoTicket,
                IdDepartamento = ticket.IdDepartamento,
                IdCategoria = ticket.IdCategoria,
                IdDesarrollador = ticket.IdDesarrollador,
                IdEstadoTicket = ticket.IdEstadoTicket
            } : null;
        }

        public static IEnumerable<TicketDTO> DeModeloADTO(IEnumerable<Ticket> tickets)
        {
            if (tickets == null)
            {
                return new List<TicketDTO>();
            }
            List<TicketDTO> ticketsData = new List<TicketDTO>();

            foreach (var item in tickets)
            {
                ticketsData.Add(DeModeloADTO(item));
            }

            return ticketsData;
        }

        public static Ticket DeDTOAModelo(TicketDTO ticketDTO)
        {
            return ticketDTO != null ? new Ticket.Builder(ticketDTO.Nombre,ticketDTO.DescripcionIncidente,ticketDTO.DescripcionSolucion,ticketDTO.FechaInicial,
                ticketDTO.FechaFinal,ticketDTO.DiasTranscurridos,ticketDTO.Departamento,ticketDTO.Categoria,ticketDTO.Desarrollador,ticketDTO.EstadoTicket,
                ticketDTO.IdDepartamento,ticketDTO.IdCategoria,ticketDTO.IdDesarrollador,ticketDTO.IdEstadoTicket).Construir() : null;
        }
    }
}

