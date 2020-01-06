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
            SessionRequest.KurumId = httpContext.Request.Path.ToUriComponent().Split('/').Where(o => !string.IsNullOrEmpty(o)).FirstOrDefault().ToInt();
            SessionRequest.baseUrl = "/" + SessionRequest.KurumId + "/";
            SessionRequest.RawUrl = SessionRequest.baseUrl;
            SessionRequest.SubeId = httpContext.Request.Path.ToUriComponent().Split('/')
                .Where(o => !string.IsNullOrEmpty(o) && (o.Contains("/sube/") || o.Contains("/iletisim/"))).LastOrDefault().ToInt();


            if (values["link"] != null && values["link"] != "")
            {
                var url = Uri.EscapeDataString(values["link"].ToString());
                httpContext.Items["cmspage"] = Uri.EscapeDataString(url);
                return true;
            }
            return false;
        }
    }

}


