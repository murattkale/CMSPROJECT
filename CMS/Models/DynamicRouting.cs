using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Models
{

    public class DynamicRouting : IRouteConstraint
    {
        public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            if (httpContext.Request.Path.ToUriComponent().Split('/').Where(o => !string.IsNullOrEmpty(o)).FirstOrDefault().ToInt()>0)
            {
                SessionRequest.KurumId = httpContext.Request.Path.ToUriComponent().Split('/').Where(o => !string.IsNullOrEmpty(o)).FirstOrDefault().ToInt();
                SessionRequest.baseUrl = "/" + SessionRequest.KurumId + "/";
                SessionRequest.RawUrl = SessionRequest.baseUrl;
            }
         
            return false;
        }
    }

}


