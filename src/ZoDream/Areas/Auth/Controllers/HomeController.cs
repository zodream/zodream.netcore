using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZoDream.Util;

namespace ZoDream.Web.Areas.Auth.Controllers
{
    [Area("Auth")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login()
        {
            return Json(new JsonResponse());
        }
    }
}