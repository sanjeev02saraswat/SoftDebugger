﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PackageModule.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
     

        public ActionResult Login()
        {
            return View();
        }


        public ActionResult LogOut()
        {
            Session.RemoveAll();
            return View();
        }
    }
}