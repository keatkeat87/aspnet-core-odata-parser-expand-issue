﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OData.UriParser;

namespace Project.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(
        ) {
        }

        public IActionResult Index()
        {
            
            return View();
        }
     
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
    }
}
