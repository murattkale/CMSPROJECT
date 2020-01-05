using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CMS.Controllers
{

    public class BaseController : Controller
    {
        IContentPageService _IContentPageService;
        IKurumService _IKurumService;
        ISubeService _ISubeService;
        ICityService _ICityService;
        ITownService _ITownService;
        //IFormlarService _IFormlarService;
        public BaseController(
            IContentPageService _IContentPageService,
             IKurumService _IKurumService,
        ISubeService _ISubeService,
        ICityService _ICityService,
        ITownService _ITownService
            )
        {
            this._IContentPageService = _IContentPageService;
            this._IKurumService = _IKurumService;
            this._ISubeService = _ISubeService;
            this._ICityService = _ICityService;
            this._ITownService = _ITownService;

        }



        public ActionResult getContent(ContentPageType ContentPageType)
        {
            var list = _IContentPageService.Where(o => o.KurumId == SessionRequest.KurumId && o.ContentPageType == (int)ContentPageType)
                .Result.OrderByDescending(o => o.CreaDate).AsQueryable();

            if (SessionRequest.SubeId > 0)
            {
                list = list.Where(o => o.Id == SessionRequest.SubeId);
            }

            switch (ContentPageType)
            {
                case ContentPageType.row1:
                    {
                        ViewBag.contents = list.ToList();
                        return View("row1");
                    }
                case ContentPageType.row2:
                    {
                        ViewBag.contents = list.ToList();
                        return View("row2");
                    }
                case ContentPageType.row3:
                    {
                        ViewBag.contents = list.ToList();
                        return View("row3");
                    }
                case ContentPageType.row4:
                    {
                        ViewBag.contents = list.ToList();
                        return View("row4");
                    }
                case ContentPageType.sliderUst:
                    {
                        ViewBag.contents = list.ToList();
                        return View("sliderUst");
                    }
                case ContentPageType.sliderAlt:
                    {
                        ViewBag.contents = list.ToList();
                        return View("sliderAlt");
                    }
                case ContentPageType.etkinlikler:
                    {
                        ViewBag.contents = list.ToList();
                        return View("etkinlikler");
                    }
                case ContentPageType.etkinlikler3:
                    {
                        list = _IContentPageService.Where(o => o.ContentPageType == (int)ContentPageType.etkinlikler).Result.OrderByDescending(o => o.CreaDate);
                        if (SessionRequest.SubeId > 0)
                        {
                            list = list.Where(o => o.Id == SessionRequest.SubeId);
                        }
                        ViewBag.contents = list.Take(3).ToList();
                        return View("etkinlikler3");
                    }
                case ContentPageType.haberler:
                    {
                        ViewBag.contents = list.ToList();
                        return View("haberler");
                    }
                case ContentPageType.haberler3:
                    {
                        list = _IContentPageService.Where(o => o.ContentPageType == (int)ContentPageType.haberler).Result.OrderByDescending(o => o.CreaDate);
                        if (SessionRequest.SubeId > 0)
                        {
                            list = list.Where(o => o.Id == SessionRequest.SubeId);
                        }
                        ViewBag.contents = list.Take(3).ToList();
                        return View("haberler3");
                    }
            }
            return View();
        }
        public ActionResult Index()
        {
            ViewBag.kurum = _IKurumService.Where(o => o.Id == SessionRequest.KurumId).Result.FirstOrDefault();
            if (SessionRequest.SubeId > 0)
            {
                ViewBag.sube = _ISubeService.Where(o => o.Id == SessionRequest.SubeId).Result.FirstOrDefault();
            }

            return View();
        }

        public ActionResult _Header()
        {
            ViewBag.kurum = _IKurumService.Where(o => o.Id == SessionRequest.KurumId).Result.FirstOrDefault();
            if (SessionRequest.SubeId > 0)
            {
                ViewBag.sube = _ISubeService.Where(o => o.Id == SessionRequest.SubeId).Result.FirstOrDefault();
            }

            return View();
        }

        public ActionResult _Footer()
        {
            ViewBag.kurum = _IKurumService.Where(o => o.Id == SessionRequest.KurumId).Result.FirstOrDefault();
            if (SessionRequest.SubeId > 0)
            {
                ViewBag.sube = _ISubeService.Where(o => o.Id == SessionRequest.SubeId).Result.FirstOrDefault();
            }

            var result1 = _IContentPageService.Where(o => o.KurumId == SessionRequest.KurumId && o.IsFooterMenu == true).Result.ToList();
            ViewBag._IMenusService = result1;

            return View();
        }

        public ActionResult _Menu()
        {
            var result1 = _IContentPageService.Where(o => o.KurumId == SessionRequest.KurumId && o.IsHeaderMenu == true).Result.ToList();
            ViewBag._IMenusService = result1;
            return View();
        }

        public ActionResult Formlar()
        {
            return View();
        }
        public ActionResult iletisim()
        {
            ViewBag.kurum = _IKurumService.Where(o => o.Id == SessionRequest.KurumId).Result.FirstOrDefault();
            if (SessionRequest.SubeId > 0)
            {
                ViewBag.sube = _ISubeService.Where(o => o.Id == SessionRequest.SubeId).Result.FirstOrDefault();
            }
            return View();
        }

        //public JsonResult FormlarSave(Formlar postModel)
        //{
        //    var result = _IFormlarService.InsertOrUpdate(postModel);
        //    return Json(result);
        //}

        public ActionResult OnKayitAnaSayfa()
        {
            return View();
        }

        public ActionResult OnKayitSube()
        {
            return View();
        }

        public ActionResult OnKayitFranch()
        {
            return View();
        }

        public ActionResult Content()
        {
            var link = HttpContext.Request.Path.Value.Split('/').LastOrDefault();
            if (!string.IsNullOrEmpty(link))
            {
                var menu = _IContentPageService.Where(o => o.Link == link).Result.FirstOrDefault();
                if (menu != null)
                {
                    ViewBag.page = menu;
                    return View();
                }
                else if (_IContentPageService.Where(o => o.Link == link).Result.FirstOrDefault() != null)
                {
                    ViewBag.page = _IContentPageService.Where(o => o.Link == link).Result.FirstOrDefault();
                    return View();
                }
                else
                {
                    return Redirect(SessionRequest.baseUrl);
                }


            }
            else
            {
                return Redirect(SessionRequest.baseUrl);
            }

        }

        public ActionResult row1()
        {
            return View();
        }
        public ActionResult row2()
        {
            return View();
        }
        public ActionResult row3()
        {
            return View();
        }
        public ActionResult row4()
        {
            return View();
        }
        public ActionResult sliderUst()
        {
            return View();
        }
        public ActionResult sliderAlt()
        {
            return View();
        }

        public ActionResult etkinlikler()
        {
            return View();
        }

        public ActionResult haberler()
        {
            return View();
        }

        public ActionResult haberler3()
        {
            return View();
        }

        public ActionResult etkinlikler3()
        {
            return View();
        }




        public ActionResult Error()
        {
            return View();
        }


        public ActionResult subeler()
        {
            return View();
        }

        public ActionResult sube()
        {
            ViewBag.kurum = _IKurumService.Where(o => o.Id == SessionRequest.KurumId).Result.FirstOrDefault();
            if (SessionRequest.SubeId > 0)
            {
                ViewBag.sube = _ISubeService.Where(o => o.Id == SessionRequest.SubeId).Result.FirstOrDefault();
            }

            return View();
        }




        public JsonResult getKurum()
        {
            var result = _ISubeService.Where(o => o.KurumId == SessionRequest.KurumId).Result.FirstOrDefault();
            return Json(result);
        }

        public JsonResult getSube(int SubeId)
        {
            var result = _ISubeService.Where(o => o.Id == SubeId);
            return Json(result);
        }

        public JsonResult getSubeler(int UlkeId, int SehirId, int IlceId)
        {
            var result = _ISubeService.Where(o => o.KurumId == SessionRequest.KurumId).Result.ToList();

            //if (UlkeId > 0)
            //    result = result.Where(o => o.UlkeId == UlkeId);

            if (SehirId > 0)
                result = result.Where(o => o.SehirId == SehirId).ToList();

            if (IlceId > 0)
                result = result.Where(o => o.IlceId == IlceId).ToList();

            var result2 = result.Select(o => new
            {
                text = o.Ad,
                value = o.Id,
                SehirId = o.SehirId,
                Yetkili = "",
                Adres = o.Adres,
                Telefon = o.Telefon,
                SehirAd = "",
                IlceAd = "",
                KurumLogo = o.Logo

            }).ToList();

            return Json(result2);
        }


        //public JsonResult getUlke()
        //{
        //    var result = _IUlkeService.Where(null).Result.Select(o => new { text = o.UlkeAd, value = o.UlkeId }).ToList();
        //    return Json(result);
        //}

        public JsonResult getSehir(int id)
        {
            var result = _ICityService.Where(null).Result.Select(o => new { text = o.CityName, value = o.Id }).ToList();
            return Json(result);
        }

        public JsonResult getIlce(int id)
        {
            var result = _ITownService.Where(o => o.CityId == id).Result.Select(o => new { text = o.TownName, value = o.Id }).ToList();
            return Json(result);
        }



    }
}