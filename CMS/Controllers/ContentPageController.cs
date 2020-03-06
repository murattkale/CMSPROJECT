﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using CMS.Models;

using Entity;

using Microsoft.AspNetCore.Http;
using System.IO;
using System.Net.Http.Headers;

namespace CMS.Controllers
{
    public class ContentPageController : Controller
    {
        IHostingEnvironment _IHostingEnvironment;
        IContentPageService _IContentPageService;
        IDocumentsService _IDocumentsService;

        public ContentPageController(IHostingEnvironment _IHostingEnvironment, IContentPageService _IContentPageService, IDocumentsService _IDocumentsService)
        {
            this._IContentPageService = _IContentPageService;
            this._IDocumentsService = _IDocumentsService;
            this._IHostingEnvironment = _IHostingEnvironment;

        }

        [HttpPost]
        public JsonResult GetPaging(DTParameters<ContentPage> param, ContentPage searchModel)
        {
            var result = _IContentPageService.GetPaging(null, true, param, false, o => o.Kurum);
            result.data = result.data.OrderByDescending(o => o.Id).ThenByDescending(o => o.Name).ToList();
            return Json(result);
        }

        [HttpPost]
        public JsonResult GetParent()
        {
            var result = _IContentPageService.Where().Result.Select(o => new { value = o.Id, text = o.Name });
            return Json(result);
        }

        [HttpPost]
        public JsonResult InsertOrUpdate()
        {
            var postModel = HttpContext.Request.Form["postmodel"][0].Deserialize<ContentPage>();
            var result = _IContentPageService.InsertOrUpdate(postModel);

            if (result.ResultType.RType == RType.OK)
            {
                var files = HttpContext.Request.Form.Files.ToList();
                files.ForEach(source =>
                {
                    string filename = ContentDispositionHeaderValue.Parse(source.ContentDisposition).FileName.ToString().Trim('"');
                    var orjinalFileName = filename;
                    filename = Guid.NewGuid().ToString() + "." + filename.Split('.').LastOrDefault();
                    var path = this.GetPathAndFilename(filename);
                    using (FileStream output = System.IO.File.Create(path))
                        source.CopyTo(output);

                    _IDocumentsService.InsertOrUpdate(new Documents
                    {
                        dataid = result.ResultRow.Id,
                        Link = filename,
                        Guid = Guid.NewGuid().ToString(),
                        Name = orjinalFileName,
                        Types = "ContentPage"
                    });
                    _IDocumentsService.SaveChanges();
                });
            }
            return Json(result);
        }

        public JsonResult DeleteImage(int id)
        {
            var result = _IDocumentsService.Where(o => o.Types == "ContentPage" && o.Id == id).Result.FirstOrDefault();

            var path = this.GetPathAndFilename(result.Link);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
                _IDocumentsService.Delete(result);
                var res = _IDocumentsService.SaveChanges();
            }
            return Json(result.Id);
        }


        public ContentPage Get(int id)
        {
            var result = _IContentPageService.Where(o => o.Id == id, true, false, o => o.Documents).Result.FirstOrDefault();
            if (result != null && result.Documents.Any())
                result.Documents = result.Documents.Where(o => o.IsDeleted == null).ToList();
            return (result);
        }

        public JsonResult Delete(int id)
        {
            var result = _IContentPageService.Delete(id);
            _IContentPageService.SaveChanges();
            return Json(result);
        }

        public IActionResult Index()
        {
            ViewBag.pageTitle = "ContentPage";
            return View();
        }

        public IActionResult InsertOrUpdatePage()
        {
            ViewBag.edit = Get(Request.Query["id"].ToInt());
            return View();
        }


        public JsonResult getContentPageType()
        {
            var list = Enum.GetValues(typeof(ContentPageType)).Cast<int>().Select(x => new { value = x.ToString(), text = ((ContentPageType)x).ExGetDescription() }).ToArray();
            return Json(list);
        }

        private string GetPathAndFilename(string filename)
        {
            string path = this._IHostingEnvironment.WebRootPath + "\\uploads\\";

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            return path + filename;
        }

    }
}
