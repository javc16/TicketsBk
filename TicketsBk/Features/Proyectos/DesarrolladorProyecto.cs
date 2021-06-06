using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketsBk.Features.Proyectos
{
    public class DesarrolladorProyecto
    {
        public int Id { get; set; }
        public int IdDesarrollador { get; set; }
        public int IdProyecto { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int Estado { get; set; }
    }
}
