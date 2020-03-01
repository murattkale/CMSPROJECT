using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using GenericRepository;
using Entity;
using System;


public interface IYayinService : IGenericRepo<Yayin>
{
    RModel<Yayin> InsertOrUpdate(Yayin model);

}

