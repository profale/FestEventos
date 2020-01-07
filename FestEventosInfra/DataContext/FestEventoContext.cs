using FestEventosDomain.Entities;
using FestEventosInfra.Properties;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FestEventosInfra.DataContext
{
    public class FestEventoContext : DbContext
    {
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Local> Locais { get; set; }

        public DbSet<EventoLocal> EventosLocais { get; set; }

        public FestEventoContext(DbContextOptions<FestEventoContext> options)
            : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(Resources.DbConnectionStringDocker);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<EventoLocal>()
                .HasKey(el => new { el.EventoId, el.LocalId });
            modelBuilder.Entity<EventoLocal>()
                .HasOne(bc => bc.Evento)
                .WithMany(b => b.EventoLocais)
                .HasForeignKey(bc => bc.EventoId);
            modelBuilder.Entity<EventoLocal>()
                .HasOne(bc => bc.Local)
                .WithMany(c => c.EventoLocais)
                .HasForeignKey(bc => bc.LocalId);
        }

        public FestEventoContext()
        {
            Database.EnsureCreated();
        }
    }
}
