using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace FaleMais.Contexts
{
    using FaleMais.Models;

    public class FaleMaisContext : DbContext
    {
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<DDD> DDDs { get; set; }
        public DbSet<Tarifa> Tarifas { get; set; }
        public DbSet<FaleMaisPlano> FaleMaisPlanos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tarifa>()
                .HasRequired(x => x.Origem)
                .WithMany()
                .HasForeignKey(x => x.OrigemNumero)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tarifa>()
                .HasRequired(x => x.Destino)
                .WithMany()
                .HasForeignKey(x => x.DestinoNumero)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Estado>()
                .HasMany(x => x.Cidades)
                .WithRequired(x => x.Estado)
                .HasForeignKey(x => x.EstadoUF);

            modelBuilder.Entity<Cidade>()
                .HasRequired(x => x.Estado)
                .WithMany(x => x.Cidades)
                .HasForeignKey(x => x.EstadoUF)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DDD>()
                .HasMany(x => x.Cidades)
                .WithRequired(x => x.DDD)
                .HasForeignKey(x => x.DDDNumero);

            modelBuilder.Entity<Cidade>()
                .HasRequired(x => x.DDD)
                .WithMany(x => x.Cidades)
                .HasForeignKey(x => x.DDDNumero)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Estado>().ToTable("Estados");
            modelBuilder.Entity<FaleMaisPlano>().ToTable("FaleMaisPlanos");
        }
    }
}