using System;
using Entity;
using Entity.ContextModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Entity.ContextModel
{
    public partial class CMSDBContext : DbContext
    {
        public CMSDBContext()
        {
        }

        public CMSDBContext(DbContextOptions<CMSDBContext> options)
            : base(options)
        {

        }

        public virtual DbSet<Banka> Banka { get; set; }
        public virtual DbSet<Brans> Brans { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<ContentPage> ContentPage { get; set; }
        public virtual DbSet<Ders> Ders { get; set; }
        public virtual DbSet<DersBrans> DersBrans { get; set; }
        public virtual DbSet<DersGrup> DersGrup { get; set; }
        public virtual DbSet<Derslik> Derslik { get; set; }
        public virtual DbSet<Hesap> Hesap { get; set; }
        public virtual DbSet<HesapTip> HesapTip { get; set; }
        public virtual DbSet<Kasa> Kasa { get; set; }
        public virtual DbSet<Kiyafet> Kiyafet { get; set; }
        public virtual DbSet<KiyafetTur> KiyafetTur { get; set; }
        public virtual DbSet<Kurum> Kurum { get; set; }
        public virtual DbSet<NeredenDuydunuz> NeredenDuydunuz { get; set; }
        public virtual DbSet<OdemeDetay> OdemeDetay { get; set; }
        public virtual DbSet<OdemeTip> OdemeTip { get; set; }
        public virtual DbSet<OgrenciDetay> OgrenciDetay { get; set; }
        public virtual DbSet<OgrenciSozlesme> OgrenciSozlesme { get; set; }
        public virtual DbSet<OgrenciSozlesmeKiyafet> OgrenciSozlesmeKiyafet { get; set; }
        public virtual DbSet<OgrenciSozlesmeOdemeTablosu> OgrenciSozlesmeOdemeTablosu { get; set; }
        public virtual DbSet<OgrenciSozlesmeYayin> OgrenciSozlesmeYayin { get; set; }
        public virtual DbSet<Okullar> Okullar { get; set; }
        public virtual DbSet<ParaBirimi> ParaBirimi { get; set; }
        public virtual DbSet<Permissions> Permissions { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Seans> Seans { get; set; }
        public virtual DbSet<ServiceConfig> ServiceConfig { get; set; }
        public virtual DbSet<ServiceConfigAuth> ServiceConfigAuth { get; set; }
        public virtual DbSet<Servis> Servis { get; set; }
        public virtual DbSet<Sezon> Sezon { get; set; }
        public virtual DbSet<Sinif> Sinif { get; set; }
        public virtual DbSet<SinifOgrenci> SinifOgrenci { get; set; }
        public virtual DbSet<Sozlesme> Sozlesme { get; set; }
        public virtual DbSet<SozlesmeTur> SozlesmeTur { get; set; }
        public virtual DbSet<Sube> Sube { get; set; }
        public virtual DbSet<Town> Town { get; set; }
        public virtual DbSet<UserRoles> UserRoles { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<VeliDetay> VeliDetay { get; set; }
        public virtual DbSet<Yayin> Yayin { get; set; }
        public virtual DbSet<Formlar> Formlar { get; set; }
        public virtual DbSet<Documents> Documents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer("Server=94.73.145.8;Database=u9073914_cms;user id=u9073914_cms;password=GTuw14C7TOcs14E;MultipleActiveResultSets=True;");
                optionsBuilder.UseSqlServer("Server=.;Database=u9073914_cms;user id=sa;password=123_*1;MultipleActiveResultSets=True;",
                    x => x.MigrationsHistoryTable("__EFMigrationsHistory", "mySchema")
                    );
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Documents>(entity =>
            {
                entity.Property(e => e.dataid).IsRequired();

                entity.Property(e => e.CreaDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsDeleted).HasColumnType("datetime");

                entity.Property(e => e.ModDate).HasColumnType("datetime");

                entity.HasOne(d => d.ContentPage)
                    .WithMany(p => p.Documents)
                    .HasForeignKey(d => d.dataid)
                    .HasConstraintName("FK_Documents_Documents");
            });


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

            modelBuilder.Entity<City>(entity =>
            {
                entity.Property(e => e.CityName).IsRequired();

                entity.Property(e => e.CreaDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsDeleted).HasColumnType("datetime");

                entity.Property(e => e.ModDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<ContentPage>(entity =>
            {
                entity.Property(e => e.CreaDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsDeleted).HasColumnType("datetime");

                entity.Property(e => e.IsFooterMenu).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsHamburgerMenu).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsHeaderMenu).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsSideMenu).HasDefaultValueSql("((0))");

                entity.Property(e => e.ModDate).HasColumnType("datetime");

                entity.Property(e => e.Name).IsRequired();

                entity.HasOne(d => d.Kurum)
                    .WithMany(p => p.ContentPage)
                    .HasForeignKey(d => d.KurumId)
                    .HasConstraintName("FK_ContentPage_Kurum");

                entity.HasOne(d => d.Sube)
                    .WithMany(p => p.ContentPage)
                    .HasForeignKey(d => d.SubeId)
                    .HasConstraintName("FK_ContentPage_Sube");
            });

            modelBuilder.Entity<Ders>(entity =>
            {
                entity.Property(e => e.Ad).IsRequired();

                entity.Property(e => e.CreaDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsDeleted).HasColumnType("datetime");

                entity.Property(e => e.ModDate).HasColumnType("datetime");

                entity.HasOne(d => d.DersGrup)
                    .WithMany(p => p.Ders)
                    .HasForeignKey(d => d.DersGrupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ders_DersGrup");
            });

            modelBuilder.Entity<DersBrans>(entity =>
            {
                entity.Property(e => e.CreaDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsDeleted).HasColumnType("datetime");

                entity.Property(e => e.ModDate).HasColumnType("datetime");

                entity.HasOne(d => d.Brans)
                    .WithMany(p => p.DersBrans)
                    .HasForeignKey(d => d.BransId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DersBrans_Brans");

                entity.HasOne(d => d.Ders)
                    .WithMany(p => p.DersBrans)
                    .HasForeignKey(d => d.DersId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DersBrans_Ders");
            });

            modelBuilder.Entity<DersGrup>(entity =>
            {
                entity.Property(e => e.Ad).IsRequired();

                entity.Property(e => e.CreaDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsDeleted).HasColumnType("datetime");

                entity.Property(e => e.ModDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Derslik>(entity =>
            {
                entity.Property(e => e.Ad).IsRequired();

                entity.Property(e => e.CreaDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsDeleted).HasColumnType("datetime");

                entity.Property(e => e.ModDate).HasColumnType("datetime");

                entity.HasOne(d => d.Sube)
                    .WithMany(p => p.Derslik)
                    .HasForeignKey(d => d.SubeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Derslik_Sube");
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

                entity.HasOne(d => d.Kurum)
                    .WithMany(p => p.Kasa)
                    .HasForeignKey(d => d.KurumId)
                    .HasConstraintName("FK_Kasa_Kurum");

                entity.HasOne(d => d.ParaBirim)
                    .WithMany(p => p.Kasa)
                    .HasForeignKey(d => d.ParaBirimId)
                    .HasConstraintName("FK_Kasa_ParaBirimi");

                entity.HasOne(d => d.Sube)
                    .WithMany(p => p.Kasa)
                    .HasForeignKey(d => d.SubeId)
                    .HasConstraintName("FK_Kasa_Sube");

                entity.HasOne(d => d.UstKasa)
                    .WithMany(p => p.UstKasaList)
                    .HasForeignKey(d => d.UstKasaId)
                    .HasConstraintName("FK_Kasa_Kasa");
            });

            modelBuilder.Entity<Kiyafet>(entity =>
            {
                entity.Property(e => e.Ad).IsRequired();

                entity.Property(e => e.CreaDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsDeleted).HasColumnType("datetime");

                entity.Property(e => e.ModDate).HasColumnType("datetime");

                entity.HasOne(d => d.KiyafetTur)
                    .WithMany(p => p.Kiyafet)
                    .HasForeignKey(d => d.KiyafetTurId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Kiyafet_KiyafetTur");
            });

            modelBuilder.Entity<KiyafetTur>(entity =>
            {
                entity.Property(e => e.Ad).IsRequired();

                entity.Property(e => e.CreaDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsDeleted).HasColumnType("datetime");

                entity.Property(e => e.ModDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Kurum>(entity =>
            {
                entity.Property(e => e.Ad).IsRequired();

                entity.Property(e => e.CreaDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsDeleted).HasColumnType("datetime");

                entity.Property(e => e.ModDate).HasColumnType("datetime");

                entity.HasOne(d => d.Town)
                    .WithMany(p => p.Kurum)
                    .HasForeignKey(d => d.TownId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Kurum_Town");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Kurum)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Kurum_City");
            });

            modelBuilder.Entity<NeredenDuydunuz>(entity =>
            {
                entity.Property(e => e.CreaDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsDeleted).HasColumnType("datetime");

                entity.Property(e => e.ModDate).HasColumnType("datetime");

                entity.Property(e => e.Name).IsRequired();
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

            modelBuilder.Entity<OgrenciDetay>(entity =>
            {
                entity.Property(e => e.CreaDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsDeleted).HasColumnType("datetime");

                entity.Property(e => e.ModDate).HasColumnType("datetime");

                entity.HasOne(d => d.NeredenDuydunuz)
                    .WithMany(p => p.OgrenciDetay)
                    .HasForeignKey(d => d.NeredenDuydunuzId)
                    .HasConstraintName("FK_OgrenciDetay_NeredenDuydunuz");

                entity.HasOne(d => d.Okullar)
                    .WithMany(p => p.OgrenciDetay)
                    .HasForeignKey(d => d.OkullarId)
                    .HasConstraintName("FK_OgrenciDetay_Okullar");
            });

            modelBuilder.Entity<OgrenciSozlesme>(entity =>
            {
                entity.Property(e => e.CreaDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsDeleted).HasColumnType("datetime");

                entity.Property(e => e.ModDate).HasColumnType("datetime");

                entity.Property(e => e.TaksitBaslangic).HasColumnType("datetime");

                entity.HasOne(d => d.Finansor)
                    .WithMany(p => p.OgrenciSozlesme)
                    .HasForeignKey(d => d.FinansorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OgrenciSozlesme_VeliDetay");

                entity.HasOne(d => d.GorusenPersonel)
                    .WithMany(p => p.OgrenciSozlesmeGorusenPersonel)
                    .HasForeignKey(d => d.GorusenPersonelId)
                    .HasConstraintName("FK_OgrenciSozlesme_Users");

                entity.HasOne(d => d.KurumaGetirenPersonel)
                    .WithMany(p => p.OgrenciSozlesmeKurumaGetirenPersonel)
                    .HasForeignKey(d => d.KurumaGetirenPersonelId)
                    .HasConstraintName("FK_OgrenciSozlesme_Users1");

                entity.HasOne(d => d.OgrenciDetay)
                    .WithMany(p => p.OgrenciSozlesme)
                    .HasForeignKey(d => d.OgrenciDetayId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OgrenciSozlesme_OgrenciDetay");

                entity.HasOne(d => d.Servis)
                    .WithMany(p => p.OgrenciSozlesme)
                    .HasForeignKey(d => d.ServisId)
                    .HasConstraintName("FK_OgrenciSozlesme_Servis");

                entity.HasOne(d => d.Sezon)
                    .WithMany(p => p.OgrenciSozlesme)
                    .HasForeignKey(d => d.SezonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OgrenciSozlesme_Sezon");

                entity.HasOne(d => d.SozlesmeTuru)
                    .WithMany(p => p.OgrenciSozlesme)
                    .HasForeignKey(d => d.SozlesmeTuruId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OgrenciSozlesme_SozlesmeTur");

                entity.HasOne(d => d.Sube)
                    .WithMany(p => p.OgrenciSozlesme)
                    .HasForeignKey(d => d.SubeId)
                    .HasConstraintName("FK_OgrenciSozlesme_Sube");
            });

            modelBuilder.Entity<OgrenciSozlesmeKiyafet>(entity =>
            {
                entity.Property(e => e.CreaDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsDeleted).HasColumnType("datetime");

                entity.Property(e => e.ModDate).HasColumnType("datetime");

                entity.HasOne(d => d.Kiyafet)
                    .WithMany(p => p.OgrenciSozlesmeKiyafet)
                    .HasForeignKey(d => d.KiyafetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OgrenciSozlesmeKiyafet_Kiyafet");

                entity.HasOne(d => d.OgrenciSozlesme)
                    .WithMany(p => p.OgrenciSozlesmeKiyafet)
                    .HasForeignKey(d => d.OgrenciSozlesmeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OgrenciSozlesmeKiyafet_OgrenciSozlesme");
            });

            modelBuilder.Entity<OgrenciSozlesmeOdemeTablosu>(entity =>
            {
                entity.Property(e => e.CreaDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsDeleted).HasColumnType("datetime");

                entity.Property(e => e.ModDate).HasColumnType("datetime");

                entity.Property(e => e.PesinatTarih).HasColumnType("datetime");

                entity.HasOne(d => d.OgrenciSozlesme)
                    .WithMany(p => p.OgrenciSozlesmeOdemeTablosu)
                    .HasForeignKey(d => d.OgrenciSozlesmeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OgrenciSozlesmeOdemeTablosu_OgrenciSozlesme");
            });

            modelBuilder.Entity<OgrenciSozlesmeYayin>(entity =>
            {
                entity.Property(e => e.CreaDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsDeleted).HasColumnType("datetime");

                entity.Property(e => e.ModDate).HasColumnType("datetime");

                entity.HasOne(d => d.OgrenciSozlesme)
                    .WithMany(p => p.OgrenciSozlesmeYayin)
                    .HasForeignKey(d => d.OgrenciSozlesmeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OgrenciSozlesmeYayin_OgrenciSozlesme");

                entity.HasOne(d => d.Yayin)
                    .WithMany(p => p.OgrenciSozlesmeYayin)
                    .HasForeignKey(d => d.YayinId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OgrenciSozlesmeYayin_Yayin");
            });

            modelBuilder.Entity<Okullar>(entity =>
            {
                entity.Property(e => e.Ad).IsRequired();

                entity.Property(e => e.CreaDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsDeleted).HasColumnType("datetime");

                entity.Property(e => e.ModDate).HasColumnType("datetime");
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

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.ParentRoles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_Roles_Roles");

                entity.HasOne(d => d.ServiceConfig)
                    .WithMany(p => p.Roles)
                    .HasForeignKey(d => d.ServiceConfigId)
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

                entity.HasOne(d => d.Sube)
                    .WithMany(p => p.Seans)
                    .HasForeignKey(d => d.SubeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Seans_Sube");
            });

            modelBuilder.Entity<ServiceConfig>(entity =>
            {
                entity.Property(e => e.CreaDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.IsDeleted).HasColumnType("datetime");

                entity.Property(e => e.ModDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ServiceName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasMaxLength(500);

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
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ServiceConfigAuth_ServiceConfig");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ServiceConfigAuth)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_ServiceConfigAuth_Users");
            });

            modelBuilder.Entity<Servis>(entity =>
            {
                entity.Property(e => e.CreaDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Guzergah).IsRequired();

                entity.Property(e => e.IsDeleted).HasColumnType("datetime");

                entity.Property(e => e.ModDate).HasColumnType("datetime");

                entity.Property(e => e.Plaka).IsRequired();
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

                entity.HasOne(d => d.Ogrenci)
                    .WithMany(p => p.SinifOgrenci)
                    .HasForeignKey(d => d.OgrenciId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SinifOgrenci_Users");

                entity.HasOne(d => d.Sinif)
                    .WithMany(p => p.SinifOgrenci)
                    .HasForeignKey(d => d.SinifId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SinifOgrenci_Sinif");
            });

            modelBuilder.Entity<Sozlesme>(entity =>
            {
                entity.Property(e => e.Ad).IsRequired();

                entity.Property(e => e.CreaDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsDeleted).HasColumnType("datetime");

                entity.Property(e => e.Metin)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.ModDate).HasColumnType("datetime");

                entity.HasOne(d => d.Sube)
                    .WithMany(p => p.Sozlesme)
                    .HasForeignKey(d => d.SubeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sozlesme_Sube");
            });

            modelBuilder.Entity<SozlesmeTur>(entity =>
            {
                entity.Property(e => e.Ad).IsRequired();

                entity.Property(e => e.CreaDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsDeleted).HasColumnType("datetime");

                entity.Property(e => e.ModDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Sube>(entity =>
            {
                entity.Property(e => e.Ad).IsRequired();

                entity.Property(e => e.CreaDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsDeleted).HasColumnType("datetime");

                entity.Property(e => e.ModDate).HasColumnType("datetime");

                entity.HasOne(d => d.Town)
                    .WithMany(p => p.Sube)
                    .HasForeignKey(d => d.TownId)
                    .HasConstraintName("FK_Sube_Town");

                entity.HasOne(d => d.Kurum)
                    .WithMany(p => p.Sube)
                    .HasForeignKey(d => d.KurumId)
                    .HasConstraintName("FK_Sube_Kurum");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Sube)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK_Sube_City");
            });

            modelBuilder.Entity<Town>(entity =>
            {
                entity.Property(e => e.CreaDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsDeleted).HasColumnType("datetime");

                entity.Property(e => e.ModDate).HasColumnType("datetime");

                entity.Property(e => e.TownName).IsRequired();

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Town)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Town__CityId__1F2E9E6D");
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
                entity.Property(e => e.Adress1).HasMaxLength(1000);

                entity.Property(e => e.Adress2).HasMaxLength(1000);

                entity.Property(e => e.BirdhDay).HasColumnType("datetime");

                entity.Property(e => e.CreaDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsDeleted).HasColumnType("datetime");

                entity.Property(e => e.Mail1).HasMaxLength(50);

                entity.Property(e => e.Mail2).HasMaxLength(50);

                entity.Property(e => e.ModDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Pass)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Phone1).HasMaxLength(50);

                entity.Property(e => e.Phone2).HasMaxLength(50);

                entity.Property(e => e.Phone3).HasMaxLength(50);

                entity.Property(e => e.ProfilImage).HasMaxLength(1000);

                entity.Property(e => e.SexType)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Tc)
                    .IsRequired()
                    .HasMaxLength(11);

                entity.Property(e => e.UserNo).HasMaxLength(50);

                entity.Property(e => e.ZipCode).HasMaxLength(50);
            });

            modelBuilder.Entity<VeliDetay>(entity =>
            {
                entity.Property(e => e.CreaDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsDeleted).HasColumnType("datetime");

                entity.Property(e => e.ModDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Yayin>(entity =>
            {
                entity.Property(e => e.Ad).IsRequired();

                entity.Property(e => e.CreaDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsDeleted).HasColumnType("datetime");

                entity.Property(e => e.ModDate).HasColumnType("datetime");

                entity.HasOne(d => d.Brans)
                    .WithMany(p => p.Yayin)
                    .HasForeignKey(d => d.BransId)
                    .HasConstraintName("FK_Yayin_Brans");

                entity.HasOne(d => d.Ders)
                    .WithMany(p => p.Yayin)
                    .HasForeignKey(d => d.DersId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Yayin_Ders");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
