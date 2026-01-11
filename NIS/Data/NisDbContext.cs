using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using NIS.Data.Models;

namespace NIS.Data;

public partial class NisDbContext : DbContext
{
    public NisDbContext()
    {
    }

    public NisDbContext(DbContextOptions<NisDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<N_DIAGNOZA> N_DIAGNOZAs { get; set; }

    public virtual DbSet<N_IZBA> N_IZBAs { get; set; }

    public virtual DbSet<N_KONTAKT> N_KONTAKTs { get; set; }

    public virtual DbSet<N_KRAJ> N_KRAJs { get; set; }

    public virtual DbSet<N_LEKAR> N_LEKARs { get; set; }

    public virtual DbSet<N_LIEK> N_LIEKs { get; set; }

    public virtual DbSet<N_OBEC> N_OBECs { get; set; }

    public virtual DbSet<N_ODDELENIE> N_ODDELENIEs { get; set; }

    public virtual DbSet<N_OKRE> N_OKREs { get; set; }

    public virtual DbSet<N_OPERACIum> N_OPERACIAs { get; set; }

    public virtual DbSet<N_OSOBNE_UDAJE> N_OSOBNE_UDAJEs { get; set; }

    public virtual DbSet<N_PACIENT> N_PACIENTs { get; set; }

    public virtual DbSet<N_PACIENTOVE_DIAGNOZY> N_PACIENTOVE_DIAGNOZies { get; set; }

    public virtual DbSet<N_PREDPI> N_PREDPIs { get; set; }

    public virtual DbSet<N_PRIJEM> N_PRIJEMs { get; set; }

    public virtual DbSet<N_SESTRA> N_SESTRAs { get; set; }

    public virtual DbSet<N_TYP_SPECIALIZACIE> N_TYP_SPECIALIZACIEs { get; set; }

    public virtual DbSet<N_VYSETRENIE> N_VYSETRENIEs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseOracle("User Id=NIS;Password=Nis12345;Data Source=localhost:1521/XEPDB1;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasDefaultSchema("NIS")
            .UseCollation("USING_NLS_COMP");

        modelBuilder.Entity<N_DIAGNOZA>(entity =>
        {
            entity.HasKey(e => e.ID_DIAGNOZY).HasName("SYS_C008268");

            entity.ToTable("N_DIAGNOZA");

            entity.Property(e => e.ID_DIAGNOZY)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER");
            entity.Property(e => e.KOD)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.NAZOV)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.POPIS)
                .HasMaxLength(400)
                .IsUnicode(false);
        });

        modelBuilder.Entity<N_IZBA>(entity =>
        {
            entity.HasKey(e => e.ID_IZBY).HasName("SYS_C008264");

            entity.ToTable("N_IZBA");

            entity.Property(e => e.ID_IZBY)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER");
            entity.Property(e => e.CISLO_IZBY)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ID_ODDELENIA).HasColumnType("NUMBER");
            entity.Property(e => e.KAPACITA).HasColumnType("NUMBER");

            entity.HasOne(d => d.ID_ODDELENIANavigation).WithMany(p => p.N_IZBAs)
                .HasForeignKey(d => d.ID_ODDELENIA)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_N_IZBA_ODDELENIE");
        });

        modelBuilder.Entity<N_KONTAKT>(entity =>
        {
            entity.HasKey(e => e.ID_KONTAKTU).HasName("SYS_C008299");

            entity.ToTable("N_KONTAKT");

            entity.Property(e => e.ID_KONTAKTU)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER");
            entity.Property(e => e.EMAIL)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.RODNE_CISLO)
                .HasMaxLength(11)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.TELEFON)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.TELEFON_PRACA)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.RODNE_CISLONavigation).WithMany(p => p.N_KONTAKTs)
                .HasForeignKey(d => d.RODNE_CISLO)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_N_KONTAKT_OS_UDAJE");
        });

        modelBuilder.Entity<N_KRAJ>(entity =>
        {
            entity.HasKey(e => e.ID_KRAJA).HasName("SYS_C008222");

            entity.ToTable("N_KRAJ");

            entity.Property(e => e.ID_KRAJA)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER");
            entity.Property(e => e.NAZOV)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<N_LEKAR>(entity =>
        {
            entity.HasKey(e => e.ID_LEKARA).HasName("SYS_C008251");

            entity.ToTable("N_LEKAR");

            entity.Property(e => e.ID_LEKARA)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER");
            entity.Property(e => e.ID_ODDELENIA).HasColumnType("NUMBER");
            entity.Property(e => e.ID_SPECIALIZACIE).HasColumnType("NUMBER");
            entity.Property(e => e.RODNE_CISLO)
                .HasMaxLength(11)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.ID_ODDELENIANavigation).WithMany(p => p.N_LEKARs)
                .HasForeignKey(d => d.ID_ODDELENIA)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_N_LEKAR_ODDELENIE");

            entity.HasOne(d => d.ID_SPECIALIZACIENavigation).WithMany(p => p.N_LEKARs)
                .HasForeignKey(d => d.ID_SPECIALIZACIE)
                .HasConstraintName("FK_N_LEKAR_SPECIALIZACIA");

            entity.HasOne(d => d.RODNE_CISLONavigation).WithMany(p => p.N_LEKARs)
                .HasForeignKey(d => d.RODNE_CISLO)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_N_LEKAR_OS_UDAJE");
        });

        modelBuilder.Entity<N_LIEK>(entity =>
        {
            entity.HasKey(e => e.SUKL_KOD).HasName("SYS_C008296");

            entity.ToTable("N_LIEK");

            entity.Property(e => e.SUKL_KOD)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ATC_KOD)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ATC_NAZOV_SK)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.BP)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.DATUM_REG).HasColumnType("DATE");
            entity.Property(e => e.DOPLNOK)
                .HasMaxLength(400)
                .IsUnicode(false);
            entity.Property(e => e.EXPIRACIA).HasColumnType("NUMBER");
            entity.Property(e => e.IDENTIFIKATOR).HasColumnType("NUMBER");
            entity.Property(e => e.KOD_DRZ)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.KOD_STATU)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.NAZOV)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.PLATNOST)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.REG_CISLO)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TYP_REG)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.VYDAJ)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<N_OBEC>(entity =>
        {
            entity.HasKey(e => e.PSC).HasName("SYS_C008230");

            entity.ToTable("N_OBEC");

            entity.Property(e => e.PSC)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ID_OKRESU).HasColumnType("NUMBER");
            entity.Property(e => e.NAZOV)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.ID_OKRESUNavigation).WithMany(p => p.N_OBECs)
                .HasForeignKey(d => d.ID_OKRESU)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_N_OBEC_OKRES");
        });

        modelBuilder.Entity<N_ODDELENIE>(entity =>
        {
            entity.HasKey(e => e.ID_ODDELENIA).HasName("SYS_C008247");

            entity.ToTable("N_ODDELENIE");

            entity.Property(e => e.ID_ODDELENIA)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER");
            entity.Property(e => e.KAPACITA).HasColumnType("NUMBER");
            entity.Property(e => e.NAZOV)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.POSCHODIE).HasColumnType("NUMBER");
        });

        modelBuilder.Entity<N_OKRE>(entity =>
        {
            entity.HasKey(e => e.ID_OKRESU).HasName("SYS_C008226");

            entity.ToTable("N_OKRES");

            entity.Property(e => e.ID_OKRESU)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER");
            entity.Property(e => e.ID_KRAJA).HasColumnType("NUMBER");
            entity.Property(e => e.NAZOV)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.ID_KRAJANavigation).WithMany(p => p.N_OKREs)
                .HasForeignKey(d => d.ID_KRAJA)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_N_OKRES_KRAJ");
        });

        modelBuilder.Entity<N_OPERACIum>(entity =>
        {
            entity.HasKey(e => e.ID_OPERACIE).HasName("SYS_C008285");

            entity.ToTable("N_OPERACIA");

            entity.Property(e => e.ID_OPERACIE)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER");
            entity.Property(e => e.DATUM_OPERACIE).HasColumnType("DATE");
            entity.Property(e => e.ID_LEKARA).HasColumnType("NUMBER");
            entity.Property(e => e.ID_PACIENTA).HasColumnType("NUMBER");
            entity.Property(e => e.POPIS)
                .HasMaxLength(400)
                .IsUnicode(false);
            entity.Property(e => e.TYP_OPERACIE)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.ID_LEKARANavigation).WithMany(p => p.N_OPERACIa)
                .HasForeignKey(d => d.ID_LEKARA)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_N_OPERACIA_LEKAR");

            entity.HasOne(d => d.ID_PACIENTANavigation).WithMany(p => p.N_OPERACIa)
                .HasForeignKey(d => d.ID_PACIENTA)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_N_OPERACIA_PACIENT");
        });

        modelBuilder.Entity<N_OSOBNE_UDAJE>(entity =>
        {
            entity.HasKey(e => e.RODNE_CISLO).HasName("SYS_C008235");

            entity.ToTable("N_OSOBNE_UDAJE");

            entity.Property(e => e.RODNE_CISLO)
                .HasMaxLength(11)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.MENO)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PRIEZVISKO)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PSC)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ULICA)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.PSCNavigation).WithMany(p => p.N_OSOBNE_UDAJEs)
                .HasForeignKey(d => d.PSC)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_N_OS_UDAJE_PSC");
        });

        modelBuilder.Entity<N_PACIENT>(entity =>
        {
            entity.HasKey(e => e.ID_PACIENTA).HasName("SYS_C008240");

            entity.ToTable("N_PACIENT");

            entity.Property(e => e.ID_PACIENTA)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER");
            entity.Property(e => e.POISTOVNA)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.RODNE_CISLO)
                .HasMaxLength(11)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.RODNE_CISLONavigation).WithMany(p => p.N_PACIENTs)
                .HasForeignKey(d => d.RODNE_CISLO)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_N_PACIENT_OS_UDAJE");
        });

        modelBuilder.Entity<N_PACIENTOVE_DIAGNOZY>(entity =>
        {
            entity.HasKey(e => new { e.ID_PACIENTA, e.ID_DIAGNOZY });

            entity.ToTable("N_PACIENTOVE_DIAGNOZY");

            entity.Property(e => e.ID_PACIENTA).HasColumnType("NUMBER");
            entity.Property(e => e.ID_DIAGNOZY).HasColumnType("NUMBER");
            entity.Property(e => e.DATUM_DIAGNOSTIKY).HasColumnType("DATE");

            entity.HasOne(d => d.ID_DIAGNOZYNavigation).WithMany(p => p.N_PACIENTOVE_DIAGNOZies)
                .HasForeignKey(d => d.ID_DIAGNOZY)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_N_PD_DIAGNOZA");

            entity.HasOne(d => d.ID_PACIENTANavigation).WithMany(p => p.N_PACIENTOVE_DIAGNOZies)
                .HasForeignKey(d => d.ID_PACIENTA)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_N_PD_PACIENT");
        });

        modelBuilder.Entity<N_PREDPI>(entity =>
        {
            entity.HasKey(e => e.ID_PREDPISU);

            entity.ToTable("N_PREDPIS");

            entity.Property(e => e.ID_PREDPISU)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER");
            entity.Property(e => e.DATUM_PREDPISU).HasColumnType("DATE");
            entity.Property(e => e.DAVKOVANIE)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ID_VYSETRENIA).HasColumnType("NUMBER");
            entity.Property(e => e.MNOZSTVO)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.POZNAMKA)
                .HasMaxLength(400)
                .IsUnicode(false);
            entity.Property(e => e.SUKL_KOD)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.ID_VYSETRENIANavigation).WithMany(p => p.N_PREDPIs)
                .HasForeignKey(d => d.ID_VYSETRENIA)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_N_PREDPIS_VYSETRENIE");

            entity.HasOne(d => d.SUKL_KODNavigation).WithMany(p => p.N_PREDPIs)
                .HasForeignKey(d => d.SUKL_KOD)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_N_PREDPIS_LIEK");
        });

        modelBuilder.Entity<N_PRIJEM>(entity =>
        {
            entity.HasKey(e => e.ID_PRIJMU).HasName("SYS_C008292");

            entity.ToTable("N_PRIJEM");

            entity.Property(e => e.ID_PRIJMU)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER");
            entity.Property(e => e.DATUM_PREPUSTENIA).HasColumnType("DATE");
            entity.Property(e => e.DATUM_PRIJMU).HasColumnType("DATE");
            entity.Property(e => e.ID_IZBY).HasColumnType("NUMBER");
            entity.Property(e => e.ID_PACIENTA).HasColumnType("NUMBER");
            entity.Property(e => e.POZNAMKA)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.STAV_PACIENTA)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.ID_IZBYNavigation).WithMany(p => p.N_PRIJEMs)
                .HasForeignKey(d => d.ID_IZBY)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_N_PRIJEM_IZBA");

            entity.HasOne(d => d.ID_PACIENTANavigation).WithMany(p => p.N_PRIJEMs)
                .HasForeignKey(d => d.ID_PACIENTA)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_N_PRIJEM_PACIENT");
        });

        modelBuilder.Entity<N_SESTRA>(entity =>
        {
            entity.HasKey(e => e.ID_SESTRY).HasName("SYS_C008258");

            entity.ToTable("N_SESTRA");

            entity.Property(e => e.ID_SESTRY)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER");
            entity.Property(e => e.ID_ODDELENIA).HasColumnType("NUMBER");
            entity.Property(e => e.RODNE_CISLO)
                .HasMaxLength(11)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.ID_ODDELENIANavigation).WithMany(p => p.N_SESTRAs)
                .HasForeignKey(d => d.ID_ODDELENIA)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_N_SESTRA_ODDELENIE");

            entity.HasOne(d => d.RODNE_CISLONavigation).WithMany(p => p.N_SESTRAs)
                .HasForeignKey(d => d.RODNE_CISLO)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_N_SESTRA_OS_UDAJE");
        });

        modelBuilder.Entity<N_TYP_SPECIALIZACIE>(entity =>
        {
            entity.HasKey(e => e.ID_SPECIALIZACIE).HasName("SYS_C008244");

            entity.ToTable("N_TYP_SPECIALIZACIE");

            entity.Property(e => e.ID_SPECIALIZACIE)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER");
            entity.Property(e => e.NAZOV)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.POPIS)
                .HasMaxLength(400)
                .IsUnicode(false);
        });

        modelBuilder.Entity<N_VYSETRENIE>(entity =>
        {
            entity.HasKey(e => e.ID_VYSETRENIA).HasName("SYS_C008278");

            entity.ToTable("N_VYSETRENIE");

            entity.Property(e => e.ID_VYSETRENIA)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER");
            entity.Property(e => e.DATUM).HasColumnType("DATE");
            entity.Property(e => e.ID_LEKARA).HasColumnType("NUMBER");
            entity.Property(e => e.ID_PACIENTA).HasColumnType("NUMBER");
            entity.Property(e => e.SNIMOK).HasColumnType("BLOB");
            entity.Property(e => e.TYP_VYSETRENIA)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.VYSLEDOK)
                .HasMaxLength(400)
                .IsUnicode(false);

            entity.HasOne(d => d.ID_LEKARANavigation).WithMany(p => p.N_VYSETRENIEs)
                .HasForeignKey(d => d.ID_LEKARA)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_N_VYSETRENIE_LEKAR");

            entity.HasOne(d => d.ID_PACIENTANavigation).WithMany(p => p.N_VYSETRENIEs)
                .HasForeignKey(d => d.ID_PACIENTA)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_N_VYSETRENIE_PACIENT");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
