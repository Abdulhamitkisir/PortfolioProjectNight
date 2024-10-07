using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PortfolioProjectNight.Models;
namespace PortfolioProjectNight.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        DbMyPortfolioNightEntities content=new DbMyPortfolioNightEntities();
        public ActionResult AboutList()
        {
            var values=content.About.ToList();
            return View(values);
        }
    }
}