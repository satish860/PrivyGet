using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNet.OData.Routing.Conventions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.DependencyInjection;
using PrivyGet.Model;

namespace PrivyGet
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOData();
            services.AddMvc(options=>
            {
                options.RespectBrowserAcceptHeader = true;
                options.OutputFormatters.Add(new XmlSerializerOutputFormatter());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            var builder = new ODataConventionModelBuilder();
            var conventions= ODataRoutingConventions.CreateDefault();
            conventions.Insert(0, new MethodNameActionRoutingConvention());
            
            builder.DataServiceVersion = new Version("2.0");
            builder.MaxDataServiceVersion = builder.DataServiceVersion;
            var packageCollection = builder.EntitySet<ODataPackage>("Packages");
            packageCollection.EntityType.HasKey(p => p.Id);
            packageCollection.EntityType.HasKey(p => p.Version);
            //var configuration = builder.EntityType<ODataPackage>().Action("Search");
            //configuration.Parameter<string>("searchTerm");
            //configuration.Parameter<string>("targetFramework");
            //configuration.Parameter<bool>("includePrerelease");
            var searchAction = builder.Action("Search");
            searchAction.Parameter<string>("searchTerm");
            searchAction.Parameter<string>("targetFramework");
            searchAction.Parameter<bool>("includePrerelease");
            searchAction.ReturnsCollectionFromEntitySet(packageCollection);
            var findPackagesAction = builder.Action("FindPackagesById");
            findPackagesAction.Parameter<string>("id");
            findPackagesAction.ReturnsCollectionFromEntitySet(packageCollection);
            app.UseMvc(routerBuilder =>
            {

                routerBuilder.MapODataServiceRoute("ODataRoute", "odata",
                    builder.GetEdmModel(),
                    new DefaultODataPathHandler(),
                    conventions);
            });
        }
    }
}
