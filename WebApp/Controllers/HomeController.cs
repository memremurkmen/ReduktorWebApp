﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {

        [AllowAnonymous]
        public ActionResult Menu()
        {
            return View();
        }

    }
}