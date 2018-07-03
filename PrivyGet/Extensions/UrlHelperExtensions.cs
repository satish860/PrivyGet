using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrivyGet.Extensions
{
    public static class UrlHelperExtensions
    {
        public static string AbsoluteAction(
        this IUrlHelper url,
        string actionName,
        string controllerName,
        object routeValues = null)
        {
            return url.Action(actionName, controllerName
                , routeValues
                , url.ActionContext.HttpContext.Request.Scheme);
        }
    }
}
