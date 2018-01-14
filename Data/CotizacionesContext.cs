using Microsoft.EntityFrameworkCore;
using Cotizaciones.Models;

namespace Cotizaciones.Data {
    public class CotizacionesContext : DbContext
    {
        public CotizacionesContext(DbContextOptions<CotizacionesContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Utilizacion de SQLite como backend
            optionsBuilder.UseSqlite("Data Source=cotizaciones.db");
        }


        /// Asigna las clases para ser creadas por el dbcontext (ORM)
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Cotizacion> Cotizaciones { get; set; }

        /// Metodo que crea el modelalo de la base de datos
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {           
            /// Se asigna las foreignKey 
            /// y se hace la relacion de clase persona con la clase cotizacion
            modelBuilder.Entity<Cotizacion>()
            /// Instancia que la clase cotizacion tiene una persona
            .HasOne(p => p.Persona)
            /// Instancia que la clase persona tiene cotizaciones
            .WithMany(c => c.Cotizaciones)
            /// Asigna la relacion a travez de la llave foreana que sera el Rut
            .HasForeignKey(p => p.Rut)
            .HasConstraintName("ForeignKey_Cotizacion_Persona");

            modelBuilder.Entity<Persona>()
            /// Asigna la primary key a la clase persona
            .HasAlternateKey(p => p.Rut)
            .HasName("AlternateKey_Rut");

            
        }

    }
}