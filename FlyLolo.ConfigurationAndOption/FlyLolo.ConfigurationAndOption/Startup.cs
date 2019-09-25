using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlyLolo.ConfigurationAndOption.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FlyLolo.ConfigurationAndOption
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
            //services.ConfigureAll<Theme>(theme=>theme.Name = "333333");
            services.Configure<Theme>(Configuration.GetSection("Theme"));
            services.Configure<Theme>("ThemeBlue", Configuration.GetSection("Themes:0"));
            services.Configure<Theme>("ThemeRed", Configuration.GetSection("Themes:1"));
            services.Configure<Theme>("ThemeBlack", theme => {
                theme.Color = "#000000";
                theme.Name = "Black";
            });
            services.Configure<Theme>("ThemeBlack", theme => {
                theme.Color = "#000000";
                theme.Name = "Black1";
            });
            //services.ConfigureAll<Theme>(theme =>
            //{
            //    theme.Color = "#000000";
            //    theme.Name = "Black2";
            //});
            services.AddControllersWithViews();
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
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
