using Domain.Model;

namespace Domain.Services
{
    public class ProfesorService
    {
        public void Add(Profesor profesor)
        {
            using var context = new ProfesorContext();

            context.Profesor.Add(profesor);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            using var context = new ProfesorContext();

            Profesor? profesorToDelete = context.Profesores.Find(id);

            if (profesorToDelete != null)
            {
                context.Profesores.Remove(profesorToDelete);
                context.SaveChanges();
            }
        }

        public Profesor? Get(int id)
        {
            using var context = new ProfesorContext();

            return context.Profesores.Find(id);
        }

        public IEnumerable<Profesor> GetAll()
        {
            using var context = new ProfesorContext();

            return context.Profesores.ToList();
        }

        public void Update(Profesor profesor)
        {
            using var context = new ProfesorContext();

            Profesor? profesorToUpdate = context.Profesores.Find(profesor.id);

            if (profesorToUpdate != null)
            {
                profesorToUpdate.nombre_y_apellido = profesor.nombre_y_apellido;
                context.SaveChanges();
            }
        }
    }
}


