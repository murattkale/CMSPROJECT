using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using ServiceStack;


public class MongoRepository<T> : IMongoRepository<T> where T : class, IBaseModelMongo
{

    protected readonly IMongoContext _MongoContext;
    protected readonly IBaseSessionMongo sessionInfo;
    protected readonly IMongoCollection<T> Collection;
    public MongoRepository(IMongoContext _MongoContext, IBaseSessionMongo sessionInfo)
    {
        this.sessionInfo = sessionInfo;
        this._MongoContext = _MongoContext;
        this.Collection = _MongoContext.GetCollection<T>(typeof(T).Name.ToLowerInvariant());
    }

    public IQueryable<T> Where(Expression<Func<T, bool>> predicate = null)
    {
        return predicate == null
            ? Collection.AsQueryable()
            : Collection.AsQueryable().Where(predicate);
    }

    public T FirstOrDefault(string id)
    {
        var data = Collection.Find(m => m.Id == id);
        return data.FirstOrDefault();
    }

    public List<T> GetAll()
    {
        return Collection.Find(book => true).ToList();
    }

    public void Add(T entity)
    {
        entity.CreaUser = sessionInfo._BaseModel.CreaUser;
        var options = new InsertOneOptions { BypassDocumentValidation = false };
        try
        {
            _MongoContext.AddCommand(() => Collection.InsertOneAsync(entity, options));
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public void AddRangeAsync(IEnumerable<T> entities)
    {
        var options = new BulkWriteOptions { IsOrdered = false, BypassDocumentValidation = false };
        _MongoContext.AddCommand(() => Collection.BulkWriteAsync((IEnumerable<WriteModel<T>>)entities, options));
    }

    public void Update(T entity)
    {
        setModel(entity);
        //var options = new FindOneAndReplaceOptions<Profile>
        //{
        //    ReturnDocument = ReturnDocument.After
        //};
        _MongoContext.AddCommand(() => Collection.FindOneAndReplaceAsync(x => x.Id == entity.Id, entity));
    }

    public void UpdateAsync(T entity, Expression<Func<T, bool>> predicate)
    {
        setModel(entity);
        _MongoContext.AddCommand(() => Collection.FindOneAndReplaceAsync(predicate, entity));
    }

    public void DeleteAsync(T entity)
    {
        setModel(entity);
        _MongoContext.AddCommand(() => Collection.FindOneAndDeleteAsync(x => x.Id == entity.Id));
    }

    public void DeleteAsync(string id)
    {
        _MongoContext.AddCommand(() => Collection.FindOneAndDeleteAsync(x => x.Id == id));
    }

    public void DeleteAsync(Expression<Func<T, bool>> filter)
    {
        _MongoContext.AddCommand(() => Collection.FindOneAndDeleteAsync(filter));
    }


    T setModel(T entity)
    {
        entity.ModUser = sessionInfo._BaseModel.CreaUser;
        entity.ModDate = DateTime.Now;
        return entity;
    }

    private bool disposed = false;
    protected void Dispose(bool disposing)
    {
        if (!this.disposed)
        {
            if (disposing)
            {
                _MongoContext?.Dispose();
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
