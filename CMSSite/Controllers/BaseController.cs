using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CMSSite.Models;
using Entity.CMSDB; using Entity.ContextModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Controllers
{

    public class BaseController : Controller
    {
        IHttpContextAccessor _httpContextAccessor;
        IHostingEnvironment _IHostingEnvironment;


        IContentPageService _IContentPageService;
        IKurumService _IKurumService;
        ISubeService _ISubeService;
        ICityService _ICityService;
        ITownService _ITownService;
        IFormlarService _IFormlarService;


        public BaseController(
            IContentPageService _IContentPageService,
             IKurumService _IKurumService,
        ISubeService _ISubeService,
        ICityService _ICityService,
        ITownService _ITownService,
        IFormlarService _IFormlarService,
        IHttpContextAccessor httpContextAccessor,
        IHostingEnvironment _IHostingEnvironment

            )
        {
            this._IContentPageService = _IContentPageService;
            this._IKurumService = _IKurumService;
            this._ISubeService = _ISubeService;
            this._ICityService = _ICityService;
            this._ITownService = _ITownService;
            this._IFormlarService = _IFormlarService;

            this._httpContextAccessor = httpContextAccessor;
            this._IHostingEnvironment = _IHostingEnvironment;

            var paths = _httpContextAccessor.HttpContext.Request.Path.ToUriComponent().Split('/').Where(o => !string.IsNullOrEmpty(o)).ToList();


            var kurum = _IKurumService.Where(o => o.Id == SessionRequest.KurumId).Result.FirstOrDefault();
            _httpContextAccessor.HttpContext.Session.Set("kurum", kurum);

            var header = _IContentPageService.Where(o => o.KurumId == SessionRequest.KurumId && o.IsHeaderMenu == true).Result;
            var footer = _IContentPageService.Where(o => o.KurumId == SessionRequest.KurumId && o.IsFooterMenu == true).Result;


            if (paths.Count() > 2 && paths.Any(o => (o.Contains("sube") || o.Contains("iletisim"))))
            {
                SessionRequest.SubeId = paths.LastOrDefault().ToInt();
                var sube = _ISubeService.Where(o => o.Id == SessionRequest.SubeId).Result.FirstOrDefault();
                _httpContextAccessor.HttpContext.Session.Set("sube", sube);

                //header = header.Where(o => o.SubeId == SessionRequest.SubeId);
                //footer = footer.Where(o => o.SubeId == SessionRequest.SubeId);
            }
            else
            {
                SessionRequest.SubeId = 0;
            }


            _httpContextAccessor.HttpContext.Session.Set("header", header.ToList());
            _httpContextAccessor.HttpContext.Session.Set("footer", footer.ToList());
        }

        public IActionResult Index()
        {


            return View();
        }

        public IActionResult Content()
        {
            var link = HttpContext.Items["cmspage"].ToString();
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



        public IActionResult _Header()
        {
            return View();
        }

        public IActionResult _Footer()
        {
            return View();
        }

        public IActionResult _Menu()
        {
            return View();
        }

        public IActionResult Formlar()
        {
            return View();
        }
        public IActionResult iletisim()
        {
            return View();
        }

        public JsonResult FormlarSave(Formlar postModel)
        {
            var result = _IFormlarService.InsertOrUpdate(postModel);
            return Json(result);
        }

        public IActionResult OnKayitAnaSayfa()
        {
            return View();
        }

        public IActionResult OnKayitSube()
        {
            return View();
        }

        public IActionResult OnKayitFranch()
        {
            return View();
        }


        public IActionResult row1()
        {
            return View();
        }
        public IActionResult row2()
        {
            return View();
        }
        public IActionResult row3()
        {
            return View();
        }
        public IActionResult row4()
        {
            return View();
        }
        public IActionResult sliderUst()
        {
            return View();
        }
        public IActionResult sliderAlt()
        {
            return View();
        }

        public IActionResult etkinlikler()
        {
            return View();
        }

        public IActionResult haberler()
        {
            return View();
        }

        public IActionResult haberler3()
        {
            return View();
        }

        public IActionResult etkinlikler3()
        {
            return View();
        }


        public IActionResult Error()
        {
            return View();
        }


        public IActionResult subeler()
        {
            return View();
        }

        public IActionResult sube()
        {
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