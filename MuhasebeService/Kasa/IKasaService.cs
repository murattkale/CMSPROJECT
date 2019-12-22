using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using GenericRepository;
using Entity;
using Entity.MuhasebeContext;

namespace Services
{
    public interface IKasaService : IGenericRepo<Kasa>
    {
        RModel<Kasa> InsertOrUpdate(Kasa model);
    }
}
