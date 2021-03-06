using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketsBk.Context;
using TicketsBk.Helpers;

namespace TicketsBk.Features.Departamentos
{
    public class DepartamentoAppService
    {
        private readonly MyContext _context;

        public DepartamentoAppService(MyContext context)
        {
            _context = context;

        }

        public IEnumerable<Departamento> GetAll()
        {
            var departamento =  _context.Departamento.Where(x=>x.Estado ==Constantes.Activo);
            return departamento;
        }

        public async Task<Departamento> GetById(int id)
        {
            var departamento = await _context.Departamento.FirstOrDefaultAsync(r => r.Id == id);
            if (departamento == null)
            {
                return new Departamento();
            }
            return departamento;
        }

        public async Task<Response> Post(Departamento departamento)
        {
            var guardarDepartamento = await _context.Departamento.FirstOrDefaultAsync(r => r.Nombre == departamento.Nombre);
            if (guardarDepartamento != null)
            {
                return new Response { Mensaje = "Este desarrollador ya existe en el sistema" };
            }
            departamento.Estado = 1;
            _context.Departamento.Add(departamento);
            await _context.SaveChangesAsync();
            return new Response { Mensaje = "Departamento guardado correctamente" };
        }

        public async Task<Response> Put(Departamento departamento)
        {
            _context.Entry(departamento).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return new Response { Mensaje = $"Departamento {departamento.Nombre} modificado correctamente" };
        }

        public async Task<Response> Delete(int id)
        {
            var departamento = await _context.Departamento.FirstOrDefaultAsync(x => x.Id == id);
            if (departamento == null)
            {
                return new Response { Mensaje = $"No tenemos un departamento con ese id" }; ;
            }
            departamento.Estado = 0;
            _context.Entry(departamento).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return new Response { Mensaje = $"Departamento {departamento.Nombre} eliminado correctamente" };
        }
    }
}
