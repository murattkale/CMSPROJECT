﻿using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;

using Entity;
using System;



public class OdemeDetayService : GenericRepo<CMSDBContext,OdemeDetay>, IOdemeDetayService
{


    public OdemeDetayService(CMSDBContext context, IBaseSession sessionInfo) : base(context, sessionInfo)
    {
    }
    public RModel<OdemeDetay> InsertOrUpdate(OdemeDetay model)
    {
        RModel<OdemeDetay> res = new RModel<OdemeDetay>();
        res.ResultType = new ResultType();
        res.ResultType.MessageList = new List<string>();

        //Duplicate Control
        //var modelControl = Where(o => o.Id != model.Id && o.OdemeDetayTipId == model.OdemeDetayTipId && o., false).Result.FirstOrDefault();
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
            var rs = SaveChanges();
            res.ResultType.RType = RType.OK;
        }
        return res;
    }






}

