using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using PrivyGet.Model;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using System.Linq;

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
            string URL = "api/serviceindex";
            var response = await this.httpClient.GetAsync(URL);
            response.IsSuccessStatusCode.Should().BeTrue();
        }
        [Fact]
        public async Task ShouldBeAbleToGetTheSearchURLWithTheCurrentBaseAddress()
        {
            string URL = "api/serviceindex";
            var response = await this.httpClient.GetAsync(URL);
            response.EnsureSuccessStatusCode();
            var messageModel = await response.Content.ReadAsAsync<ServiceIndexModel>();
            var resource = messageModel.Resources
                .FirstOrDefault(p => p.Type == "SearchQueryService/3.0.0-rc");
            resource.Id.Should().Be("http://localhost/api/Search");
        }
    }
}
