using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_Personel_Demo.Models;

namespace Project_Personel_Demo.Controllers
{
    public class EducationController : Controller
    {
        // GET: Education
        PersonalDbEntities PersonalDbEntities = new PersonalDbEntities();
        public ActionResult Index()
        {
            var values = PersonalDbEntities.TblEducation.ToList();
            return View(values);
        }

        [HttpPost]
        public ActionResult AddEducation(TblEducation p)
        {

            PersonalDbEntities.TblEducation.Add(p);
            PersonalDbEntities.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult AddEducation()
        {

            return View();

        }
        public ActionResult DeleteEducation(int id)
        {
            var value = PersonalDbEntities.TblEducation.Where(x => x.EducationID == id).FirstOrDefault();
            PersonalDbEntities.TblEducation.Remove(value);
            PersonalDbEntities.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult EditEducation(int id)
        {
            var dnym = PersonalDbEntities.TblEducation.Where(x => x.EducationID == id).FirstOrDefault();

            return View("EditEducation", dnym);

        }
        [HttpPost]
        public ActionResult UpdateEducation(TblEducation p)

        {
            var dnym = PersonalDbEntities.TblEducation.Where(x => x.EducationID == p.EducationID).FirstOrDefault();
            dnym.EducationTitle = p.EducationTitle;
            dnym.EduationDate = p.EduationDate;
            dnym.EducationDescription = p.EducationDescription;
            PersonalDbEntities.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}