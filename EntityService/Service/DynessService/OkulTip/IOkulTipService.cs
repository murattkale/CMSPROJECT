using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;

using Entity;
using System;


public interface IOkulTipService : IGenericRepo<OkulTip>
{
    RModel<OkulTip> InsertOrUpdate(OkulTip model);

}

