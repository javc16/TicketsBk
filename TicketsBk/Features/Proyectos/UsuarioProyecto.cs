using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketsBk.Features.Proyectos
{
    public class UsuarioProyecto
    {

        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public int IdProyecto { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int Estado { get; set; }
    }
}
