using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;

using Entity;
using System;



public interface ISeansService : IGenericRepo<Seans>
{
    RModel<Seans> InsertOrUpdate(Seans model);

}

