using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;

using Entity;
using System;


public interface IDersGrupService : IGenericRepo<DersGrup>
{
    RModel<DersGrup> InsertOrUpdate(DersGrup model);

}

