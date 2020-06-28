using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.DependencyModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public partial class CMSDBContext : DbContext
{
    public CMSDBContext()
    {
    }

    public CMSDBContext(DbContextOptions<CMSDBContext> options)
        : base(options)
    {

    }


    public virtual DbSet<Lang> Lang { get; set; }
    public virtual DbSet<ContentPage> ContentPage { get; set; }
    public virtual DbSet<Formlar> Formlar { get; set; }
    public virtual DbSet<Documents> Documents { get; set; }
    public virtual DbSet<SiteConfig> SiteConfig { get; set; }

    public virtual DbSet<User> User { get; set; }
    public virtual DbSet<Permission> Permission { get; set; }
    public virtual DbSet<Role> Role { get; set; }
    public virtual DbSet<ServiceConfig> ServiceConfig { get; set; }
    public virtual DbSet<ServiceConfigAuth> ServiceConfigAuth { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql("Host=85.98.10.19;Database=PLTDBLast;Username=postgres;Password=123_*1", x => x.MigrationsHistoryTable("__EFMigrationsHistory", "mySchema"));

        }
    }

    private static readonly MethodInfo ConfigureGlobalFiltersMethodInfo = typeof(CMSDBContext).GetMethod(nameof(ConfigureGlobalFilters), BindingFlags.Instance | BindingFlags.NonPublic);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            ConfigureGlobalFiltersMethodInfo
                .MakeGenericMethod(entityType.ClrType)
                .Invoke(this, new object[] { modelBuilder, entityType });
        }

        modelBuilder.Entity<ContentPage>()
             .HasOne(a => a.ThumbImage)
             .WithOne(b => b.ThumbImage)
             .HasForeignKey<Documents>(b => b.ThumbImageId);

        modelBuilder.Entity<ContentPage>()
              .HasOne(a => a.Picture)
              .WithOne(b => b.Picture)
              .HasForeignKey<Documents>(b => b.PictureId);

        modelBuilder.Entity<ContentPage>()
              .HasOne(a => a.BannerImage)
              .WithOne(b => b.BannerImage)
              .HasForeignKey<Documents>(b => b.BannerImageId);



        modelBuilder.Entity<ContentPage>()
            .HasMany(a => a.Documents)
            .WithOne(b => b.Document);


        modelBuilder.Entity<ContentPage>()
          .HasMany(a => a.Gallery)
          .WithOne(b => b.Gallery);

        modelBuilder.Entity<ContentPage>()
       .HasMany(a => a.ContentPageChilds)
       .WithOne(b => b.Parent);


        base.OnModelCreating(modelBuilder);
    }

    protected void ConfigureGlobalFilters<TEntity>(ModelBuilder modelBuilder, IMutableEntityType entityType) where TEntity : class
    {
        if (entityType.BaseType != null || !ShouldFilterEntity<TEntity>(entityType)) return;
        var filterExpression = CreateFilterExpression<TEntity>();
        if (filterExpression == null) return;
        //if (entityType.GetType().IsInterface==true)
        if (false)
            modelBuilder.Query<TEntity>().HasQueryFilter(filterExpression);
        else
            modelBuilder.Entity<TEntity>().HasQueryFilter(filterExpression);
    }

    protected virtual bool ShouldFilterEntity<TEntity>(IMutableEntityType entityType) where TEntity : class
    {
        return typeof(IBaseModel).IsAssignableFrom(typeof(TEntity));
    }

    protected Expression<Func<TEntity, bool>> CreateFilterExpression<TEntity>() where TEntity : class
    {
        Expression<Func<TEntity, bool>> expression = null;

        if (typeof(IBaseModel).IsAssignableFrom(typeof(TEntity)))
        {
            Expression<Func<TEntity, bool>> removedFilter = e => (DateTime)((IBaseModel)e).IsDeleted == null;
            expression = expression == null ? removedFilter : CombineExpressions(expression, removedFilter);
        }

        return expression;
    }

    protected Expression<Func<T, bool>> CombineExpressions<T>(Expression<Func<T, bool>> expression1, Expression<Func<T, bool>> expression2)
    {
        return Helpers.Combine(expression1, expression2);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

