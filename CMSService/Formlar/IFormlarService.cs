using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using GenericRepository;
using Entity;
using Entity.CMSDB;

public interface IFormlarService : IGenericRepo<Formlar>
    {
        RModel<Formlar> InsertOrUpdate(Formlar model);
    }

