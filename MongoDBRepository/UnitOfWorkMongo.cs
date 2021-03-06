﻿using System;
using System.Threading.Tasks;


public class UnitOfWorkMongo : IUnitOfWorkMongo
{
    private readonly IMongoContext _context;

    public UnitOfWorkMongo(IMongoContext context)
    {
        _context = context;
    }

    public async Task<bool> Commit()
    {
        var changeAmount = await _context.SaveChanges();

        return changeAmount > 0;
    }

    private bool disposed = false;
    protected void Dispose(bool disposing)
    {
        if (!this.disposed)
        {
            if (disposing)
            {
                _context.Dispose();
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

