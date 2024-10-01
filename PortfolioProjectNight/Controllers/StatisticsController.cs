using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PortfolioProjectNight.Models;

namespace PortfolioProjectNight.Controllers
{
    public class StatisticsController : Controller
    {
        DbMyPortfolioNightEntities context=new DbMyPortfolioNightEntities();
        public ActionResult Index()
        {
            //x=> Linq Lambda
            ViewBag.totalMessageCount=context.Contact.Count();
            ViewBag.messageIsReadTrueCount = context.Contact.Where(x=> x.IsRead==true).Count();
            ViewBag.messageIsReadFalseCount=context.Contact.Where(y=> y.IsRead==false).Count(); 
            ViewBag.skillCount=context.Contact.Count();
            ViewBag.skillRateSum = context.Skill.Sum(x=> x.Rate);
            ViewBag.skillRateAvg = context.Skill.Average(x=> x.Rate);

            var maxRate=context.Skill.Max(x=> x.Rate);
            ViewBag.maxRateSkillname = context.Skill.Where(x => x.Rate == maxRate).Select(y=> y.SkillName).FirstOrDefault();

            ViewBag.getMessageCountBySubjectReferances=context.Contact.Where(x=> x.Subject=="Referans").Count();

            ViewBag.getMessageCountByEmailContainhadnIsReadTrue=context.Contact.Where(x=> x.IsRead==true&& x.Email.Contains("h")).Count();

            ViewBag.getSkillNameByRate90=context.Skill.Where(x=> x.Rate==90).Select(y=> y.SkillName).FirstOrDefault();

            return View();
        }
    }
}