﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ZoDream.Web.Areas.Auth.Controllers
{
    [Area("Auth")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}