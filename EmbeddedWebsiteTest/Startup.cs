
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


using Microsoft.AspNetCore.Http;

namespace EmbeddedWebsiteTest
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
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            // services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IHttpContextAccessor ctx)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                // app.UseBrowserLink();
            }
            else
            {
                // https://docs.microsoft.com/en-us/aspnet/core/fundamentals/error-handling
                app.UseExceptionHandler("/Error");
            }



            // http://www.talkingdotnet.com/handle-404-error-asp-net-core-mvc-6/
            // https://github.com/aspnet/Diagnostics/blob/dev/src/Microsoft.AspNetCore.Diagnostics/StatusCodePage/StatusCodePagesMiddleware.cs
            // https://github.com/aspnet/Diagnostics/blob/b1643b438aa947370868b4d5ee7727c27f2d78cb/src/Microsoft.AspNet.Diagnostics/StatusCodePagesExtensions.cs

            app.UseStatusCodePages();
            /*
            app.Use(async (context, next) =>
            {
                await next();
                if (context.Response.StatusCode >= 400)
                {
                    await ctx.HttpContext.Response.WriteAsync("Error: " + context.Response.StatusCode.ToString());
                    // context.Request.Path = "/Home";
                    // await next();
                }
            });
            */



            //DefaultFilesOptions options = new DefaultFilesOptions();
            //options.DefaultFileNames.Clear();
            //options.DefaultFileNames.Add("index.html");
            //app.UseDefaultFiles(options);

            // https://docs.microsoft.com/en-us/aspnet/core/fundamentals/static-files
            app.UseStaticFiles();
            app.UseFileServer(enableDirectoryBrowsing: false);


            /*
            app.UseStaticFiles(
                new StaticFileOptions()
            {
                FileProvider = env.WebRootFileProvider,
                RequestPath = env.WebRootPath,
                    OnPrepareResponse = ctx =>
                    {
                        // ctx.Context.Response.Headers.Append("Cache-Control", "public,max-age=600");
                    }
                });
            */


            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //        name: "default",
            //        template: "{controller}/{action=Index}/{id?}");
            //});
        }


    }


}
