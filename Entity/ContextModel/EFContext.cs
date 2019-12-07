using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;


namespace Entity
{
    public partial class EFContext : DbContext
    {
        public EFContext()
        {
        }

        public EFContext(DbContextOptions<EFContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Content> Content { get; set; }
        public virtual DbSet<Images> Images { get; set; }
        public virtual DbSet<Menus> Menus { get; set; }

        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Formlar> Formlar { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //{
            ////optionsBuilder.UseLazyLoadingProxies();
            //optionsBuilder.UseNpgsql("Host=localhost;Database=ONERSENDB6;Username=postgres;Password=123_*1"
            ////,x => x.MigrationsHistoryTable("__EFMigrationsHistory", "mySchema")
            //);
            //}
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Menus>()
           .HasMany(e => e.Content)
           .WithOne(e => e.Menus)
           .HasForeignKey(e => e.MenuId);

            modelBuilder.Entity<Content>()
            .HasMany(e => e.Images)
            .WithOne(e => e.Content)
            .HasForeignKey(e => e.ContentId);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
