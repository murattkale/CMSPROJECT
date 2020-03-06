using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;

using Entity;
using System;



public interface ISubeService : IGenericRepo<Sube>
{
    RModel<Sube> InsertOrUpdate(Sube model);

}

