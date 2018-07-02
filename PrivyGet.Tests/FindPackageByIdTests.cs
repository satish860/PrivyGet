using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;

namespace PrivyGet.Tests
{
    public class FindPackageByIdTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        //private HttpClient
        public FindPackageByIdTests(WebApplicationFactory<Startup> webApplicationFactory)
        {
            WebApplicationFactory = webApplicationFactory;
        }

        public WebApplicationFactory<Startup> WebApplicationFactory { get; }

        [Fact]
        public async Task ShouldBeAbleToFindPackageByIDMethod()
        {
            var client = WebApplicationFactory.CreateClient();
            var response = await client.GetAsync("https://localhost/odata");
            response.IsSuccessStatusCode.Should().BeTrue();
        }
    }
}
