using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;

using Entity;
using System;


public interface IServisService : IGenericRepo<Servis>
{
    RModel<Servis> InsertOrUpdate(Servis model);

}

