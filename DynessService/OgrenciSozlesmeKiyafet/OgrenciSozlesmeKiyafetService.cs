using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;

using Entity;
using System;


public class OgrenciSozlesmeKiyafetService : GenericRepo<CMSDBContext,OgrenciSozlesmeKiyafet>, IOgrenciSozlesmeKiyafetService
{


    public OgrenciSozlesmeKiyafetService(CMSDBContext context, IBaseSession sessionInfo) : base(context, sessionInfo)
    {
    }
    public RModel<OgrenciSozlesmeKiyafet> InsertOrUpdate(OgrenciSozlesmeKiyafet model)
    {
        RModel<OgrenciSozlesmeKiyafet> res = new RModel<OgrenciSozlesmeKiyafet>();
        res.ResultType = new ResultType();
        res.ResultType.MessageList = new List<string>();

        //Duplicate Control
        //var modelControl = Where(o => o.Id != model.Id &&  o. == model.Ad, false).Result.FirstOrDefault();
        //if (modelControl != null)
        if (false)
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

