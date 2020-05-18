using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;


public interface IMongoRepository<T> where T : class
{

    IQueryable<T> Where(Expression<Func<T, bool>> predicate = null);
    T FirstOrDefault(string id);
    List<T> GetAll();
    void Add(T entity);
    void AddRangeAsync(IEnumerable<T> entities);
    void Update(T entity);
    void UpdateAsync(T entity, Expression<Func<T, bool>> predicate);
    void DeleteAsync(T entity);
    void DeleteAsync(string id);
    void DeleteAsync(Expression<Func<T, bool>> filter);
    void Dispose();



}



