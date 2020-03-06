using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;

public interface IFormlarService : IGenericRepo<Formlar>
    {
        RModel<Formlar> InsertOrUpdate(Formlar model);
    }

