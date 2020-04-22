﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public interface IBaseRepository<TEntity> : IDisposable where TEntity : class
{
    void Add(TEntity obj);
    Task<TEntity> GetById(Guid id);
    Task<IEnumerable<TEntity>> GetAll();
    void Update(TEntity obj);
    void Remove(Guid id);
}

