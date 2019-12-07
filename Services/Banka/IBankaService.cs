using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using GenericRepository;
using Entity;
using Entity;
using System;

namespace Services
{
    public interface IBankaService : IGenericRepo<Banka>
    {
        RModel<Banka> InsertOrUpdate(Banka model);

        DTResult<Banka> GetPaging(
                    Expression<Func<Banka, bool>> filter = null
                   , bool AsNoTracking = true
                   , DTParameters<Banka> param = null
                   , bool IsDeletedShow = false
                   , params Expression<Func<Banka, object>>[] includes
                   );
    }
}
