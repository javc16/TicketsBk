using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketsBk.Context;
using TicketsBk.Helpers;

namespace TicketsBk.Features.Proyectos
{
    public class ProyectoAppService
    {
        private readonly MyContext _context;
        
        public ProyectoAppService(MyContext context)
        {
            _context = context;
           
        }

        public IEnumerable<ProyectoDTO> GetAll()
        {
            var proyecto = _context.Proyecto.Include(e => e.ProductOwner).Where(x => x.Estado == Constantes.Activo);
            var proyectoDTO = ProyectoDTO.DeModeloADTO(proyecto);
            return proyectoDTO;
        }

        public async Task<Response> GetById(string nombreProyecto)
        {
            var articulo = await _context.Proyecto.FirstOrDefaultAsync(r => r.NombreProyecto == nombreProyecto);
            if (articulo == null)
            {
                return new Response { Mensaje = "Este proyecto no existe" };
            }
            var data = ProyectoDTO.DeModeloADTO(articulo);
            return new Response { Datos = data };
        }

        public async Task<Response> PostProyecto(ProyectoDTO proyectoDTO)
        {
            var guardarProyecto = await _context.Proyecto.FirstOrDefaultAsync(r => r.NombreProyecto == proyectoDTO.NombreProyecto);
            if (guardarProyecto != null)
            {
                return new Response { Mensaje = "Este proyecto ya existe en el sistema" };
            }
            var proyecto = ProyectoDTO.DeDTOAModelo(proyectoDTO);
            _context.Proyecto.Add(proyecto);
            await _context.SaveChangesAsync();
            return new Response { Mensaje = "Proyecto guardado correctamente" };
        }

        public async Task<Response> PutProyecto(ProyectoDTO proyectoDTO)
        {
            var proyecto = ProyectoDTO.DeDTOAModelo(proyectoDTO);
            _context.Entry(proyecto).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return new Response { Mensaje = $"Proyecto {proyecto.NombreProyecto} modificado correctamente" };
        }

        public async Task<Response> DeleteProyecto(int id)
        {
            var proyecto = await _context.Proyecto.FirstOrDefaultAsync(x=>x.Id==id);
            if (proyecto == null)
            {
                return new Response { Mensaje = $"No tenemos un proyecto con ese id" }; ;
            }
            proyecto.Estado = 0;
            _context.Entry(proyecto).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return new Response { Mensaje = $"Proyecto {proyecto.NombreProyecto} eliminado correctamente" };
        }
    }
}
