using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;

using Entity;


public class FormlarService : GenericRepo<CMSDBContext,Formlar>, IFormlarService
{
    public FormlarService(CMSDBContext context, IBaseSession sessionInfo) : base(context, sessionInfo)
    {
    }
    public RModel<Formlar> InsertOrUpdate(Formlar model)
    {
        RModel<Formlar> res = new RModel<Formlar>();
        res.ResultType = new ResultType();
        res.ResultType.MessageList = new List<string>();

        //Duplicate Control
        var modelControl = Where(o => o.Id != model.Id && o.Telefon == model.Telefon, false).Result.FirstOrDefault();
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

