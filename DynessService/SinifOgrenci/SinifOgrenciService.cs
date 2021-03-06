﻿using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;

using System;
using Entity;

public class SinifOgrenciService : GenericRepo<CMSDBContext,SinifOgrenci>, ISinifOgrenciService
{


    public SinifOgrenciService(CMSDBContext context, IBaseSession sessionInfo) : base(context, sessionInfo)
    {
    }
    public RModel<SinifOgrenci> InsertOrUpdate(SinifOgrenci model)
    {
        RModel<SinifOgrenci> res = new RModel<SinifOgrenci>();
        res.ResultType = new ResultType();
        res.ResultType.MessageList = new List<string>();

        //Duplicate Control
        var modelControl = Where(o => o.Id != model.Id && o.OgrenciDetayId == model.OgrenciDetayId && o.SinifId != model.SinifId, false).Result.FirstOrDefault();
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

