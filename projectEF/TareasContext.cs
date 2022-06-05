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
        modelBuilder.Entity<Categoria>(categoria =>
        {
            categoria.ToTable("Category");
            categoria.HasKey(p=>p.CategoriaId);
            categoria.Property(p=>p.Nombre).IsRequired().HasMaxLength(150);
            categoria.Property(p=>p.Descripcion);
        });

         modelBuilder.Entity<Tarea>(tarea =>
        {
            tarea.ToTable("Task");
            tarea.HasKey(p=>p.TareaId);
            tarea.HasOne(p=>p.Categoria).WithMany(p=>p.Tareas).HasForeignKey(p=>p.CategoriaId);
            tarea.Property(p=>p.Titulo).IsRequired().HasMaxLength(200);
            tarea.Property(p=>p.Descripcion);
            tarea.Property(p=>p.PrioridadTarea);
            tarea.Property(p=>p.FechaCreacion);            
            tarea.Ignore(p=>p.Resumen);
        });
    }
}