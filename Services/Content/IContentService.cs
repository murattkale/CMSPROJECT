using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using GenericRepository;
using Entity;

namespace Services
{
    public interface IContentService : IGenericRepo<Content>
    {
        RModel<Content> InsertOrUpdate(Content model);
    }
}
