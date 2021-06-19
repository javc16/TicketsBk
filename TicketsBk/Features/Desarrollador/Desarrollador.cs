using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketsBk.Features.Proyectos
{
    public class Desarrollador
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int CodigoEmpleado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int IdProyecto { get; set; }
        public Proyecto Proyecto { get; set; }
        public int Estado { get; set; }


    }
}
