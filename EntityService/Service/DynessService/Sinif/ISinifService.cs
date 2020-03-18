using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;

using Entity;
using System;



public interface ISinifService : IGenericRepo<Sinif>
{
    RModel<Sinif> InsertOrUpdate(Sinif model);

}

