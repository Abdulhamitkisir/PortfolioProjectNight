using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using PortfolioProjectNight.Models;
using System.Data.Entity.Migrations;
using PagedList;
namespace PortfolioProjectNight.Controllers
{
    public class SkillController : Controller
    {
        // GET: Skill
        DbMyPortfolioNightEntities context = new DbMyPortfolioNightEntities();
        public ActionResult SkillList(int page=1)
        {
            var values = context.Skill.ToList().ToPagedList(page, 5);
            return View(values);

        }
        [HttpGet]
        public ActionResult CreateSkill()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateSkill(Skill skill)
        {
            context.Skill.Add(skill);
            context.SaveChanges();
            return RedirectToAction("SkillList");
        }
        public ActionResult DeleteSkill(int id)
        {
            var value = context.Skill.Find(id);
            context.Skill.Remove(value);
            context.SaveChanges();
            return RedirectToAction("SkillList");
        }
        [HttpGet]

        public ActionResult UpdateSkill(int id)
        {
            var value = context.Skill.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateSkill(Skill skill)
        {
            var values = context.Skill.Find(skill.SkillId);
            values.SkillName = skill.SkillName;
            values.Rate = skill.Rate;
            values.Icon = skill.Icon;
            values.Status = skill.Status;
            context.SaveChanges();
            return RedirectToAction("SkillList");
        }

        public ActionResult ChangeSkillStatusTrue(int id)
        {
            var values = context.Skill.Find(id);
            values.Status = true;
            context.SaveChanges();
            return RedirectToAction("SkillList"); 
        }
        public ActionResult ChangeSkillStatusFalse(int id)
        { 
            var values =context.Skill.Find(id);
            values.Status = false;
            context.SaveChanges();
            return RedirectToAction("SkillList");
        }
       
    }
}