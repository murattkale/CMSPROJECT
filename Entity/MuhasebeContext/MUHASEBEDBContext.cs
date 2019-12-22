using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Entity.MuhasebeContext
{
    public partial class MUHASEBEDBContext : DbContext
    {
        public MUHASEBEDBContext()
        {
        }

        public MUHASEBEDBContext(DbContextOptions<MUHASEBEDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Banka> Banka { get; set; }
        public virtual DbSet<Hesap> Hesap { get; set; }
        public virtual DbSet<HesapTip> HesapTip { get; set; }
        public virtual DbSet<Kasa> Kasa { get; set; }
        public virtual DbSet<OdemeDetay> OdemeDetay { get; set; }
        public virtual DbSet<OdemeTip> OdemeTip { get; set; }
        public virtual DbSet<ParaBirimi> ParaBirimi { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server=.;Database=MUHASEBEDB;user id=sa;password=123_*1;MultipleActiveResultSets=True;");
//            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Banka>(entity =>
            {
                entity.Property(e => e.CreaDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsDeleted).HasColumnType("datetime");

                entity.Property(e => e.ModDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Hesap>(entity =>
            {
                entity.Property(e => e.AliciKasaId).HasColumnName("aliciKasaId");

                entity.Property(e => e.CreaDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IlgiliKasaId).HasColumnName("ilgiliKasaId");

                entity.Property(e => e.IsDeleted).HasColumnType("datetime");

                entity.Property(e => e.ModDate).HasColumnType("datetime");

                entity.HasOne(d => d.AliciKasa)
                    .WithMany(p => p.HesapAliciKasa)
                    .HasForeignKey(d => d.AliciKasaId)
                    .HasConstraintName("FK_Hesap_Kasa1");

                entity.HasOne(d => d.HesapTip)
                    .WithMany(p => p.Hesap)
                    .HasForeignKey(d => d.HesapTipId)
                    .HasConstraintName("FK_Hesap_HesapTip");

                entity.HasOne(d => d.IlgiliKasa)
                    .WithMany(p => p.HesapIlgiliKasa)
                    .HasForeignKey(d => d.IlgiliKasaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Hesap_Kasa");

                entity.HasOne(d => d.OdemeTip)
                    .WithMany(p => p.Hesap)
                    .HasForeignKey(d => d.OdemeTipId)
                    .HasConstraintName("FK_Hesap_OdemeTip");
            });

            modelBuilder.Entity<HesapTip>(entity =>
            {
                entity.Property(e => e.CreaDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsDeleted).HasColumnType("datetime");

                entity.Property(e => e.ModDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Kasa>(entity =>
            {
                entity.Property(e => e.CreaDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsDeleted).HasColumnType("datetime");

                entity.Property(e => e.ModDate).HasColumnType("datetime");

                entity.HasOne(d => d.Banka)
                    .WithMany(p => p.Kasa)
                    .HasForeignKey(d => d.BankaId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Kasa_Banka");

                entity.HasOne(d => d.ParaBirim)
                    .WithMany(p => p.Kasa)
                    .HasForeignKey(d => d.ParaBirimId)
                    .HasConstraintName("FK_Kasa_ParaBirimi");

                entity.HasOne(d => d.UstKasa)
                    .WithMany(p => p.InverseUstKasa)
                    .HasForeignKey(d => d.UstKasaId)
                    .HasConstraintName("FK_Kasa_Kasa");
            });

            modelBuilder.Entity<OdemeDetay>(entity =>
            {
                entity.Property(e => e.CreaDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsDeleted).HasColumnType("datetime");

                entity.Property(e => e.ModDate).HasColumnType("datetime");

                entity.Property(e => e.VadeTarihi).HasColumnType("datetime");

                entity.HasOne(d => d.Hesap)
                    .WithMany(p => p.OdemeDetay)
                    .HasForeignKey(d => d.HesapId)
                    .HasConstraintName("FK_OdemeDetay_Hesap");
            });

            modelBuilder.Entity<OdemeTip>(entity =>
            {
                entity.Property(e => e.CreaDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsDeleted).HasColumnType("datetime");

                entity.Property(e => e.ModDate).HasColumnType("datetime");

                entity.HasOne(d => d.Banka)
                    .WithMany(p => p.OdemeTip)
                    .HasForeignKey(d => d.BankaId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_OdemeTip_Banka");
            });

            modelBuilder.Entity<ParaBirimi>(entity =>
            {
                entity.Property(e => e.Ad).IsRequired();

                entity.Property(e => e.CreaDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsDeleted).HasColumnType("datetime");

                entity.Property(e => e.Kod).IsRequired();

                entity.Property(e => e.ModDate).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
