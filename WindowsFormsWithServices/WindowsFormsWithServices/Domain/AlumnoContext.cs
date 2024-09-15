using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Domain
{
    internal class AlumnoContext : DbContext
    {
        internal DbSet<Alumno> Alumnos { get; set; }

        internal AlumnoContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Initial Catalog=NETdb");
    }
}