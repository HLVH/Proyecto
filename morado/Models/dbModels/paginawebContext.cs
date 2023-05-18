using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace morado.Models.dbModels
{
    public partial class paginawebContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {
        public paginawebContext()
        {
        }

        public paginawebContext(DbContextOptions<paginawebContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Contenido> Contenidos { get; set; } = null!;
        public virtual DbSet<Directorio> Directorios { get; set; } = null!;
        public virtual DbSet<DondeVer> DondeVers { get; set; } = null!;
        public virtual DbSet<Episodio> Episodios { get; set; } = null!;
        public virtual DbSet<Genero> Generos { get; set; } = null!;
        public virtual DbSet<Opinione> Opiniones { get; set; } = null!;
        public virtual DbSet<Tempora> Temporas { get; set; } = null!;



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Contenido>(entity =>
            {
                entity.Property(e => e.IdContenido).ValueGeneratedNever();

                entity.Property(e => e.IdGeneros).ValueGeneratedOnAdd();

                entity.HasOne(d => d.IdDirectorioNavigation)
                    .WithMany(p => p.Contenidos)
                    .HasForeignKey(d => d.IdDirectorio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Contenido_Directorio");

                entity.HasOne(d => d.IdGenerosNavigation)
                    .WithMany(p => p.Contenidos)
                    .HasForeignKey(d => d.IdGeneros)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Contenido_Generos");
            });

            modelBuilder.Entity<DondeVer>(entity =>
            {
                entity.Property(e => e.IdComentarios).ValueGeneratedNever();

                entity.Property(e => e.IdContenido).ValueGeneratedOnAdd();

                entity.HasOne(d => d.IdContenidoNavigation)
                    .WithMany(p => p.DondeVers)
                    .HasForeignKey(d => d.IdContenido)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Donde ver_Contenido");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.DondeVers)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Donde ver_Usuario");
            });

            modelBuilder.Entity<Episodio>(entity =>
            {
                entity.Property(e => e.IdEpisodios).ValueGeneratedNever();

                entity.Property(e => e.IdTempora).ValueGeneratedOnAdd();

                entity.HasOne(d => d.IdTemporaNavigation)
                    .WithMany(p => p.Episodios)
                    .HasForeignKey(d => d.IdTempora)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Episodios_Tempora");
            });

            modelBuilder.Entity<Opinione>(entity =>
            {
                entity.HasKey(e => new { e.IdUsuario, e.IdContenido });

                entity.Property(e => e.IdContenido).ValueGeneratedOnAdd();

                entity.HasOne(d => d.IdContenidoNavigation)
                    .WithMany(p => p.Opiniones)
                    .HasForeignKey(d => d.IdContenido)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Opiniones_Contenido");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Opiniones)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Opiniones_Usuario");
            });

            modelBuilder.Entity<Tempora>(entity =>
            {
                entity.Property(e => e.IdTemporadas).ValueGeneratedNever();

                entity.Property(e => e.IdContenido).ValueGeneratedOnAdd();

                entity.HasOne(d => d.IdContenidoNavigation)
                    .WithMany(p => p.Temporas)
                    .HasForeignKey(d => d.IdContenido)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tempora_Contenido");
            });

        
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
