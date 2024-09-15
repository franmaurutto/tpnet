using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Domain
{
    internal class ProfesorContext : DbContext
    {
        internal DbSet<Profesor> Profesores { get; set; }

        internal ProfesorContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Initial Catalog=NETdb");
    }
}