using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PruebaProject.Domain.Entities;

namespace PruebaProject.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        //constructor y demas configuraciones
        public AppDbContext(DbContextOptions<AppDbContext> options) 
        : base(options)
        {
        }

        // Tablas
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuracion de la relacion uno a uno entre Persona y Usuario
            modelBuilder.Entity<Persona>()
                .HasOne(p => p.Usuario)
                .WithOne(u => u.Persona)
                .HasForeignKey<Usuario>(u => u.PersonaId);
        }
    }
}