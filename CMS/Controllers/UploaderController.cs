
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Entity.CMSDB; using Entity.ContextModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

namespace CMS
{
    public class UploaderController : Controller
    {
        IHostingEnvironment hostingEnvironment;
        //I hostingEnvironment;

        public UploaderController(IHostingEnvironment hostingEnvironment)
        {
            this.hostingEnvironment = hostingEnvironment;
        }

        [HttpPost]
        public JsonResult Index(IList<IFormFile> files, Documents postmodel)
        {

            var list = new List<string>();
            foreach (IFormFile source in files)
            {
                string filename = ContentDispositionHeaderValue.Parse(source.ContentDisposition).FileName.ToString().Trim('"');
                //filename = this.EnsureCorrectFilename(filename);
                filename = SessionRequest.version + "_" + Guid.NewGuid().ToString() + "." + filename.Split('.').LastOrDefault();
                list.Add(filename);
                var path = this.GetPathAndFilename(filename);
                using (FileStream output = System.IO.File.Create(path))
                    source.CopyTo(output);
            }

            return Json(list);
        }

        private string EnsureCorrectFilename(string filename)
        {
            if (filename.Contains("\\"))
                filename = filename.Substring(filename.LastIndexOf("\\") + 1);

            return filename;
        }

        private string GetPathAndFilename(string filename)
        {
            string path = this.hostingEnvironment.WebRootPath + "\\uploads\\";

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            return path + filename;
        }
    }
}