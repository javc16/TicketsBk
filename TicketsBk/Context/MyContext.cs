using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketsBk.Features.Proyectos;
using TicketsBk.Features.Departamentos;
using TicketsBk.Features.Categorias;
using TicketsBk.Features.Estados;
using TicketsBk.Features.Tickets;

namespace TicketsBk.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        { }

        public DbSet<Proyecto> Proyecto { get; set; }
        public DbSet<Desarrollador> Desarrollador { get; set; }
        public DbSet<ProductOwner> ProductOwner { get; set; }
        public DbSet<Departamento> Departamento { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<EstadoTicket> EstadoTicket { get; set; }
        public DbSet<Ticket> Ticket { get; set; }








        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer(@"Server=ARAX;Database=HelpDesk;Trusted_Connection=True;");
        }
    }
}
