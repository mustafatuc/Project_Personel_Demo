using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_Personel_Demo.Models;

namespace Project_Personel_Demo.Controllers
{
    public class SkillController : Controller
    {
        // GET: Skill
        PersonalDbEntities PersonalDbEntities = new PersonalDbEntities();
        public ActionResult Index()
        {

            var values = PersonalDbEntities.TblSkill.ToList();
            return View(values);
        }
        [HttpPost]
        public ActionResult AddSkill(TblSkill p) 
        {

            PersonalDbEntities.TblSkill.Add(p);
            PersonalDbEntities.SaveChanges();
            return RedirectToAction("Index");
        
        }
        [HttpGet]
        public ActionResult AddSkill()
        {

            return View();

        }

        public ActionResult DeleteSkill(int id)
        {
          var value = PersonalDbEntities.TblSkill.Where(x => x.SkillID == id).FirstOrDefault();
            PersonalDbEntities.TblSkill.Remove(value);
            PersonalDbEntities.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditSkill(int id)
        {
            var value = PersonalDbEntities.TblSkill.Where(x => x.SkillID == id).FirstOrDefault();

            return View(value);

        }
        [HttpPost]
        public ActionResult EditSkill(TblSkill p)

        {
            var dnym = PersonalDbEntities.TblSkill.Where(x => x.SkillID == p.SkillID).FirstOrDefault();
            dnym.SkillTitle = p.SkillTitle;
            dnym.SkillValue = p.SkillValue;
            PersonalDbEntities.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}