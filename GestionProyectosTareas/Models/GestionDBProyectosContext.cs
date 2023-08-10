using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GestionProyectosTareas.Models
{
    public partial class GestionDBProyectosContext : DbContext
    {

        public GestionDBProyectosContext(DbContextOptions<GestionDBProyectosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Anexo> Anexo { get; set; } 
        public virtual DbSet<ParticipacionProyecto> ParticipacionProyecto { get; set; } 
        public virtual DbSet<Proyecto> Proyecto { get; set; } 
        public virtual DbSet<Role> Role { get; set; } 
        public virtual DbSet<Tarea> Tarea { get; set; } 
        public virtual DbSet<Usuario> Usuario { get; set; } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Anexo>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.NombreArchivo).HasMaxLength(100);

                entity.HasOne(d => d.Tarea)
                    .WithMany(p => p.Anexos)
                    .HasForeignKey(d => d.TareaId)
                    .HasConstraintName("FK__Anexos__TareaId__48CFD27E");
            });

            modelBuilder.Entity<ParticipacionProyecto>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Proyecto)
                    .WithMany(p => p.ParticipacionProyectos)
                    .HasForeignKey(d => d.ProyectoId)
                    .HasConstraintName("FK__Participa__Proye__403A8C7D");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.ParticipacionProyectos)
                    .HasForeignKey(d => d.UsuarioId)
                    .HasConstraintName("FK__Participa__Usuar__3F466844");
            });

            modelBuilder.Entity<Proyecto>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.FechaFin).HasColumnType("date");

                entity.Property(e => e.FechaInicio).HasColumnType("date");

                entity.Property(e => e.Título).HasMaxLength(100);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.NombreDelRol).HasMaxLength(50);
            });

            modelBuilder.Entity<Tarea>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.FechaFin).HasColumnType("date");

                entity.Property(e => e.FechaInicio).HasColumnType("date");

                entity.Property(e => e.Título).HasMaxLength(100);

                entity.HasOne(d => d.Proyecto)
                    .WithMany(p => p.Tareas)
                    .HasForeignKey(d => d.ProyectoId)
                    .HasConstraintName("FK__Tareas__Proyecto__3B75D760");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Tareas)
                    .HasForeignKey(d => d.UsuarioId)
                    .HasConstraintName("FK__Tareas__UsuarioI__3C69FB99");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Contraseña).HasMaxLength(100);

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Nombre).HasMaxLength(100);

                entity.Property(e => e.Rol).HasMaxLength(50);

                entity.HasMany(d => d.Roles)
                    .WithMany(p => p.Users)
                    .UsingEntity<Dictionary<string, object>>(
                        "UsuariosRole",
                        l => l.HasOne<Role>().WithMany().HasForeignKey("RoleId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__UsuariosR__RoleI__45F365D3"),
                        r => r.HasOne<Usuario>().WithMany().HasForeignKey("UserId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__UsuariosR__UserI__44FF419A"),
                        j =>
                        {
                            j.HasKey("UserId", "RoleId").HasName("PK__Usuarios__AF2760ADB6DCD40E");

                            j.ToTable("UsuariosRoles");
                        });
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
