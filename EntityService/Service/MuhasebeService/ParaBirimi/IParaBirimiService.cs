using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;

using Entity;
using System;



    public interface IParaBirimiService : IGenericRepo<ParaBirimi>
    {
        RModel<ParaBirimi> InsertOrUpdate(ParaBirimi model);

    }

