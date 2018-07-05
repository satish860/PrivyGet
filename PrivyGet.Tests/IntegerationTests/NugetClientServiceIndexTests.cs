using Microsoft.AspNetCore.Mvc.Testing;
using NuGet.Configuration;
using NuGet.Packaging.PackageCreation.Resources;
using NuGet.Repositories;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PrivyGet.Tests.IntegerationTests
{
    public class NugetClientServiceIndexTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> webApplicationFactory;
        private HttpClient httpClient;
        public NugetClientServiceIndexTests(WebApplicationFactory<Startup> webApplicationFactory)
        {
            this.webApplicationFactory = webApplicationFactory;
            this.httpClient = webApplicationFactory.CreateDefaultClient();
        }

        public async Task ShouldBeAbleToConsumeServiceDocumentAndGetBaseUrl()
        {
            string URL = "v3/index.json";
            string NugetUrl = this.httpClient.BaseAddress + URL;
           // Settings.
        }
    }
}
