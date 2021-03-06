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
           // optionBuilder.UseSqlServer(@"Server=DESKTOP-AICR3S2;Database=HelpDesk;User Id=sa;Password=1234");
            optionBuilder.UseSqlServer(@"Server=database-1.cwyafa0gf6ea.us-east-1.rds.amazonaws.com,1433;Database=HelpDesk;User Id=admin;Password=hola1234");
            //@"Server=database-1.cwyafa0gf6ea.us-east-1.rds.amazonaws.com,1433;Database=citizen;User Id=admin;Password=hola1234"
        }
    }
}
