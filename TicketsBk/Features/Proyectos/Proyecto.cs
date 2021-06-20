using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketsBk.Helpers;

namespace TicketsBk.Features.Proyectos
{
    public class Proyecto
    {
        public int Id { get; set; }
        public string NombreProyecto { get; set; }
        public string DescripcionProyecto { get; set; }
        public string EstadoDelProyecto { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int IdProductOwner { get; set; }
        public ProductOwner ProductOwner { get; set; }    
        public int Estado { get; set; }

        public sealed class Builder
        {
            private readonly Proyecto _proyecto;

            public Builder(string nombreProyecto,string estadoDelProyecto,DateTime fechaInicio,DateTime fechaFin,ProductOwner productOwner, string descripcionProyecto, int idProductOwner)
            {
                _proyecto = new Proyecto
                {
                    NombreProyecto = nombreProyecto,
                    DescripcionProyecto = descripcionProyecto,
                    EstadoDelProyecto = estadoDelProyecto,
                    FechaInicio = fechaInicio,
                    FechaFin = fechaFin,
                    ProductOwner = productOwner,
                    IdProductOwner = idProductOwner,
                    FechaCreacion = DateTime.Now,
                    Estado = Constantes.Activo
                };
            }

            public Builder conDescripcionDelProyecto(string descripcionProyecto)
            {
                _proyecto.DescripcionProyecto = descripcionProyecto;
                return this;
            }
      
            public Proyecto Construir()
            {
                return _proyecto;
            }
        }

    }
}
