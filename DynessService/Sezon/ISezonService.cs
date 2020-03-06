using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;

using Entity;
using System;



public interface ISezonService : IGenericRepo<Sezon>
{
    RModel<Sezon> InsertOrUpdate(Sezon model);

}

