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
        DbMyPortfolioNightEntities context = new DbMyPortfolioNightEntities();
        public ActionResult SocialMediaList()
        {
            var values = context.SocialMedia.ToList();
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
        [HttpGet]
        public ActionResult UpdateSocialMedia(int id)
        {
            var value=context.SocialMedia.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateSocialMedia(SocialMedia socialMedia)
        {
            var value = context.SocialMedia.Find(socialMedia.SocialMediaId);
            value.Title = socialMedia.Title;
            value.Url = socialMedia.Url;
            value.Icon=socialMedia.Icon;
            value.Status = socialMedia.Status;
            context.SaveChanges();
            return RedirectToAction("SocialMediaList");
        }
        public ActionResult ChangeSocialStatusTrue(int id)
        {
            var values = context.SocialMedia.Find(id);
            values.Status = true;
            context.SaveChanges();
            return RedirectToAction("SocialMediaList");
        }
        public ActionResult ChangeSocialStatusFalse(int id)
        {
            var values = context.SocialMedia.Find(id);
            values.Status = false;
            context.SaveChanges();
            return RedirectToAction("SocialMediaList");
        }
    }
}