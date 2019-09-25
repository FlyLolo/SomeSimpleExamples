using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace FlyLolo.ConfigurationAndOption
{
    public class Program
    {
        public static readonly Dictionary<string, string> dict = new Dictionary<string, string> { { "ThemeName", "Purple" }, { "ThemeColor", "#7D26CD" } };
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((hostingContext, config) =>
            {
                config.SetBasePath(Directory.GetCurrentDirectory());

                var path = Path.Combine(Directory.GetCurrentDirectory(), "Theme.json");
                config.AddJsonFile(path, optional: false, reloadOnChange: true);

                var pathIni = Path.Combine(Directory.GetCurrentDirectory(), "Theme.ini");
                config.AddIniFile(pathIni, optional: false, reloadOnChange: true);

                var pathFile = Path.Combine(Directory.GetCurrentDirectory(), "s");
                config.AddKeyPerFile(directoryPath: pathFile, optional: true);

                config.AddInMemoryCollection(dict);
            })
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
    }
}
