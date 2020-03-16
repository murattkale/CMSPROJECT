using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;


using System;



public interface IModelService : IGenericRepo<Model>
{
    RModel<Model> InsertOrUpdate(Model model);

}

