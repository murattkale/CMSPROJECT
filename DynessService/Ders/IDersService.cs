using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;

using Entity;
using System;


public interface IDersService : IGenericRepo<Ders>
{
    RModel<Ders> InsertOrUpdate(Ders model);

}

