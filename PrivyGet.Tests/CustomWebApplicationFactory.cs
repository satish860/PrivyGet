using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace PrivyGet.Tests
{
    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> 
        where TStartup : class
    {
        public CustomWebApplicationFactory()
        {
            
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("development");
            base.ConfigureWebHost(builder);
        }
    }
}
