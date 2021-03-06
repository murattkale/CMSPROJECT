﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


using Entity;


namespace CMS.Controllers
{
    public class KasaController : Controller
    {
        IKasaService _service_Kasa;
        public KasaController(IKasaService _service_Kasa) { this._service_Kasa = _service_Kasa; }



        [HttpPost]
        public JsonResult GetPaging(DTParameters<Kasa> param, Kasa searchModel)
        {
            var result = _service_Kasa.GetPaging(null, true, param, false, o => o.UstKasa, o => o.Banka, o => o.ParaBirim);
            return Json(result);
        }

        [HttpPost]
        public JsonResult GetSelect()
        {
            var result = _service_Kasa.Where().Result.Select(o => new { value = o.Id, text = o.Ad });
            return Json(result);
        }

        [HttpPost]
        public JsonResult GetParent(int? Id)
        {
            var result = GetResult().Where(o => (Id == null ? true : o.Id != Id)).Select(o => new { value = o.Id,
                text = (o.Banka == null ? "" : o.Banka.Ad) 
                + (string.IsNullOrEmpty(o.Ad) ? "" : " / " + o.Ad)
            }).OrderBy(o => o.text).ToList();
            return Json(result);
        }

        IQueryable<Kasa> GetResult()
        {
            return _service_Kasa.Where(null, true, false, o => o.UstKasa, o => o.Banka, o => o.ParaBirim).Result;
        }


        public JsonResult InsertOrUpdate(Kasa postModel)
        {
            var result = _service_Kasa.InsertOrUpdate(postModel);
            return Json(result);
        }

        public Kasa Get(int id)
        {
            var result = _service_Kasa.Find(id);
            return (result);
        }

        public JsonResult Delete(int id)
        {
            var result = _service_Kasa.Delete(id);
            _service_Kasa.SaveChanges();
            return Json(result);
        }

        public IActionResult Index()
        {
            ViewBag.pageTitle = "Kasa";
            return View();
        }

        public IActionResult InsertOrUpdatePage()
        {
            ViewBag.edit = Get(Request.Query["id"].ToInt());
            return View();
        }


    }
}
