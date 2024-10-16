using PortfolioProjectNight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioProjectNight.Controllers
{
    public class SocialMediaController : Controller
    {
        // GET: SocialMedia
        DbMyPortfolioNightEntities context=new DbMyPortfolioNightEntities();
        public ActionResult SocialMediaList()
        {
            var values =context.SocialMedia.ToList();
            return View(values);
        }
        public ActionResult CreateSocialMedia() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateSocialMedia(SocialMedia socialMedia)
        {
            context.SocialMedia.Add(socialMedia);
            context.SaveChanges();
            return RedirectToAction("SocialMediaList");
        }
    }
}