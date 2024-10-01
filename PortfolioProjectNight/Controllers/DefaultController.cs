﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PortfolioProjectNight.Models;

namespace PortfolioProjectNight.Controllers
{
    public class DefaultController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult PartialHead()
        { 
            return PartialView();
        
        }
        public PartialViewResult PartialScripts()
        {
            return PartialView();

        }
        public PartialViewResult PartialNavbar()
        {
            return PartialView();

        }
    }
}