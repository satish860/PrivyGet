using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PrivyGet.Tests
{
    public class SearchTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> webApplicationFactory;

        public SearchTests(WebApplicationFactory<Startup> webApplicationFactory)
        {
            this.webApplicationFactory = webApplicationFactory;
        }

        [Fact]
        public async Task ShouldBeAbleHitSearchMethod()
        {
            string URL = "https://localhost:5001/odata/Search()?$filter=IsAbsoluteLatestVersion&searchTerm=''&targetFramework='net46'&includePrerelease=true&$skip=0&$top=26&semVerLevel=2.0";
            var client = webApplicationFactory.CreateClient();
            var response = await client.GetAsync(URL);

        }
    }
}
