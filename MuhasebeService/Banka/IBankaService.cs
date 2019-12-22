using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using GenericRepository;
using Entity;
using System;
using Entity.MuhasebeContext;


public interface IBankaService : IGenericRepo<Banka>
{
    RModel<Banka> InsertOrUpdate(Banka model);

}

