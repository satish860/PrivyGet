using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PrivyGet.Tests
{
    public class ServiceIndexRewriteUrlTests :  IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> webApplicationFactory;
        private HttpClient httpClient;

        public ServiceIndexRewriteUrlTests(WebApplicationFactory<Startup> webApplicationFactory)
        {
            this.webApplicationFactory = webApplicationFactory;
            this.httpClient = this.webApplicationFactory.CreateDefaultClient();
        }

        [Fact]
        public async Task ShouldBeAbleRedirectBasedOnURL()
        {
            string URL = "v3/index.json";
            var response = await this.httpClient.GetAsync(URL);
            response.IsSuccessStatusCode.Should().BeTrue();
        }
    }
}
