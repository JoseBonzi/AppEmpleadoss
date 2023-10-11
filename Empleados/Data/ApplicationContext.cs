using System;
using System.Collections.Generic;
using Empleados.Models;
using Microsoft.EntityFrameworkCore;

namespace Empleados.Data;

public partial class ApplicationContext : DbContext
{
    public ApplicationContext()
    {
    }

    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cargo> Cargos { get; set; }

    public virtual DbSet<Ciudade> Ciudades { get; set; }

    public virtual DbSet<Credenciale> Credenciales { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Sucursale> Sucursales { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Name=cadenaConexion");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cargo>(entity =>
        {
            entity.HasKey(e => e.IdCargo);

            entity.ToTable("cargos");

            entity.Property(e => e.IdCargo)
                .ValueGeneratedNever()
                .HasColumnName("id_cargo");
            entity.Property(e => e.Nombre).HasColumnName("nombre");
        });

        modelBuilder.Entity<Ciudade>(entity =>
        {
            entity.HasKey(e => e.IdCiudad);

            entity.ToTable("ciudades");

            entity.Property(e => e.IdCiudad)
                .ValueGeneratedNever()
                .HasColumnName("id_ciudad");
            entity.Property(e => e.Nombre).HasColumnName("nombre");
        });

        modelBuilder.Entity<Credenciale>(entity =>
        {
            entity.HasKey(e => e.IdCredencial);

            entity.ToTable("credenciales");

            entity.Property(e => e.IdCredencial)
                .ValueGeneratedNever()
                .HasColumnName("id_credencial");
            entity.Property(e => e.Activo)
                .HasDefaultValueSql("1")
                .HasColumnName("activo");
            entity.Property(e => e.ActualizadoEn).HasColumnName("actualizado_en");
            entity.Property(e => e.Avatar).HasColumnName("avatar");
            entity.Property(e => e.Contrasenia).HasColumnName("contrasenia");
            entity.Property(e => e.CreadoEn).HasColumnName("creado_en");
            entity.Property(e => e.Usuario).HasColumnName("usuario");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.IdEmpleado);

            entity.ToTable("empleados");

            entity.HasIndex(e => e.IdCargo, "IX_empleados_id_cargo");

            entity.HasIndex(e => e.IdSucursal, "IX_empleados_id_sucursal");

            entity.Property(e => e.IdEmpleado)
                .ValueGeneratedNever()
                .HasColumnName("id_empleado");
            entity.Property(e => e.Activo)
                .HasDefaultValueSql("1")
                .HasColumnName("activo");
            entity.Property(e => e.Apellido).HasColumnName("apellido");
            entity.Property(e => e.Dni).HasColumnName("dni");
            entity.Property(e => e.FechaAlta).HasColumnName("fecha_alta");
            entity.Property(e => e.IdCargo).HasColumnName("id_cargo");
            entity.Property(e => e.IdJefe).HasColumnName("id_jefe");
            entity.Property(e => e.IdSucursal).HasColumnName("id_sucursal");
            entity.Property(e => e.Nombre).HasColumnName("nombre");

            entity.HasOne(d => d.IdCargoNavigation).WithMany(p => p.Empleados).HasForeignKey(d => d.IdCargo);

            entity.HasOne(d => d.IdSucursalNavigation).WithMany(p => p.Empleados).HasForeignKey(d => d.IdSucursal);
        });

        modelBuilder.Entity<Sucursale>(entity =>
        {
            entity.HasKey(e => e.IdSucursal);

            entity.ToTable("sucursales");

            entity.HasIndex(e => e.IdCiudad, "IX_sucursales_id_ciudad");

            entity.Property(e => e.IdSucursal)
                .ValueGeneratedNever()
                .HasColumnName("id_sucursal");
            entity.Property(e => e.IdCiudad).HasColumnName("id_ciudad");
            entity.Property(e => e.Nombre).HasColumnName("nombre");

            entity.HasOne(d => d.IdCiudadNavigation).WithMany(p => p.Sucursales).HasForeignKey(d => d.IdCiudad);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
