using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.Framework.DependencyInjection;
using Microsoft.Framework.Configuration;
using Microsoft.Dnx.Runtime;
using ASPNET5EFDemo.Models;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNet.Cors.Core;

namespace ASPNET5EFDemo
{
    public class Startup
    {
        public static IConfigurationRoot Configuration { get; set; }
        public Startup(IApplicationEnvironment appEnv)
        {
            var build = new ConfigurationBuilder(appEnv.ApplicationBasePath)
                .AddJsonFile("config.json")
                .AddEnvironmentVariables();

            Configuration = build.Build();
        }
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {


            services.AddMvc()
                .AddJsonOptions(opt=> {
                    opt.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

                });

            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<CourseContext>();

            services.AddTransient<CourseContextSeedData>();
            services.AddScoped<ICourseRepository, CourseRepository>();

            //Add Cors support to the service
            //services.AddCors();

            //var policy = new CorsPolicy();

            //policy.Headers.Add("*");
            //policy.Methods.Add("*");
            //policy.Origins.Add("*");
            //policy.SupportsCredentials = true;

            //services.ConfigureCors(x => x.AddPolicy("mypolicy", policy));

            services.AddCors();
            services.ConfigureCors(options =>
                                    options.AddPolicy("AllowAll", p => p.AllowAnyOrigin()
                                                                        .AllowAnyMethod()
                                                                        .AllowAnyHeader()));

        }

        public void Configure(IApplicationBuilder app, CourseContextSeedData seeder)
        {
            app.UseStaticFiles();

            //Use the new policy globally
            app.UseCors("AllowAll");

            app.UseMvc(config =>
           {
               config.MapRoute(
                   name:"Default",
                   template:"{controller}/{action}/{id?}",
                   defaults: new { controller="Home", action ="Index"});
           });

            seeder.EnsureSeedData();

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});
        }
    }
}
