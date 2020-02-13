using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using GenericRepository;
using Entity;
using Entity.CMSDB; using Entity.ContextModel;

public interface IFormlarService : IGenericRepo<Formlar>
    {
        RModel<Formlar> InsertOrUpdate(Formlar model);
    }

