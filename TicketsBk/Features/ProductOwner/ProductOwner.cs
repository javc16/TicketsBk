using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketsBk.Features.Proyectos
{
    public class ProductOwner
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int CodigoEmpleado { get; set; }
        public string Departamento { get; set; }
        public DateTime FechaCreacion { get; set; }
        public List<Proyecto> Proyectos { get; set; }

    }
}
