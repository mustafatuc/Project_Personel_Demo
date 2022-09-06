using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_Personel_Demo.Models;


namespace Project_Personel_Demo.Controllers
{
    public class TestimonialController : Controller
    {
        // GET: Testimonial
        PersonalDbEntities PersonalDbEntities = new PersonalDbEntities();
        public ActionResult Index()
        {
            var values = PersonalDbEntities.TblTestimonial.ToList();
            return View(values);
        }
        [HttpPost]
        public ActionResult AddTestimonial(TblTestimonial p)
        {

            PersonalDbEntities.TblTestimonial.Add(p);
            PersonalDbEntities.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult AddTestimonial()
        {

            return View();

        }
        public ActionResult DeleteTestimonial(int id)
        {
            var value = PersonalDbEntities.TblTestimonial.Where(x => x.TestimonialID == id).FirstOrDefault();
            PersonalDbEntities.TblTestimonial.Remove(value);
            PersonalDbEntities.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult EditTestimonial(int id)
        {
            var dnym = PersonalDbEntities.TblTestimonial.Where(x => x.TestimonialID == id).FirstOrDefault();

            return View("EditTestimonial", dnym);

        }
        [HttpPost]
        public ActionResult UpdateTestimonial(TblTestimonial p)

        {
            var dnym = PersonalDbEntities.TblTestimonial.Where(x => x.TestimonialID == p.TestimonialID).FirstOrDefault();
            dnym.TestimonialName = p.TestimonialName;
            dnym.TestimonialImage = p.TestimonialImage;
            dnym.TestimonialTitle = p.TestimonialTitle;
            dnym.TestimonialDescription = p.TestimonialDescription;
            PersonalDbEntities.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}