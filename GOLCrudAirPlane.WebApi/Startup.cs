using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GOLCrudAirplane.Application;
using GOLCrudAirplane.Domain.Interfaces;
using GOLCrudAirplane.Infra.Config;
using GOLCrudAirplane.Infra.Repositorio;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.PlatformAbstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Serialization;

namespace GOLCrudAirplane.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {

            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            builder.AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvcCore()
                .AddJsonFormatters()
                .SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_2_1)
                .AddJsonOptions(options =>
                {
                    var resolver = options.SerializerSettings.ContractResolver;
                    if (resolver != null)
                        (resolver as DefaultContractResolver).NamingStrategy = null;
                });
            
            // services.AddMvcCore().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddDbContext<ContextoBase>(options => options.UseSqlServer(Configuration.GetConnectionString("DevConnection")));

            services.AddSingleton(typeof(InterfaceGeneric<>), typeof(RepositorioGeneric<>));

            services.AddSingleton<InterfaceAirplane, RepositorioAirplane>();

            services.AddSingleton<IAppAirplane, ApplicationAirplane>();

            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(options =>
            {
                options.WithOrigins("http://localhost/4200").AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().AllowCredentials().Build();
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller=Airplane}/{action=Index}/{id?}");
            });
            

        }
    }
}
