using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using GenericRepository;
using Entity;
using System;
using Entity.MuhasebeContext;


public interface IOdemeTipService : IGenericRepo<OdemeTip>
{
    RModel<OdemeTip> InsertOrUpdate(OdemeTip model);

    DTResult<OdemeTipModel> GetPagingCustom(
            Expression<Func<OdemeTip, bool>> filter = null
           , bool AsNoTracking = true
           , DTParameters<OdemeTipModel> param = null
           , bool IsDeletedShow = false
           , params Expression<Func<OdemeTip, object>>[] includes
           );

}


