using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketsBk.Features.Proyectos
{
    public class ProyectoDTO
    {
        public int Id { get; set; }
        public string NombreProyecto { get; set; }
        public string DescripcionProyecto { get; set; }
        public string EstadoDelProyecto { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public int IdProductOwner { get; set; }
        public Usuario ProductOwner { get; set; }
        public List<Desarrollador> DesarrolladoresResponsables { get; set; }
        public List<Usuario> UsuariosInvolucrados { get; set; }
        public int Estado { get; set; }

        public static ProyectoDTO DeModeloADTO(Proyecto proyecto)
        {
            

            return proyecto != null ? new ProyectoDTO
            {
                Id = proyecto.Id,
                NombreProyecto = proyecto.NombreProyecto,
                DescripcionProyecto = proyecto.DescripcionProyecto,
                EstadoDelProyecto = proyecto.EstadoDelProyecto,
                FechaInicio = proyecto.FechaInicio,
                FechaFin = proyecto.FechaFin,
                IdProductOwner = proyecto.IdProductOwner,
                ProductOwner = proyecto.ProductOwner,
                DesarrolladoresResponsables = proyecto.DesarrolladoresResponsables,
                UsuariosInvolucrados = proyecto.usuariosInvolucrados,
                Estado = proyecto.Estado
            } : null;
        }

        public static IEnumerable<ProyectoDTO> DeModeloADTO(IEnumerable<Proyecto> proyecto)
        {
            if (proyecto == null)
            {
                return new List<ProyectoDTO>();
            }
            List<ProyectoDTO> proyectoData = new List<ProyectoDTO>();

            foreach (var item in proyecto)
            {
                proyectoData.Add(DeModeloADTO(item));
            }

            return proyectoData;
        }

        public static Proyecto DeDTOAModelo(ProyectoDTO proyectoDTO)
        {
            return proyectoDTO != null ? new Proyecto.Builder(proyectoDTO.NombreProyecto,proyectoDTO.EstadoDelProyecto,proyectoDTO.FechaInicio,proyectoDTO.FechaFin,proyectoDTO.ProductOwner).Construir() : null;
        }
    }
}
