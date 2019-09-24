using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TagHelperDemo.Models;

namespace TagHelperDemo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(new Book() { Code = "001", Name = "ASP",Prefix="TJ" });
        }
    }
}
