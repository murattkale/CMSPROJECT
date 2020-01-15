using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using GenericRepository;
using Entity;
using System;
using Entity.CMSDB;


public interface IDocumentsService : IGenericRepo<Documents>
{
    RModel<Documents> InsertOrUpdate(Documents model);

}

