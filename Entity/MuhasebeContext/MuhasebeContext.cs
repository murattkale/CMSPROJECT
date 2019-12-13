using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Entity
{
    public partial class MuhasebeContext : DbContext
    {
        public MuhasebeContext()
        {
        }

        public MuhasebeContext(DbContextOptions<MuhasebeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Banka> Banka { get; set; }
        public virtual DbSet<Hesap> Hesap { get; set; }
        public virtual DbSet<HesapTip> HesapTip { get; set; }
        public virtual DbSet<Kasa> Kasa { get; set; }
        public virtual DbSet<KasaTip> KasaTip { get; set; }
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

            modelBuilder.Entity<Hesap>(entity =>
            {

                entity.HasOne(d => d.HesapTip)
                    .WithMany(p => p.Hesap)
                    .HasForeignKey(d => d.HesapTipId)
                    .OnDelete(DeleteBehavior.Cascade);
                //.HasConstraintName("FK_GelirGider_GelirGiderTip");

                entity.HasOne(d => d.IlgiliKasa)
                    .WithMany(p => p.Hesap)
                    .HasForeignKey(d => d.IlgiliKasaId)
                    .OnDelete(DeleteBehavior.Cascade);
                //.HasConstraintName("FK_GelirGider_Kasa");

                entity.HasOne(d => d.KasaTip)
                    .WithMany(p => p.Hesap)
                    .HasForeignKey(d => d.KasaTipId);
                //.HasConstraintName("FK_GelirGider_KasaTip");
            });


            modelBuilder.Entity<Kasa>(entity =>
            {

                entity.HasOne(d => d.KasaTip)
                    .WithMany(p => p.Kasa)
                    .HasForeignKey(d => d.KasaTipId)
                    .OnDelete(DeleteBehavior.Cascade);
                //.HasConstraintName("FK_Kasa_KasaTip");

                entity.HasOne(d => d.ParaBirim)
                    .WithMany(p => p.Kasa)
                    .HasForeignKey(d => d.ParaBirimId);
                //.HasConstraintName("FK_Kasa_ParaBirimi");

                entity.HasOne(d => d.UstKasa)
                    .WithMany(p => p.InverseUstKasa)
                    .HasForeignKey(d => d.UstKasaId);
                //.HasConstraintName("FK_Kasa_Kasa");
            });

            modelBuilder.Entity<KasaTip>(entity =>
            {

                //entity.HasOne(d => d.Banka);
                    //.WithMany(p => p.KasaTip)
                    //.HasForeignKey(d => d.BankaId)
                    //.OnDelete(DeleteBehavior.Cascade);
                //.HasConstraintName("FK_KasaTip_Banka");
            });


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
