using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SampleSite.Models;

public partial class SampleContext : DbContext
{
    public SampleContext()
    {
    }

    public SampleContext(DbContextOptions<SampleContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<PersonWare> PersonWares { get; set; }

    public virtual DbSet<Ware> Wares { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("Data Source=.\\Data\\sample.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>(entity =>
        {
            entity.ToTable("Person");
        });

        modelBuilder.Entity<PersonWare>(entity =>
        {
            entity.ToTable("PersonWare");

            entity.HasOne(d => d.Person).WithMany(p => p.PersonWares)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Ware).WithMany(p => p.PersonWares)
                .HasForeignKey(d => d.WareId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Ware>(entity =>
        {
            entity.ToTable("Ware");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
