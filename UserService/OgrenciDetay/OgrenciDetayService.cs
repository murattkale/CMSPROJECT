using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using GenericRepository;
using Entity;
using System;
using Entity.CMSDB;
using Entity.ContextModel;


public class OgrenciDetayService : GenericRepo<OgrenciDetay>, IOgrenciDetayService
{


    public OgrenciDetayService(CMSDBContext context, IBaseSession sessionInfo) : base(context, sessionInfo)
    {
    }
    public RModel<OgrenciDetay> InsertOrUpdate(OgrenciDetay model)
    {
        RModel<OgrenciDetay> res = new RModel<OgrenciDetay>();
        res.ResultType = new ResultType();
        res.ResultType.MessageList = new List<string>();

        //Duplicate Control
        //var modelControl = Where(o => o.Id != model.Id, false).Result.FirstOrDefault();
        //if (modelControl != null)
        if(false)
        {
            //res.ResultType.RType = RType.Warning;
            //res.ResultType.MessageList.Add("Duplicate");
            //res.ResultRow = modelControl;
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

