using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using GenericRepository;
using Entity;
using System;


public interface ISozlesmeTurService : IGenericRepo<SozlesmeTur>
{
    RModel<SozlesmeTur> InsertOrUpdate(SozlesmeTur model);

}

