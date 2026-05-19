using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace osztalynaplo.Models
{
    public partial class osztalynaploContext : DbContext
    {
        public osztalynaploContext()
        {
        }

        public osztalynaploContext(DbContextOptions<osztalynaploContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Jegyek> Jegyeks { get; set; } = null!;
        public virtual DbSet<Tanarok> Tanaroks { get; set; } = null!;
        public virtual DbSet<Tantargyak> Tantargyaks { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySQL("server=localhost;database= osztalynaplo;user=root;password=;ssl mode=none;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Jegyek>(entity =>
            {
                entity.ToTable("jegyek");

                entity.HasIndex(e => e.IdTanarok, "id_tanarok");

                entity.HasIndex(e => e.IdTantargyak, "id_tantargyak");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.BeirasDatuma)
                    .HasColumnType("date")
                    .HasColumnName("beiras_datuma")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.IdTanarok)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_tanarok")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.IdTantargyak)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_tantargyak")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.JegySzammal)
                    .HasColumnType("int(1)")
                    .HasColumnName("jegy_szammal")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.JegySzoveggel)
                    .HasMaxLength(10)
                    .HasColumnName("jegy_szoveggel")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.ModositasDatuma)
                    .HasColumnType("date")
                    .HasColumnName("modositas_datuma")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.IdTanarokNavigation)
                    .WithMany(p => p.Jegyeks)
                    .HasForeignKey(d => d.IdTanarok)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("jegyek_ibfk_2");

                entity.HasOne(d => d.IdTantargyakNavigation)
                    .WithMany(p => p.Jegyeks)
                    .HasForeignKey(d => d.IdTantargyak)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("jegyek_ibfk_1");
            });

            modelBuilder.Entity<Tanarok>(entity =>
            {
                entity.ToTable("tanarok");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.KeresztNev)
                    .HasMaxLength(30)
                    .HasColumnName("kereszt_nev")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Nem)
                    .HasMaxLength(10)
                    .HasColumnName("nem")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.VezetekNev)
                    .HasMaxLength(30)
                    .HasColumnName("vezetek_nev")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Tantargyak>(entity =>
            {
                entity.ToTable("tantargyak");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.TantargyLeiras)
                    .HasMaxLength(50)
                    .HasColumnName("tantargy_leiras")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.TantargyNev)
                    .HasMaxLength(20)
                    .HasColumnName("tantargy_nev")
                    .HasDefaultValueSql("'NULL'");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
