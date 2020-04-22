using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public interface IMongoRepository<T> : IDisposable where T : class
{
    T Add(T obj);
    Task<T> GetById(Guid id);
    Task<IEnumerable<T>> GetAll();
    T Update(T obj);
    void Remove(Guid id);
}



