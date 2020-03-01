using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using GenericRepository;
using Entity;
using System;


public interface IOkulService : IGenericRepo<Okul>
{
    RModel<Okul> InsertOrUpdate(Okul model);

}

