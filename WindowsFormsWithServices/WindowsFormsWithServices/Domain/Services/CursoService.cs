using Domain.Model;
using System.Collections.Generic;

namespace Domain.Services
{
    public class CursoService
    {
        public void Add(Curso curso)
        {
            using var context = new CursoContext();

            context.Cursos.Add(curso);
            context.SaveChanges();
        }

        public void Delete(int identificador)
        {
            using var context = new CursoContext();

            Curso? cursoToDelete = context.Cursos.Find(identificador);

            if (cursoToDelete != null)
            {
                context.Cursos.Remove(cursoToDelete);
                context.SaveChanges();
            }
        }

        public Curso? Get(int identificador)
        {
            using var context = new CursoContext();

            return context.Cursos.Find(identificador);
        }

        public IEnumerable<Curso> GetAll()
        {
            using var context = new CursoContext();

            return context.Cursos.ToList();
        }

        public void Update(Curso curso)
        {
            using var context = new CursoContext();

            Curso? cursoToUpdate = context.Cursos.Find(curso.identificador);

            if (cursoToUpdate != null)
            {
                cursoToUpdate.descripcion = curso.descripcion;
                context.SaveChanges();
            }
        }
    }
}