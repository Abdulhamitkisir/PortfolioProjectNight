using Microsoft.Ajax.Utilities;
using PortfolioProjectNight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioProjectNight.Controllers
{
    public class EducationController : Controller
    {
        // GET: Education
        DbMyPortfolioNightEntities context = new DbMyPortfolioNightEntities();
        public ActionResult EducationList()
        {
            var values= context.Education.ToList();
            return View(values);
        }
        public ActionResult CreateEducation() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateEducation(Education education)
        {
            context.Education.Add(education);
            context.SaveChanges();
            return RedirectToAction("EducationList");
        }      
        public ActionResult DeleteEducation(int id) 
        {
            var values= context.Education.Find(id);
            context.Education.Remove(values);
            context.SaveChanges();
            return RedirectToAction ("EducationList"); 
        }
        [HttpGet]

        public ActionResult UpdateEducation(int id)
        {
            var values = context.Education.Find(id);              
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateEducation(Education education)
        {
            var values = context.Education.Find(education.EducationID);
            values.Title = education.Title;
            values.Description = education.Description;
            values.SubTitle = education.SubTitle;           
            context.SaveChanges();
            return RedirectToAction("EducationList");
        }


    }
}