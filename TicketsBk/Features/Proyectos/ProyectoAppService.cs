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

        public async Task<Response> GetById(long id)
        {
            var articulo = await _context.Proyecto.FirstOrDefaultAsync(r => r.Id == id);
            if (articulo == null)
            {
                return new Response { Mensaje = "Este proyecto no existe" };
            }
            var data = ProyectoDTO.DeModeloADTO(articulo);
            return new Response { Datos = data };
        }

        public async Task<Response> PostProyecto(Proyecto proyecto)
        {
            var guardarProyecto = await _context.Proyecto.FirstOrDefaultAsync(r => r.NombreProyecto == proyecto.NombreProyecto);
            if (guardarProyecto != null)
            {
                return new Response { Mensaje = "Este proyecto ya existe en el sistema" };
            }

            _context.Proyecto.Add(proyecto);
            await _context.SaveChangesAsync();
            return new Response { Mensaje = "Proyecto guardado correctamente" };
        }

        public async Task<Response> PutProyecto(Proyecto proyecto)
        {
            _context.Entry(proyecto).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return new Response { Mensaje = $"Proyecto {proyecto.NombreProyecto} modificado correctamente" };
        }

        public async Task<Response> DeleteProyecto(int id)
        {
            var proyecto = await _context.Proyecto.FindAsync(id);
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
