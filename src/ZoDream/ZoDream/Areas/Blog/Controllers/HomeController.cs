﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ZoDream.Areas.Blog.Controllers
{
    [Area("Blog")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}