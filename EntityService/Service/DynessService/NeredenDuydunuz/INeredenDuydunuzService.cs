using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;

using Entity;
using System;



public interface INeredenDuydunuzService : IGenericRepo<NeredenDuydunuz>
{
    RModel<NeredenDuydunuz> InsertOrUpdate(NeredenDuydunuz model);

}

