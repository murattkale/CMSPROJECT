using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;


using Microsoft.AspNetCore.Http;
using System.IO;
using System.Net.Http.Headers;
using Newtonsoft.Json.Converters;

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
            var result = _IContentPageService.GetPaging(null, true, param, false, o => o.Lang, o => o.Documents, o => o.ContentPageChilds, o => o.Parent);
            result.data = result.data.OrderByDescending(o => o.CreaDate).ThenByDescending(o => o.Name).ToList();
            return Json(result);
        }

        [HttpPost]
        public JsonResult GetSelect()
        {
            var result = _IContentPageService.Where(o => o.Name != "").Result.Select(o => new { value = o.Id, text = o.Name }).ToList();
            return Json(result);
        }


        public JsonResult GetContentPageType()
        {
            var list = Enum.GetValues(typeof(ContentPageType)).Cast<int>().Select(x => new { name = ((ContentPageType)x).ToStr(), value = x.ToString(), text = ((ContentPageType)x).ExGetDescription() }).ToArray();
            return Json(list);
        }

        [HttpPost]
        public JsonResult GetContentPage()
        {
            var result = _IContentPageService.Where(null).Result.Select(o => new { value = o.Id, text = o.Name }).ToList();
            return Json(result);
        }

        [HttpPost]
        public JsonResult InsertOrUpdate(ContentPage postmodel)
        {
            try
            {
                var result = _IContentPageService.InsertOrUpdate(postmodel);
                return Json(result.ResultRow);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        [HttpPost]
        public JsonResult ImportDocumentsSingle()
        {
            try
            {
                var aa = HttpContext.Request.Form["postmodel"];
                var bb = aa[0].Replace("[", "").Replace("]", "");
                var idValue = bb.Deserialize<TextValue>().value.ToInt();
                var text = bb.Deserialize<TextValue>().text.ToStr();

                var row = new Documents();

                switch (text)
                {
                    case "ThumbImage":
                        {
                            row = _IDocumentsService.Where(o => o.ThumbImageId == idValue, false, true).Result.FirstOrDefault();
                            if (row == null) { row = new Documents(); row.Guid = Guid.NewGuid().ToString(); }
                            else
                            {
                                row.IsDeleted = null;
                            }
                            row.ThumbImageId = idValue;
                            break;
                        }
                    case "BannerImage":
                        {
                            row = _IDocumentsService.Where(o => o.BannerImageId == idValue, false, true).Result.FirstOrDefault();
                            if (row == null) { row = new Documents(); row.Guid = Guid.NewGuid().ToString(); }
                            else
                            {
                                row.IsDeleted = null;
                            }
                            row.BannerImageId = idValue;
                            break;
                        }
                    case "Picture":
                        {
                            row = _IDocumentsService.Where(o => o.PictureId == idValue, false, true).Result.FirstOrDefault();

                            if (row == null) { row = new Documents(); row.Guid = Guid.NewGuid().ToString(); }
                            else
                            {
                                row.IsDeleted = null;
                            }
                            row.PictureId = idValue;
                            break;
                        }

                }



                var files = HttpContext.Request.Form.Files.FirstOrDefault();
                string filename = ContentDispositionHeaderValue.Parse(files.ContentDisposition).FileName.ToString().Trim('"');
                row.Name = filename;
                var newfilename = Guid.NewGuid().ToString() + "." + filename.Split('.').LastOrDefault();
                var path = this.GetPathAndFilename(newfilename);
                using (FileStream output = System.IO.File.Create(path)) files.CopyTo(output);

                row.Link = newfilename;
                row.Types = "ContentPage";

                //if (row != null)
                //{
                //    if (System.IO.File.Exists(path + row.Link))
                //        System.IO.File.Delete(path + row.Link);

                //}
                //else
                //{

                //}
                var rs = _IDocumentsService.InsertOrUpdate(row);
                return Json(row);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        [HttpPost]
        public JsonResult ImportDocuments()
        {
            try
            {
                var aa = HttpContext.Request.Form["postmodel"];
                var bb = aa[0].Replace("[", "").Replace("]", "");
                var postModel = bb.Deserialize<ContentPage>();

                var files = HttpContext.Request.Form.Files.ToList();
                var Documents = new List<Documents>();
                var guid = Guid.NewGuid().ToString();

                var gallleryOrdocumentName = postModel.Name == "Gallery" ? "Gallery" : "Document";

                files.ForEach(source =>
                {
                    string filename = ContentDispositionHeaderValue.Parse(source.ContentDisposition).FileName.ToString().Trim('"');
                    var orjinalFileName = filename;
                    filename = Guid.NewGuid().ToString() + "." + filename.Split('.').LastOrDefault();
                    var path = this.GetPathAndFilename(filename);
                    using (FileStream output = System.IO.File.Create(path))
                        source.CopyTo(output);

                    var row = new Documents
                    {
                        DocumentId = gallleryOrdocumentName == "Document" ? postModel?.Id : null,
                        GalleryId = gallleryOrdocumentName == "Gallery" ? postModel?.Id : null,
                        Link = filename,
                        Guid = guid,
                        Name = orjinalFileName,
                        Types = "ContentPage"
                    };
                    _IDocumentsService.InsertOrUpdate(row);
                    Documents.Add(row);
                    _IDocumentsService.SaveChanges();
                });

                return Json(Documents);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        public JsonResult DeleteImage(int id)
        {
            var result = _IDocumentsService.Where(o => o.Types == "ContentPage" && o.Id == id).Result.FirstOrDefault();

            var path = this.GetPathAndFilename(result.Link);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
            _IDocumentsService.Delete(result);
            var res = _IDocumentsService.SaveChanges();
            return Json(result.Id);
        }

        public JsonResult DeleteImageAll(int id)
        {
            var resultList = _IDocumentsService.Where(o => o.Types == "ContentPage" && o.DocumentId == id).Result.ToList();

            resultList.ForEach(result =>
            {

                var path = this.GetPathAndFilename(result.Link);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
                _IDocumentsService.Delete(result);
                var res = _IDocumentsService.SaveChanges();
            });

            return Json("ok");
        }


        public ContentPage Get(int id)
        {
            var result = _IContentPageService.Where(o => o.Id == id, true, false, o => o.Documents, o => o.ThumbImage, o => o.Picture, o => o.BannerImage, o => o.Gallery).Result.FirstOrDefault();
            if (result != null)
            {
                var dc = _IDocumentsService.Where().Result.ToList();
                result.Documents = dc.Where(o => o.DocumentId == result.Id).ToList();
                result.Gallery = dc.Where(o => o.GalleryId == result.Id).ToList();
            }
            return (result);
        }

        public JsonResult Delete(int id)
        {
            var result = _IContentPageService.Delete(id);
            _IContentPageService.SaveChanges();

            DeleteImageAll(id);

            return Json(result);
        }

        public IActionResult Index()
        {
            var selecttype = HttpContext.Request.Query["selecttype"].ToInt();
            var EnumText = ((ContentPageType)selecttype).ExGetDescription();
            ViewBag.pageTitle = (EnumText ?? "İçerik") + " Yönetimi";
            return View();
        }

        public IActionResult InsertOrUpdatePage()
        {
            var row = Get(Request.Query["id"].ToInt());
            //if (row == null || row.Id < 1)
            //{
            //    return Redirect("/ContentPage/InsertOrUpdatePage");
            //}
            ViewBag.edit = row;
            var EnumText = row?.ContentPageType.ExGetDescription();
            ViewBag.pageTitle = (EnumText ?? "İçerik") + " Yönetimi";
            return View();
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
