using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiddlewarePoC
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddTransient<ConsoleLoggerMiddleware>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<ConsoleLoggerMiddleware>();



            app.Use(async (context,next) =>
            {
                await context.Response.WriteAsync("<br> Before request ");
                await next();
                await context.Response.WriteAsync("<br> After request ");
            });

            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("<br> Before request 2");
                await next();
                await context.Response.WriteAsync("<br> After request 2");
            });

            app.Run(async context =>
            {
                await context.Response.WriteAsync("<br> Terminal middleware ");
            });
            
           

            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            //app.UseRouting();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });
            //});
        }

    }
}
