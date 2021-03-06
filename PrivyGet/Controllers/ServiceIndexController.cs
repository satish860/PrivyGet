﻿using Microsoft.AspNetCore.Mvc;
using PrivyGet.Model;
using System.Collections.Generic;
using System.Linq;
using PrivyGet.Extensions;

namespace PrivyGet.Controllers
{

    public class ServiceIndexController : Controller
    {
        public ActionResult<ServiceIndexModel> Get()
        {
            string searchUrl = this.Url.AbsoluteAction("Get", "search");
            return new ServiceIndexModel
            {
                version = "3.0.0",
                Resources = new List<Resources>
                {
                    new Resources
                    {
                        Id ="https://api.nuget.org/v3-flatcontainer/",
                        Type="PackageBaseAddress/3.0.0"
                    },
                    new Resources
                    {
                        Id ="https://www.nuget.org/api/v2/package",
                        Type="PackagePublish/2.0.0"
                    },
                    new Resources
                    {
                        Id =searchUrl,
                        Type="SearchQueryService/Versioned"
                    },
                    new Resources
                    {
                        Id ="https://api-v2v3search-0.nuget.org/autocomplete",
                        Type="SearchAutocompleteService/Versioned"
                    },
                    new Resources
                    {
                        Id ="https://api.nuget.org/v3/registration2/",
                        Type="RegistrationsBaseUrl/3.4.0"
                    },
                }
            };
        }
    }
}