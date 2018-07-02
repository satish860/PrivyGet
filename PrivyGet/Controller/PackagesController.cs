using Bogus;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNetCore.Mvc;
using PrivyGet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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

        [HttpGet]
        [HttpPost]
        public virtual IActionResult Search(
            ODataQueryOptions<ODataPackage> options,
            [FromODataUri] string searchTerm = "",
            [FromODataUri] string targetFramework = "",
            [FromODataUri] bool includePrerelease = false,
            [FromODataUri] bool includeDelisted = false,
            [FromQuery] string semVerLevel = "",
            CancellationToken token = default(CancellationToken))
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

        [HttpGet]
        [HttpPost]
        public virtual IActionResult FindPackagesById(
             ODataQueryOptions<ODataPackage> options,
             [FromODataUri] string id,
             [FromQuery] string semVerLevel = "",
             CancellationToken token = default(CancellationToken))
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
