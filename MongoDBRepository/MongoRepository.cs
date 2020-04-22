using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using ServiceStack;


public class MongoRepository<C, T> : IMongoRepository<T> where T : class, IBaseModelMongo where C : MongoContext, new()
{
    private C _context = new C();
    public C Context { get { return _context; } set { _context = value; } }
    protected IBaseSessionMongo sessionInfo;
    public MongoRepository(C _context, IBaseSessionMongo sessionInfo) { this.sessionInfo = sessionInfo; this._context = _context; }

    protected IMongoCollection<T> DbSet;

    private void ConfigDbSet()
    {
        DbSet = _context.GetCollection<T>(typeof(T).Name);
    }

    public T Add(T t)
    {
        t.CreaUser = sessionInfo._BaseModel.CreaUser;
        t.CreaDate = DateTime.Now;

        ConfigDbSet();
        _context.AddCommand(() => DbSet.InsertOneAsync(t));
        return t;
    }

    public async Task<T> GetById(Guid id)
    {
        ConfigDbSet();
        var data = await DbSet.FindAsync(Builders<T>.Filter.Eq("_id", id));
        return data.SingleOrDefault();
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        ConfigDbSet();
        var all = await DbSet.FindAsync(Builders<T>.Filter.Empty);
        return all.ToList();
    }

    public T Update(T t)
    {
        t.ModUser = sessionInfo._BaseModel.CreaUser;
        t.ModDate = DateTime.Now;

        ConfigDbSet();
        _context.AddCommand(() => DbSet.ReplaceOneAsync(Builders<T>.Filter.Eq("_id", t.GetId()), t));
        return t;
    }

    public void Remove(Guid id)
    {
        ConfigDbSet();
        _context.AddCommand(() => DbSet.DeleteOneAsync(Builders<T>.Filter.Eq("_id", id)));
    }


    private bool disposed = false;
    protected void Dispose(bool disposing)
    {
        if (!this.disposed)
        {
            if (disposing)
            {
                Context?.Dispose();
            }
            this.disposed = true;
        }
    }
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

}
