using PortfolioProjectNight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioProjectNight.Controllers
{
    public class PortfolioController : Controller
    {
        // GET: Portfolio
        DbMyPortfolioNightEntities context=new DbMyPortfolioNightEntities();
        public ActionResult PortfolioList()
        {
            var values=context.Porfolio.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult CreatePortfolio()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreatePortfolio(Porfolio porfolio)
        {
            context.Porfolio.Add(porfolio);
            context.SaveChanges();
            return RedirectToAction("PortfolioList");
        }
        public ActionResult DeletePortfolio(int id)
        {
            var value = context.Porfolio.Find(id);
            context.Porfolio.Remove(value);
            context.SaveChanges();

            return RedirectToAction("PortfolioList");
        }

        [HttpGet]
        public ActionResult UpdatePortfolio(int id)
        {
            var value = context.Porfolio.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdatePortfolio(Porfolio porfolio)
        {
            var value = context.Porfolio.Find(porfolio.PortfolioId);

            
            value.Title = porfolio.Title;
            value.Description = porfolio.Description;
            value.ImageUrl = porfolio.ImageUrl;
            context.SaveChanges();

            return RedirectToAction("PortfolioList");
        }
    }
}