using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;

using Entity;
using System;
 


public interface IBransService : IGenericRepo<Brans>
{
    RModel<Brans> InsertOrUpdate(Brans model);

}

