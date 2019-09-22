using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GOLCrudAirplane.Application;
using GOLCrudAirplane.Domain.Interfaces;
using GOLCrudAirplane.Infra.Repositorio;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace GOLCrudAirplane.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvcCore()
                .AddJsonFormatters()
                .SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_2_1);
            
            services.AddMvcCore().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddSingleton(typeof(InterfaceGeneric<>), typeof(RepositorioGeneric<>));

            services.AddSingleton<InterfaceAirplane, RepositorioAirplane>();

            services.AddSingleton<IAppAirplane, ApplicationAirplane>();

            services.AddCors(options =>
            {
                options.AddPolicy("EnableCORS", builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().AllowCredentials().Build();
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("EnableCORS");

            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller=Airplane}/{action=Index}/{id?}");
            });

        }
    }
}
