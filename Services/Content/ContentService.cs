using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using GenericRepository;
using Entity;

namespace Services
{
    public class ContentService : GenericRepo<Content>, IContentService
    {
        public ContentService(EFContext context, IBaseSession sessionInfo) : base(context, sessionInfo)
        {
        }
        public RModel<Content> InsertOrUpdate(Content model)
        {
            RModel<Content> res = new RModel<Content>();
            res.ResultType = new ResultType();
            res.ResultType.MessageList = new List<string>();

            //Duplicate Control
            var modelControl = Where(o => o.Id != model.Id && o.ContentName == model.ContentName, false).Result.FirstOrDefault();
            if (modelControl != null)
            {
                res.ResultType.RType = RType.Warning;
                res.ResultType.MessageList.Add("Duplicate");
                res.ResultRow = modelControl;
            }
            else
            {
                if (model.Id > 0)
                {
                    res.ResultRow = Update(model);
                }
                else
                {
                    res.ResultRow = Add(model);
                }
                SaveChanges();
                res.ResultType.RType = RType.OK;
            }
            return res;
        }




    }
}
