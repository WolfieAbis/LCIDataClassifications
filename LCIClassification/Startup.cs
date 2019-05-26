using System;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using LCIEntities;
using LCIBusinessLayer;
using SwashBuckle.AspNetCore;
using Swashbuckle.AspNetCore.Swagger;
using LCIData.Interface;
using LCIData;
using LCIEntities.Models;
using Microsoft.EntityFrameworkCore;

namespace LCIClassification
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
            services.AddMvc();
            var connection = @"Server = B2ML17083; Database = LCIDataClassification; Trusted_Connection = True; ";
            services.AddDbContext<LCIDataClassificationContext>(options => options.UseSqlServer(connection));
            RegisterServices(services);


            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "LCI-DataClassification API", Version = "v1" });



            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

        }

        private void RegisterServices(IServiceCollection services)
        {
            //var connection = Configuration.GetConnectionString("LocalConnection");

            //services.AddDbContext<LCIDataClassificationContext>(options => options.UseSqlServer(connection));

            services.AddScoped<ILCIBusiness, LCIBusiness>();
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            services.AddSingleton<IConfiguration>(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "LCI-Classification-V1");
                c.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
            });
            app.UseAuthentication();
            app.UseMvc();
        }





    }
}
