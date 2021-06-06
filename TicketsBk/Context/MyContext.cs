using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketsBk.Features.Proyectos;

namespace TicketsBk.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        { }
        public DbSet<Proyecto> Proyecto { get; set; }
        public DbSet<Desarrollador> Desarrollador { get; set; }
        public DbSet<Usuario> Usuario { get; set; }








        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer(@"Server=DESKTOP-AICR3S2;Database=HelpDesk;User Id=sa;Password=1234");
        }
    }
}
