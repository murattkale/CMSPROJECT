using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;

using Entity;
using System;



public interface IDerslikService : IGenericRepo<Derslik>
{
    RModel<Derslik> InsertOrUpdate(Derslik model);

}

