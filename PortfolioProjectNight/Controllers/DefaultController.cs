using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Web;
using System.Web.Mvc;
using PortfolioProjectNight.Models;

namespace PortfolioProjectNight.Controllers
{
    public class DefaultController : Controller
    {
        DbMyPortfolioNightEntities context = new DbMyPortfolioNightEntities();
        public ActionResult Index()
        {
            List<SelectListItem> values = (from x in context.Category.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()

                                           }).ToList();
            ViewBag.value = values;

            return View();
        }
        [HttpPost]
        public ActionResult Index(Contact contact)
        {
            contact.SendDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            contact.IsRead = false;

            context.Contact.Add(contact);
            context.SaveChanges();
            return RedirectToAction("Index");
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
        public PartialViewResult PartialHeader()
        {
            ViewBag.title = context.Profile.Select(x => x.Title).FirstOrDefault();
            ViewBag.description = context.Profile.Select(x => x.Description).FirstOrDefault();
            ViewBag.adress = context.Profile.Select(x => x.Address).FirstOrDefault();
            ViewBag.email = context.Profile.Select(x => x.Email).FirstOrDefault();
            ViewBag.phone = context.Profile.Select(x => x.Phone).FirstOrDefault();
            ViewBag.githup = context.Profile.Select(x => x.Githup).FirstOrDefault();
            ViewBag.imageUrl = context.Profile.Select(x => x.ImageUrl).FirstOrDefault();
            return PartialView();
        }
        public PartialViewResult PartialAbout()
        {
            var values = context.About.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialExperience()
        {
            var values = context.Experience.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialSkill()
        {
            var values = context.Skill.Where(x => x.Status == true).ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialFooter()
        {
            return PartialView();
        }
        public PartialViewResult PartialEducation()
        {
            var values = context.Education.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialTestimonial()
        {
            var values = context.Testimonial.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialContact()
        {
            return PartialView();
        }
        public PartialViewResult PartialPortfolio()
        {
            var values=context.Porfolio.ToList();
            return PartialView(values);
        }
    }
}