using System;
using System.Threading.Tasks;

namespace GoogleCrawler.Models.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> Commit();
    }
}
