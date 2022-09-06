using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_Personel_Demo.Models;

namespace Project_Personel_Demo.Controllers
{
    public class ImageController : Controller
    {
        // GET: Image
        PersonalDbEntities PersonalDbEntities = new PersonalDbEntities();
        public ActionResult Index()
        {

            var values = PersonalDbEntities.TblImage.ToList();
            return View(values);
        }
        [HttpPost]
        public ActionResult AddImage(TblImage p)
        {

            PersonalDbEntities.TblImage.Add(p);
            PersonalDbEntities.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult AddImage()
        {

            return View();

        }
        public ActionResult DeleteImage(int id)
        {
            var value = PersonalDbEntities.TblImage.Where(x => x.ImageID == id).FirstOrDefault();
            PersonalDbEntities.TblImage.Remove(value);
            PersonalDbEntities.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditImage(int id)
        {
            var value = PersonalDbEntities.TblImage.Where(x => x.ImageID == id).FirstOrDefault();

            return View(value);

        }
        public ActionResult UpdateImage(TblImage p)

        {
            var dnym = PersonalDbEntities.TblImage.Where(x => x.ImageID == p.ImageID).FirstOrDefault();
            dnym.ImageUrl = p.ImageUrl;
            dnym.ImageDescription = p.ImageDescription;
            PersonalDbEntities.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}