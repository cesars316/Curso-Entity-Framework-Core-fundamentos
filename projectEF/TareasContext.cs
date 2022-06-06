using Microsoft.EntityFrameworkCore;
using projectEF.Models;

namespace projectEF;

public class TareasContext : DbContext
{
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Tarea> Tareas { get; set; }
    public TareasContext(DbContextOptions<TareasContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        List<Categoria> categoriasInit = new List<Categoria>();
        categoriasInit.Add(new Categoria() { CategoriaId = Guid.Parse("4eaf4501-49f8-4b6a-931e-f75f2212a43e"), Nombre = "Actividades pendientes", Peso = 20 });
        categoriasInit.Add(new Categoria() { CategoriaId = Guid.Parse("4eaf4501-49f8-4b6a-931e-f75f2212a401"), Nombre = "Actividades personales", Peso = 30 });
        modelBuilder.Entity<Categoria>(categoria =>
        {
            categoria.ToTable("Category");
            categoria.HasKey(p => p.CategoriaId);
            categoria.Property(p => p.Nombre).IsRequired().HasMaxLength(150);
            categoria.Property(p => p.Descripcion).IsRequired(false);
            categoria.Property(p => p.Peso);
            categoria.HasData(categoriasInit);
        });

        List<Tarea> tareasInit = new List<Tarea>();
        tareasInit.Add(new Tarea()
        {
            TareaId = Guid.Parse("4eaf4501-49f8-4b6a-931e-f75f2212a410"),
            CategoriaId = Guid.Parse("4eaf4501-49f8-4b6a-931e-f75f2212a43e"),
            PrioridadTarea = Prioridad.Media,
            Titulo = "Pago de servicios publicos",
            FechaCreacion = DateTime.Now
        });

        tareasInit.Add(new Tarea()
        {
            TareaId = Guid.Parse("4eaf4501-49f8-4b6a-931e-f75f2212a411"),
            CategoriaId = Guid.Parse("4eaf4501-49f8-4b6a-931e-f75f2212a401"),
            PrioridadTarea = Prioridad.Baja,
            Titulo = "Terminar de ver pelicula en netflix",
            FechaCreacion = DateTime.Now
        });

        modelBuilder.Entity<Tarea>(tarea =>
       {
           tarea.ToTable("Task");
           tarea.HasKey(p => p.TareaId);
           tarea.HasOne(p => p.Categoria).WithMany(p => p.Tareas).HasForeignKey(p => p.CategoriaId);
           tarea.Property(p => p.Titulo).IsRequired().HasMaxLength(200);
           tarea.Property(p => p.Descripcion).IsRequired(false);
           tarea.Property(p => p.PrioridadTarea);
           tarea.Property(p => p.FechaCreacion);
           tarea.Property(p => p.Usuario).IsRequired(false);
           tarea.Ignore(p => p.Resumen);
           tarea.HasData(tareasInit);
       });
    }
}