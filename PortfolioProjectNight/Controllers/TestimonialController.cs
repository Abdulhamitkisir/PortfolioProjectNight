using PortfolioProjectNight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioProjectNight.Controllers
{
    public class TestimonialController : Controller
    {
        // GET: Testimonial
        DbMyPortfolioNightEntities context=new DbMyPortfolioNightEntities();
        public ActionResult TestimonialList()
        {
            var values=context.Testimonial.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult UpdateTestimonial(int id)
        {
            var value = context.Testimonial.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateTestimonial(Testimonial testimonial)
        {
            var value = context.Testimonial.Find(testimonial.TestimonialId);
            value.NameSurname = testimonial.NameSurname;
            value.Adress = testimonial.Adress;
            value.Comment = testimonial.Comment;
            value.FotoUrl = testimonial.FotoUrl;
            value.Point=testimonial.Point;
            context.SaveChanges();
            return RedirectToAction("TestimonialList");
        }
        [HttpGet]
        public ActionResult CreateTestimonial()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateTestimonial(Testimonial testimonial)
        {
            context.Testimonial.Add(testimonial);
            context.SaveChanges();
            return RedirectToAction("TestimonialList");
        }
        public ActionResult DeleteTestimonial(int id)
        {
            var value = context.Testimonial.Find(id);
            context.Testimonial.Remove(value);
            context.SaveChanges();
            return RedirectToAction("TestimonialList");
        }

    }
}