using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using GenericRepository;
using Entity;
using System;
using Entity.ContextModel;


public interface INeredenDuydunuzService : IGenericRepo<NeredenDuydunuz>
{
    RModel<NeredenDuydunuz> InsertOrUpdate(NeredenDuydunuz model);

}

