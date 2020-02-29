using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using GenericRepository;
using Entity;
using System;
using Entity; using Entity.ContextModel;


public class OdemeTipService : GenericRepo<OdemeTip>, IOdemeTipService
{


    public OdemeTipService(CMSDBContext context, IBaseSession sessionInfo) : base(context, sessionInfo)
    {
    }
    public RModel<OdemeTip> InsertOrUpdate(OdemeTip model)
    {
        RModel<OdemeTip> res = new RModel<OdemeTip>();
        res.ResultType = new ResultType();
        res.ResultType.MessageList = new List<string>();

        //Duplicate Control
        var modelControl = Where(o => o.Id != model.Id && o.Ad == model.Ad, false).Result.FirstOrDefault();
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

    //public DTResult<OdemeTipModel> GetPagingCustom(
    //        Expression<Func<OdemeTip, bool>> filter = null
    //       , bool AsNoTracking = true
    //       , DTParameters<OdemeTipModel> param = null
    //       , bool IsDeletedShow = false
    //       , params Expression<Func<OdemeTip, object>>[] includes
    //       )
    //{
    //    var result = Where(filter, AsNoTracking, IsDeletedShow, includes).Result;

    //    var query = result.Select(o => new OdemeTipModel
    //    {
    //        Ad = o.Ad,
    //        _Banka = o.Banka
    //    });


    //    var GlobalSearchFilteredData = query.ToGlobalSearchInAllColumn<OdemeTipModel>(param);
    //    var IndividualColSearchFilteredData = GlobalSearchFilteredData.ToIndividualColumnSearch(param);
    //    var SortedFilteredData = IndividualColSearchFilteredData.ToSorting(param);
    //    var SortedData = SortedFilteredData.ToPagination(param);

    //    var rSortedData = SortedData.ToList();

    //    int Count = query.Count();


    //    var resultData = new DTResult<OdemeTipModel>
    //    {
    //        draw = param.Draw,
    //        data = rSortedData,
    //        recordsFiltered = Count,
    //        recordsTotal = Count
    //    };


    //    //Paging(o => new OdemeTipModel
    //    //{
    //    //    _OdemeTip = o,
    //    //    _Fikir = o.Fikir,
    //    //    Etiket = o.Kategori.Ad,
    //    //    ustKategoriAd1 = o.Kategori.ustKategori == null ? "" : o.Kategori.ustKategori.Ad,
    //    //    ustKategoriAd2 = o.Kategori.ustKategori.ustKategori == null ? "" : o.Kategori.ustKategori.ustKategori.Ad,
    //    //    ustKategoriAd3 = o.Kategori.ustKategori.ustKategori.ustKategori == null ? "" : o.Kategori.ustKategori.ustKategori.ustKategori.Ad,
    //    //    SLA1 = o.Departman.SLA1,
    //    //    SLA2 = o.Departman.SLA2,
    //    //    DepartmanAd = o.Departman.Ad,
    //    //}, null, true, param, false, o => o.Fikir, o => o.Departman, o => o.Kategori).ResultPaging;

    //    return resultData;

    //}




}

