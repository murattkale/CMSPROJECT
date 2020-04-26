using MongoDB.Driver;
using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
{
    protected readonly IMongoContext Context;
    protected IMongoCollection<TEntity> DbSet;

    protected BaseRepository(IMongoContext context)
    {
        Context = context;
    }

    public virtual void Add(TEntity obj)
    {
        ConfigDbSet();
        Context.AddCommand(() => DbSet.InsertOneAsync(obj));
    }

    private void ConfigDbSet()
    {
        DbSet = DbSet == null ? Context.GetCollection<TEntity>(typeof(TEntity).Name) : DbSet;
    }

    public virtual async Task<IAsyncCursor<TEntity>> Where(Expression<Func<TEntity, bool>> filter = null)
    {
        ConfigDbSet();
        var query = await DbSet.FindAsync(filter);
        return query;
    }

    public virtual async Task<TEntity> GetById(Guid id)
    {
        ConfigDbSet();
        var data = await DbSet.FindAsync(Builders<TEntity>.Filter.Eq("_id", id));
        return data.SingleOrDefault();
    }

    public virtual async Task<IEnumerable<TEntity>> GetAll()
    {
        ConfigDbSet();
        var all = await DbSet.FindAsync(Builders<TEntity>.Filter.Empty);
        return all.ToList();
    }

    public virtual void Update(TEntity obj)
    {
        ConfigDbSet();
        Context.AddCommand(() => DbSet.ReplaceOneAsync(Builders<TEntity>.Filter.Eq("_id", obj.GetId()), obj));
    }

    public virtual void Remove(Guid id)
    {
        ConfigDbSet();
        Context.AddCommand(() => DbSet.DeleteOneAsync(Builders<TEntity>.Filter.Eq("_id", id)));
    }

    public void Dispose()
    {
        Context?.Dispose();
    }
}

