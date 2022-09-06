using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_Personel_Demo.Models;

namespace Project_Personel_Demo.Controllers
{
    public class FeatureController : Controller
    {
        // GET: Feature
        PersonalDbEntities PersonalDbEntities = new PersonalDbEntities();
        public ActionResult Index()
        {
            var values = PersonalDbEntities.TblFeature.ToList();
            return View(values);

        }
        [HttpPost]
        public ActionResult AddFeature(TblFeature p)
        {

            PersonalDbEntities.TblFeature.Add(p);
            PersonalDbEntities.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult AddFeature()
        {

            return View();

        }
        public ActionResult DeleteFeature(int id)
        {
            var value = PersonalDbEntities.TblFeature.Where(x => x.FeatureID == id).FirstOrDefault();
            PersonalDbEntities.TblFeature.Remove(value);
            PersonalDbEntities.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult EditFeature(int id)
        {
            var dnym = PersonalDbEntities.TblFeature.Where(x => x.FeatureID == id).FirstOrDefault();

            return View("EditFeature", dnym);

        }
        [HttpPost]
        public ActionResult UpdateFeature(TblFeature p)

        {
            var dnym = PersonalDbEntities.TblFeature.Where(x => x.FeatureID == p.FeatureID).FirstOrDefault();
            dnym.FeatureTitle = p.FeatureTitle;
            dnym.FeatureLogo = p.FeatureLogo;
            dnym.FeatureDescription = p.FeatureDescription;
            PersonalDbEntities.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}