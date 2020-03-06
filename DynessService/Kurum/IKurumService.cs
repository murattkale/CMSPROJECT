using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;

using Entity;
using System;



public interface IKurumService : IGenericRepo<Kurum>
{
    RModel<Kurum> InsertOrUpdate(Kurum model);

}

