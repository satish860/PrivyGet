using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNet.OData.Routing.Conventions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrivyGet
{
    public class MethodNameActionRoutingConvention : IODataRoutingConvention
    {
        public IEnumerable<ControllerActionDescriptor> SelectAction(RouteContext routeContext)
        {
            IActionDescriptorCollectionProvider actionCollectionProvider =
                routeContext.HttpContext.RequestServices.GetService(typeof(IActionDescriptorCollectionProvider)) as IActionDescriptorCollectionProvider;
            ODataPath odataPath = routeContext.HttpContext.ODataFeature().Path;
            HttpRequest request = routeContext.HttpContext.Request;
            var actionName = request.Path.Value.Split('/')[2];
            if (actionName == "FindPackagesById()")

                return new[]
                {
                    new ControllerActionDescriptor
                    {
                        ActionName ="FindPackagesById",
                        ControllerName="PackagesController",
                        
                    }
                };



            // actionCollectionProvider.ActionDescriptors.Items.Where(p=>p.DisplayName==request.pa)
            return null;
        }
    }
}
