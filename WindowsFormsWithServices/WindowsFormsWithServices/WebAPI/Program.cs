using Domain.Services;
using Domain.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpLogging(o => { });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    //Falta configurar de manera correcta        
    app.UseHttpLogging();
}

app.UseHttpsRedirection();

//Actualmente estamos usando los objetos del Domain Model, deberiamos usar ViewModels o DTOs         


app.MapGet("/cursos/{identificador}", (int identificador) =>
{
    CursoService cursoService = new CursoService();

    return cursoService.Get(identificador);
})
.WithName("GetCurso")
.WithOpenApi();

app.MapGet("/cursos", () =>
{
    CursoService cursoService = new CursoService();

    return cursoService.GetAll();
})
.WithName("GetAllCursos")
.WithOpenApi();

app.MapPost("/cursos", (Curso curso) =>
{
    CursoService cursoService = new CursoService();

    cursoService.Add(curso);
})
.WithName("AddCurso")
.WithOpenApi();

app.MapPut("/cursos", (Curso curso) =>
{
    ClursoService cursoService = new CursoService();

    cursoService.Update(curso);
})
.WithName("UpdateCurso")
.WithOpenApi();

app.MapDelete("/cursos/{identificador}", (int identificador) =>
{
    CursoService cursoService = new CursoService();

    cursoService.Delete(identificador);
})
.WithName("DeleteCurso")
.WithOpenApi();

app.MapGet("/profesores/{id}", (int id) =>
{
    ProfesorService profesorService = new ProfesorService();

    return profesorService.Get(id);
})
.WithName("GetProfesor")
.WithOpenApi();

app.MapGet("/profesores", () =>
{
    ProfesorService profesorService = new ProfesorService();

    return profesorService.GetAll();
})
.WithName("GetAllProfesores")
.WithOpenApi();

app.MapPost("/profesores", (Profesor profesor) =>
{
    ProfesorService profesorService = new ProfesorService();

    profesorService.Add(profesor);
})
.WithName("AddProfesor")
.WithOpenApi();

app.MapPut("/profesores", (Profesor profesor) =>
{
    ProfesorService profesorService = new ProfesorService();

    profesorService.Update(profesor);
})
.WithName("UpdateProfesor")
.WithOpenApi();

app.MapDelete("/profesores/{id}", (int id) =>
{
    ProfesorService profesorService = new ProfesorService();

    profesorService.Delete(id);
})
.WithName("DeleteProfesor")
.WithOpenApi();

app.Run();
