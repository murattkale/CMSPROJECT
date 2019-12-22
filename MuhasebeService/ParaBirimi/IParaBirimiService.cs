using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using GenericRepository;
using Entity;
using System;
using Entity.MuhasebeContext;


    public interface IParaBirimiService : IGenericRepo<ParaBirimi>
    {
        RModel<ParaBirimi> InsertOrUpdate(ParaBirimi model);

        DTResult<ParaBirimi> GetPaging(
                    Expression<Func<ParaBirimi, bool>> filter = null
                   , bool AsNoTracking = true
                   , DTParameters<ParaBirimi> param = null
                   , bool IsDeletedShow = false
                   , params Expression<Func<ParaBirimi, object>>[] includes
                   );
    }

