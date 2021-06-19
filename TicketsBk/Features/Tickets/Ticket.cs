using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketsBk.Features.Categorias;
using TicketsBk.Features.Departamentos;
using TicketsBk.Features.Proyectos;
using TicketsBk.Helpers;

namespace TicketsBk.Features.Tickets
{
    public class Ticket
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

        public sealed class Builder
        {
            private readonly Ticket _ticket;

            public Builder(string nombre, string descripcionIncidente, string descripcionSolucion, DateTime fechaInicio, 
                DateTime fechaFin, int diasTranscurridos, Departamento departamento, Categoria categoria, Desarrollador desarrollador)
            {
                _ticket = new Ticket
                {
                    Nombre = nombre,
                    DescripcionIncidente = descripcionIncidente,
                    DescripcionSolucion = descripcionSolucion,
                    FechaCreacion = DateTime.Now,
                    FechaInicial = fechaInicio,
                    FechaFinal = fechaFin,
                    DiasTranscurridos = diasTranscurridos,
                    Departamento = departamento,
                    Categoria = categoria,
                    Desarrollador= desarrollador,
                };
            }

         

            public Ticket Construir()
            {
                return _ticket;
            }
        }
    }
}
