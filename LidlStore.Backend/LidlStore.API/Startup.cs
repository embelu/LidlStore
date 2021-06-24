using LidlStore.API.HealthCheck;
using LidlStore.BL.Implementations;
using LidlStore.BL.Interfaces;
using LidlStore.Data.Entities;
using LidlStore.Data.Interfaces;
using LidlStore.Data.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LidlStore.API
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
            services.AddControllers();
            #region Injection
            var connectionDB = Configuration.GetConnectionString("FormationDB");
            services.AddDbContext<DB_FormationContext>(options => options.UseSqlServer(connectionDB));

            services.AddTransient<ICategorieBL, CategorieBL>();
            services.AddTransient<ICategorieRepository, CategorieRepository>();

            services.AddTransient<IProduitBL, ProduitBL>();
            services.AddTransient<IProduitRepository, ProduitRepository>();

            services.AddTransient<ICommandeBL, CommandeBL>();
            services.AddTransient<ICommandeRepository, CommandeRepository>();

            services.AddTransient<IDetailCommandeRepository, DetailCommandeRepository>();
            #endregion

            #region HealthCheck
            services.AddHealthChecks();
            services.AddHealthChecks().AddDbContextCheck<DB_FormationContext>()
                                      .AddUrlGroup(new Uri("https://google.be"), name: "Google")
                                      .AddCheck<CustomHealthCheck>(name: "New Custom Check");
            #endregion


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                { Title = "LidlStore", Description = "DotNet Core Api 3 - with swagger" });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Music V1");
            });

            app.UseHealthChecks("/health", new HealthCheckOptions
            {
                ResponseWriter = async (context, report) =>
                {
                    context.Response.ContentType = "application/json"; // Le type de réponse doit être du Json
                    var response = new HealthCheckReponse
                    {
                        Status = report.Status.ToString(),
                        HealthChecks = report.Entries.Select(x => new IndividualHealthCheckResponse
                        {
                            Component = x.Key,
                            Status = x.Value.Status.ToString(),
                            Description = x.Value.Description
                        }),
                        HealthCheckDuration = report.TotalDuration
                    };
                    await context.Response.WriteAsync(JsonConvert.SerializeObject(response));
                }
            });
        }
    }
}
