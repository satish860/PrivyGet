using Microsoft.AspNetCore.Mvc.Testing;
using NuGet.Configuration;
using NuGet.Protocol;
using NuGet.Protocol.Core.Types;
using System;
using System.Collections.Generic;
using System.Net.Http;
using Xunit;
using System.Linq;
using System.Threading.Tasks;
using NuGet.Packaging.Core;
using NuGet.Versioning;

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

        [Fact]
        public async Task ShouldBeAbleToConsumeServiceDocumentAndGetBaseUrl()
        {
            string URL = "api/v3/index.json";
            string NugetUrl = this.httpClient.BaseAddress + URL;
            var response= await this.httpClient.GetAsync(NugetUrl);
            ISettings settings = Settings.LoadSpecificSettings(@"D:\PrivyGet\PrivyGet\PrivyGet.Tests\", "Nuget.config");
            List<Lazy<INuGetResourceProvider>> lazies = new List<Lazy<INuGetResourceProvider>>();
            lazies.AddRange(Repository.Provider.GetCoreV3());
            var sourceRepositery = new SourceRepositoryProvider(settings, lazies);
            var repo = sourceRepositery.GetRepositories().FirstOrDefault();
            var resgistrationSource = await repo.GetResourceAsync<RegistrationResourceV3>();
            var packageidentity = new PackageIdentity("json", NuGetVersion.Parse("1.0.0"));
            var packageEntry = resgistrationSource.GetUri(packageidentity);
        }
    }
}
