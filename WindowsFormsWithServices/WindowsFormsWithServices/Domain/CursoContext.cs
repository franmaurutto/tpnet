using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Domain
{
    internal class CursoContext : DbContext
    {
        internal DbSet<Curso> Cursos { get; set; }

        internal CursoContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Initial Catalog=NETdb");
    }
}