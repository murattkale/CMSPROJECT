using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;

using Entity;
using System;


public class OgrenciSozlesmeOdemeTablosuService : GenericRepo<CMSDBContext,OgrenciSozlesmeOdemeTablosu>, IOgrenciSozlesmeOdemeTablosuService
{


    public OgrenciSozlesmeOdemeTablosuService(CMSDBContext context, IBaseSession sessionInfo) : base(context, sessionInfo)
    {
    }
    public RModel<OgrenciSozlesmeOdemeTablosu> InsertOrUpdate(OgrenciSozlesmeOdemeTablosu model)
    {
        RModel<OgrenciSozlesmeOdemeTablosu> res = new RModel<OgrenciSozlesmeOdemeTablosu>();
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

