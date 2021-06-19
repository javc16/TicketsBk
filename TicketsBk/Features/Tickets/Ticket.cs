using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketsBk.Features.Categorias;
using TicketsBk.Features.Departamentos;
using TicketsBk.Features.Proyectos;

namespace TicketsBk.Features.Tickets
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string DescripcionIncidente { get; set; }
        public string DescripcionSolucion { get; set; }

        public DateTime FechaInicial { get; set; }
        public DateTime FechaFinal { get; set; }
        public int DiasTranscurridos { get; set; }
        public Departamento Departamento { get; set; }
        public Categoria Categoria { get; set; }
        public Desarrollador Desarrollador { get; set; }
    }
}
