using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_Personel_Demo.Models;

namespace Project_Personel_Demo.Controllers
{
    public class ExperienceController : Controller
    {
        // GET: Experience
        PersonalDbEntities PersonalDbEntities = new PersonalDbEntities();
        public ActionResult Index()
        {
            var values = PersonalDbEntities.TblExperience.ToList();
            return View(values);
        }
        public ActionResult AddExperience(TblExperience p)
        {

            PersonalDbEntities.TblExperience.Add(p);
            PersonalDbEntities.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult AddExperience()
        {

            return View();

        }
        public ActionResult DeleteExperience(int id)
        {
            var value = PersonalDbEntities.TblExperience.Where(x => x.ExperienceID == id).FirstOrDefault();
            PersonalDbEntities.TblExperience.Remove(value);
            PersonalDbEntities.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult EditExperience(int id)
        {
            var dnym = PersonalDbEntities.TblExperience.Where(x => x.ExperienceID == id).FirstOrDefault();

            return View("EditExperience", dnym);

        }
        [HttpPost]
        public ActionResult UpdateExperience(TblExperience p)

        {
            var dnym = PersonalDbEntities.TblExperience.Where(x => x.ExperienceID == p.ExperienceID).FirstOrDefault();
            dnym.ExperinceTitle = p.ExperinceTitle;
            dnym.ExperienceDate = p.ExperienceDate;
            dnym.ExperienceDescription = p.ExperienceDescription;
            PersonalDbEntities.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}