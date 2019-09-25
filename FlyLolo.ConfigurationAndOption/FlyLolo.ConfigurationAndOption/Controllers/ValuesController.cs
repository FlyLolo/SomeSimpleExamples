using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlyLolo.ConfigurationAndOption.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FlyLolo.ConfigurationAndOption.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        //private IOptions<Theme> _options = null;
        //public ValuesController(IOptions<Theme> options)
        //{
        //    _options = options;
        //}

        //public ContentResult GetOptions()
        //{
        //    return new ContentResult() { Content = $"options:{ _options.Value.Name}" };
        //}
        private IOptions<Theme> _options = null;
        private IOptionsMonitor<Theme> _optionsMonitor = null;
        private IOptionsSnapshot<Theme> _optionsSnapshot = null;
        public ValuesController(IOptions<Theme> options, IOptionsMonitor<Theme> optionsMonitor, IOptionsSnapshot<Theme> optionsSnapshot)
        {
            _options = options;
            _optionsMonitor = optionsMonitor;
            _optionsSnapshot = optionsSnapshot;
        }

        //public ContentResult GetOptions()
        //{
        //    return new ContentResult() { Content = $"_options:{_options.Value.Name}," +
        //        $"optionsSnapshot:{ _optionsSnapshot.Get("ThemeBlue").Name }," +
        //        $"optionsMonitor:{_optionsMonitor.Get("ThemeRed").Name}" };
        //}

        public ContentResult GetOptions()
        {
            _optionsMonitor.OnChange((theme,name)=> { Console.WriteLine(theme.Name +"---"+ name); });

            return new ContentResult()
            {
                Content = $"options:{_options.Value.Name}|{_options.Value.Guid}," +
                $"\r\n optionsSnapshot:{ _optionsSnapshot.Get("ThemeBlue").Name }|{_optionsSnapshot.Get("ThemeBlue").Guid}," +
                $"\r\n optionsMonitor:{_optionsMonitor.Get("ThemeRed").Name}|{_optionsMonitor.Get("ThemeRed").Guid}" +
                $"\r\n optionsMonitorNull:{_optionsMonitor.Get("ddd").Name}|{_optionsMonitor.Get("ddd").Guid}" +
                $"\r\n optionsMonitordouble:{_optionsMonitor.Get("ThemeBlack").Name}|{_optionsMonitor.Get("ThemeBlack").Guid}"
            };
        }

    }
}
