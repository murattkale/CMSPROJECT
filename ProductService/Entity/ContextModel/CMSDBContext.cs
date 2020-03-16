using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;


public partial class CMSDBContext : DbContext
{
    public CMSDBContext()
    {
    }

    public CMSDBContext(DbContextOptions<CMSDBContext> options)
        : base(options)
    {

    }


    public virtual DbSet<ContentPage> ContentPage { get; set; }
    public virtual DbSet<Formlar> Formlar { get; set; }
    public virtual DbSet<Documents> Documents { get; set; }


    public virtual DbSet<User> User { get; set; }
    public virtual DbSet<Permission> Permission { get; set; }
    public virtual DbSet<Role> Role { get; set; }
    public virtual DbSet<ServiceConfig> ServiceConfig { get; set; }
    public virtual DbSet<ServiceConfigAuth> ServiceConfigAuth { get; set; }
    public virtual DbSet<Brand> Brand { get; set; }
    public virtual DbSet<Model> Model { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql("Host=78.188.40.28;Database=ProductDBS;Username=postgres;Password=123_*1", x => x.MigrationsHistoryTable("__EFMigrationsHistory", "mySchema"));

        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BaseModel>().HasQueryFilter(u => u.IsDeleted == null);

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

