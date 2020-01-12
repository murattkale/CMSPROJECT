using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSSite.Models
{

    public class DynamicRouting : IRouteConstraint
    {

        public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            if (values["site"].ToInt() > 0)
            {
                SessionRequest.KurumId = values["site"].ToInt();
                SessionRequest.baseUrl = "/" + SessionRequest.KurumId + "/";
                SessionRequest.RawUrl = SessionRequest.baseUrl;

                var paths = httpContext.Request.Path.ToUriComponent().Split('/').Where(o => !string.IsNullOrEmpty(o)).ToList();

                if (paths.Any(o => (o.Contains("sube") || o.Contains("iletisim"))))
                {
                    SessionRequest.SubeId = paths.LastOrDefault().ToInt();
                }

                if (values["link"] != null && values["link"] != "")
                {
                    var url = Uri.EscapeDataString(values["link"].ToString());
                    httpContext.Items["cmspage"] = Uri.EscapeDataString(url);
                    return true;
                }
            }

            return false;
        }
    }

}


