﻿using Microsoft.AspNetCore.Mvc;

namespace Presentation.WebUI.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
