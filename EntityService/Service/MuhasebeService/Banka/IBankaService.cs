using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;

using Entity;
using System;



public interface IBankaService : IGenericRepo<Banka>
{
    RModel<Banka> InsertOrUpdate(Banka model);

}

