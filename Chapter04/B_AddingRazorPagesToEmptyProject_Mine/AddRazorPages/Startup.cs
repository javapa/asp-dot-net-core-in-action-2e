using AddRazorPages.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text;

namespace AddRazorPages
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages().AddRazorPagesOptions(options =>
            {
                //options.Conventions.Add(new PageRouteTransformerConvention(new KebabCaseTransformer()));
                //options.Conventions.AddPageRoute("/Contact", "/search-products");
            });


            services.AddTransient<IQuoteService, QuoteService>();
            services.AddHealthChecks();

            services.Configure<RouteOptions>(options =>
            {
                options.AppendTrailingSlash = true;
                options.LowercaseUrls = true;
                options.LowercaseQueryStrings = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            //app.UseStatusCodePages(options => options.));
            app.UseStatusCodePagesWithReExecute("/StatusCodes/{0}");

            // Endpoint routing middleware
            app.UseRouting();

            // Endpoint middleware
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapGet("/test", async context => 
                {
                    await context.Response.WriteAsync("Hello World!");
                });
                endpoints.MapHealthChecks("/health");
            });
        }
    }
}
