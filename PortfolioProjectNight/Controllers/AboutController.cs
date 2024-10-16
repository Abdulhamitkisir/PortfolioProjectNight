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
        DbMyPortfolioNightEntities content = new DbMyPortfolioNightEntities();
        public ActionResult AboutList()
        {
            var values = content.About.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult UpdateAbout(int id)
        {
            var values = content.About.Find(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateAbout(About about)
        {
            var values = content.About.Find(about.AbutId);
            values.Title = about.Title;
            values.Description = about.Description;
            values.ImageUrl = about.ImageUrl;
            content.SaveChanges();
            return RedirectToAction("AboutList");
        }
        public ActionResult DeleteAbout(int id)
        {
            return RedirectToAction("AboutList");
        }

    }
}