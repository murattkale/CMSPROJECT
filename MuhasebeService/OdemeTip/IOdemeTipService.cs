using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;

using Entity;
using System;



public interface IOdemeTipService : IGenericRepo<OdemeTip>
{
    RModel<OdemeTip> InsertOrUpdate(OdemeTip model);



}


