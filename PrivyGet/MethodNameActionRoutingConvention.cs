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
            ControllerActionDescriptor actionDescriptor = actionCollectionProvider.ActionDescriptors
                .Items.OfType<ControllerActionDescriptor>()
                .FirstOrDefault(p => p.ActionName == odataPath.Path.FirstSegment.Identifier);

            if (actionDescriptor != null)
                return new[] { actionDescriptor };

            // actionCollectionProvider.ActionDescriptors.Items.Where(p=>p.DisplayName==request.pa)
            return null;
        }
    }
}
