using System;
using System.Threading.Tasks;


    public interface IUnitOfWorkMongo : IDisposable
    {
        Task<bool> Commit();
    }

