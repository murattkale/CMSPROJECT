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
        public virtual DbSet<Brans> Brans { get; set; }
        public virtual DbSet<Derslik> Derslik { get; set; }
        public virtual DbSet<Hesap> Hesap { get; set; }
        public virtual DbSet<HesapTip> HesapTip { get; set; }
        public virtual DbSet<Kasa> Kasa { get; set; }
        public virtual DbSet<Kurum> Kurum { get; set; }
        public virtual DbSet<OdemeDetay> OdemeDetay { get; set; }
        public virtual DbSet<OdemeTip> OdemeTip { get; set; }
        public virtual DbSet<ParaBirimi> ParaBirimi { get; set; }
        public virtual DbSet<Permissions> Permissions { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Seans> Seans { get; set; }
        public virtual DbSet<ServiceConfig> ServiceConfig { get; set; }
        public virtual DbSet<ServiceConfigAuth> ServiceConfigAuth { get; set; }
        public virtual DbSet<Sezon> Sezon { get; set; }
        public virtual DbSet<Sinif> Sinif { get; set; }
        public virtual DbSet<SinifOgrenci> SinifOgrenci { get; set; }
        public virtual DbSet<Sube> Sube { get; set; }
        public virtual DbSet<UserRoles> UserRoles { get; set; }
        public virtual DbSet<Users> Users { get; set; }

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

            modelBuilder.Entity<Brans>(entity =>
            {
                entity.Property(e => e.Ad).IsRequired();

                entity.Property(e => e.CreaDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsDeleted).HasColumnType("datetime");

                entity.Property(e => e.ModDate).HasColumnType("datetime");

                entity.HasOne(d => d.Kurum)
                    .WithMany(p => p.Brans)
                    .HasForeignKey(d => d.KurumId)
                    .HasConstraintName("FK_Brans_Kurum");
            });

            modelBuilder.Entity<Derslik>(entity =>
            {
                entity.Property(e => e.Ad).IsRequired();

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

            modelBuilder.Entity<Kurum>(entity =>
            {
                entity.Property(e => e.Ad).IsRequired();

                entity.Property(e => e.Adres).IsRequired();

                entity.Property(e => e.CreaDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsDeleted).HasColumnType("datetime");

                entity.Property(e => e.Logo).IsRequired();

                entity.Property(e => e.Mail).IsRequired();

                entity.Property(e => e.ModDate).HasColumnType("datetime");

                entity.Property(e => e.Telefon).IsRequired();

                entity.Property(e => e.TicariUnvan).IsRequired();

                entity.Property(e => e.VergiDairesi).IsRequired();

                entity.Property(e => e.VergiNo).IsRequired();
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

            modelBuilder.Entity<Permissions>(entity =>
            {
                entity.Property(e => e.CreaDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsDeleted).HasColumnType("datetime");

                entity.Property(e => e.ModDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Permissions)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Permissions_Roles");
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.Property(e => e.CreaDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsDeleted).HasColumnType("datetime");

                entity.Property(e => e.ModDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("FK_Roles_Roles");

                entity.HasOne(d => d.StartPage)
                    .WithMany(p => p.Roles)
                    .HasForeignKey(d => d.StartPageId)
                    .HasConstraintName("FK_Roles_ServiceConfig");
            });

            modelBuilder.Entity<Seans>(entity =>
            {
                entity.Property(e => e.Ad).IsRequired();

                entity.Property(e => e.CreaDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsDeleted).HasColumnType("datetime");

                entity.Property(e => e.ModDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<ServiceConfig>(entity =>
            {
                entity.Property(e => e.CreaDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.IsDeleted).HasColumnType("datetime");

                entity.Property(e => e.ModDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.ServiceName).HasMaxLength(50);

                entity.Property(e => e.Url).HasMaxLength(500);

                entity.Property(e => e.UrlTarget).HasMaxLength(50);

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("FK_ServiceConfig_ServiceConfig");
            });

            modelBuilder.Entity<ServiceConfigAuth>(entity =>
            {
                entity.Property(e => e.CreaDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsDeleted).HasColumnType("datetime");

                entity.Property(e => e.ModDate).HasColumnType("datetime");

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.ServiceConfigAuth)
                    .HasForeignKey(d => d.PermissionId)
                    .HasConstraintName("FK_ServiceConfigAuth_Permissions");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.ServiceConfigAuth)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_ServiceConfigAuth_Roles");

                entity.HasOne(d => d.ServiceConfig)
                    .WithMany(p => p.ServiceConfigAuth)
                    .HasForeignKey(d => d.ServiceConfigId)
                    .HasConstraintName("FK_ServiceConfigAuth_ServiceConfig");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ServiceConfigAuth)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_ServiceConfigAuth_Users");
            });

            modelBuilder.Entity<Sezon>(entity =>
            {
                entity.Property(e => e.Ad).IsRequired();

                entity.Property(e => e.CreaDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsDeleted).HasColumnType("datetime");

                entity.Property(e => e.ModDate).HasColumnType("datetime");

                entity.HasOne(d => d.Kurum)
                    .WithMany(p => p.Sezon)
                    .HasForeignKey(d => d.KurumId)
                    .HasConstraintName("FK_Sezon_Kurum");
            });

            modelBuilder.Entity<Sinif>(entity =>
            {
                entity.Property(e => e.Ad).IsRequired();

                entity.Property(e => e.CreaDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsDeleted).HasColumnType("datetime");

                entity.Property(e => e.ModDate).HasColumnType("datetime");

                entity.HasOne(d => d.Derslik)
                    .WithMany(p => p.Sinif)
                    .HasForeignKey(d => d.DerslikId)
                    .HasConstraintName("FK_Sinif_Derslik");

                entity.HasOne(d => d.Seans)
                    .WithMany(p => p.Sinif)
                    .HasForeignKey(d => d.SeansId)
                    .HasConstraintName("FK_Sinif_Seans");

                entity.HasOne(d => d.Sube)
                    .WithMany(p => p.Sinif)
                    .HasForeignKey(d => d.SubeId)
                    .HasConstraintName("FK_Sinif_Sube");
            });

            modelBuilder.Entity<SinifOgrenci>(entity =>
            {
                entity.Property(e => e.CreaDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsDeleted).HasColumnType("datetime");

                entity.Property(e => e.ModDate).HasColumnType("datetime");

                entity.HasOne(d => d.Sinif)
                    .WithMany(p => p.SinifOgrenci)
                    .HasForeignKey(d => d.SinifId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SinifOgrenci_Sinif");
            });

            modelBuilder.Entity<Sube>(entity =>
            {
                entity.Property(e => e.Ad).IsRequired();

                entity.Property(e => e.Adres).IsRequired();

                entity.Property(e => e.CreaDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsDeleted).HasColumnType("datetime");

                entity.Property(e => e.Logo).IsRequired();

                entity.Property(e => e.Mail).IsRequired();

                entity.Property(e => e.ModDate).HasColumnType("datetime");

                entity.Property(e => e.Telefon).IsRequired();

                entity.Property(e => e.TicariUnvan).IsRequired();

                entity.Property(e => e.VergiDairesi).IsRequired();

                entity.Property(e => e.VergiNo).IsRequired();

                entity.HasOne(d => d.Kurum)
                    .WithMany(p => p.Sube)
                    .HasForeignKey(d => d.KurumId)
                    .HasConstraintName("FK_Sube_Kurum");
            });

            modelBuilder.Entity<UserRoles>(entity =>
            {
                entity.Property(e => e.CreaDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsDeleted).HasColumnType("datetime");

                entity.Property(e => e.ModDate).HasColumnType("datetime");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_UserRoles_Roles");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_UserRoles_Users");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.Adress).HasMaxLength(1000);

                entity.Property(e => e.CreaDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsDeleted).HasColumnType("datetime");

                entity.Property(e => e.Mail)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ModDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Pass)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Tc)
                    .IsRequired()
                    .HasMaxLength(11);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
