using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using exercice_ado.Models;

namespace exercice_ado.Context;

public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Etudiant> Etudiants { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=MyDbConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Etudiant>(entity =>
        {
            entity.HasKey(e => e.Primarikey);

            entity.ToTable("ETUDIANT");

            entity.Property(e => e.Primarikey)
                .ValueGeneratedNever()
                .HasColumnName("PRIMARIKEY");
            entity.Property(e => e.DateDiplome).HasColumnName("DATE_DIPLOME");
            entity.Property(e => e.Firstname).HasColumnName("FIRSTNAME");
            entity.Property(e => e.Name).HasColumnName("NAME");
            entity.Property(e => e.NumberClass).HasColumnName("NUMBER_CLASS");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
