using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Curso.ApiPrueba.Model;

public partial class CursoDbContext : DbContext
{
    public CursoDbContext()
    {
    }

    public CursoDbContext(DbContextOptions<CursoDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bitacora> Bitacoras { get; set; }

    public virtual DbSet<Curso> Cursos { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-2UQ9A34\\SQLEXPRESS;Initial Catalog=CursoDB;Integrated Security=False;User ID=sa;Password=12345678;Connect Timeout=60;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bitacora>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Bitacora");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany()
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Bitacora__IdUsua__48CFD27E");
        });

        modelBuilder.Entity<Curso>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cursos__3214EC079EAF5D3A");

            entity.Property(e => e.Fecha).HasColumnType("date");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Porcentaje).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Cursos)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Cursos__IdUsuari__3B75D760");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Roles__3214EC07BAEE2B5E");

            entity.Property(e => e.Nombre)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuarios__3214EC0726F6C337");

            entity.Property(e => e.Apellidos)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Contraseña)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Correo)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.FechaNacimiento).HasColumnType("date");
            entity.Property(e => e.Nombre)
                .HasMaxLength(250)
                .IsUnicode(false);

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdRol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Usuarios__IdRol__38996AB5");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
