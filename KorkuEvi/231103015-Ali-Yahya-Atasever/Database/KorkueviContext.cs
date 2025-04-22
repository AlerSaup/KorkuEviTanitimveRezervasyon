using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace _231103015_Ali_Yahya_Atasever.Database;

public partial class KorkueviContext : DbContext
{
    public KorkueviContext()
    {
    }

    public KorkueviContext(DbContextOptions<KorkueviContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Anasayfa> Anasayfas { get; set; }

    public virtual DbSet<Iletisimbaslik> Iletisimbasliks { get; set; }

    public virtual DbSet<Iletisimicerik> Iletisimiceriks { get; set; }

    public virtual DbSet<Kurallarbaslik> Kurallarbasliks { get; set; }

    public virtual DbSet<Kurallaricerik> Kurallariceriks { get; set; }

    public virtual DbSet<Rezervasyon> Rezervasyons { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=korkuevi;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Anasayfa>(entity =>
        {
            entity.ToTable("anasayfa");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Anasayfabaslik).HasColumnName("anasayfabaslik");
            entity.Property(e => e.Anasayfaicerik).HasColumnName("anasayfaicerik");
            entity.Property(e => e.Anasayfaresim).HasColumnName("anasayfaresim");
        });

        modelBuilder.Entity<Iletisimbaslik>(entity =>
        {
            entity.ToTable("iletisimbaslik");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Iletisimbaslik1).HasColumnName("iletisimbaslik");
        });

        modelBuilder.Entity<Iletisimicerik>(entity =>
        {
            entity.ToTable("iletisimicerik");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Iletisimadres).HasColumnName("iletisimadres");
            entity.Property(e => e.Iletisimitel).HasColumnName("iletisimitel");
        });

        modelBuilder.Entity<Kurallarbaslik>(entity =>
        {
            entity.ToTable("kurallarbaslik");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Kurallarbaslik1).HasColumnName("kurallarbaslik");
        });

        modelBuilder.Entity<Kurallaricerik>(entity =>
        {
            entity.ToTable("kurallaricerik");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Kuralicerik).HasColumnName("kuralicerik");
        });

        modelBuilder.Entity<Rezervasyon>(entity =>
        {
            entity.ToTable("Rezervasyon");

            entity.Property(e => e.Ad).HasMaxLength(50);
            entity.Property(e => e.RezervasyonTarihi).HasColumnType("datetime");
            entity.Property(e => e.Soyad).HasMaxLength(50);
            entity.Property(e => e.Telefon).HasMaxLength(15);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
