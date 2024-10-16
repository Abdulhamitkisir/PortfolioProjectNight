using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PortfolioProjectNight.Models;

namespace PortfolioProjectNight.Controllers
{
    public class IntershipController : Controller
    {
        // GET: Intership
        DbMyPortfolioNightEntities context = new DbMyPortfolioNightEntities();
        public ActionResult InterShipList()
        {
            var values = context.Intership.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateInterShip()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateInterShip(Intership intership)
        {
            context.Intership.Add(intership);
            context.SaveChanges();
            return RedirectToAction("InterShipList");
        }
        public ActionResult DeleteInterShip(int id)
        {
            var values = context.Intership.Find(id);
            context.Intership.Remove(values);
            context.SaveChanges();
            return RedirectToAction("InterShipList");
        }
        [HttpGet]
        public ActionResult UpdateInterShip(int id)
        {
            var values = context.Intership.Find(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateInterShip(Intership intership) 
        {
            var values = context.Intership.Find(intership.IntershipID);
            values.Title = intership.Title;
            values.Description = intership.Description;
            values.Date= intership.Date;
            context.SaveChanges();
            return RedirectToAction("InterShipList");
        }
    }
}