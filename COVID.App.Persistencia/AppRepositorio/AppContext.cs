using Microsoft.EntityFrameworkCore;
using COVID.App.Dominio;

namespace COVID.App.Persistencia 
{
    public class AppContext : DbContext
    {
        public DbSet <Clase> Clases { get; set; }
        public DbSet <Directivo> Directivos { get; set; }
       
        public DbSet <Estudiante> Estudiantes { get; set; }
        public DbSet <HistoriaClinica> HistoriaClinicas { get; set; } 
        public DbSet <Persona> Personas { get; set; }
        public DbSet <Personal_Aseo> Personal_Aseo { get; set; }
        public DbSet <Profesor> Profesores { get; set; }
        public DbSet <Salon> Salones { get; set; }
        public DbSet <Sede> Sedes { get; set; }
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
          if(!optionsBuilder.IsConfigured)
           {
            optionsBuilder
            .UseSqlServer("Data Source = .; Initial Catalog =COVIDUM.Data;Integrated security=true");
           }
        }
    }
}