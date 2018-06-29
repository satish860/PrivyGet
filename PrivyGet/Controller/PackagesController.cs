using Bogus;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using PrivyGet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrivyGet.Controller
{
    public class PackagesController : ODataController
    {
        public IActionResult Get()
        {
            ODataPackage oDataPackage = new ODataPackage
            {
                Id = "1",
                Title = "Some Package",
                Version = "1.0",
                Authors = "Satish"
            };
            IQueryable<ODataPackage> oDataPackages = new List<ODataPackage> { oDataPackage }.AsQueryable();
            return Ok(oDataPackages);

        }
    }
}
