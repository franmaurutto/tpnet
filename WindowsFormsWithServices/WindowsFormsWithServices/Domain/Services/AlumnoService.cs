using Domain.Model;

namespace Domain.Services
{
    public class AlumnoService
    {
        public void Add(Alumno alumno)
        {
            using var context = new AlumnoContext();

            context.Alumnos.Add(alumno);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            using var context = new AlumnoContext();

            Alumno? alumnoToDelete = context.Alumnos.Find(id);

            if (alumnoToDelete != null)
            {
                context.Alumnos.Remove(alumnoToDelete);
                context.SaveChanges();
            }
        }

        public Alumno? Get(int id)
        {
            using var context = new AlumnoContext();

            return context.Alumnos.Find(id);
        }

        public IEnumerable<Alumno> GetAll()
        {
            using var context = new AlumnoContext();

            return context.Alumnos.ToList();
        }

        public void Update(Alumno alumno)
        {
            using var context = new AlumnoContext();

            Alumno? alumnoToUpdate = context.Alumnos.Find(alumno.id);

            if (alumnoToUpdate != null)
            {
                alumnoToUpdate.NombreCompleto = alumno.NombreCompleto;
                context.SaveChanges();
            }
        }
    }
}
