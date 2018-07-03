using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;

namespace PrivyGet.Tests
{
    public class ServiceIndexTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> webApplicationFactory;
        private HttpClient httpClient;

        public ServiceIndexTests(WebApplicationFactory<Startup> webApplicationFactory)
        {
            this.webApplicationFactory = webApplicationFactory;
            this.httpClient = this.webApplicationFactory.CreateDefaultClient();

        }

        [Fact]
        public async Task ShouldBeAbleToConfigureAndGetTheBasicResponseFromAPI()
        {
            string URL = "/serviceIndex";
            var response = await this.httpClient.GetAsync(URL);
            response.IsSuccessStatusCode.Should().BeTrue();
        }
    }
}
