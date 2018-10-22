using BNETestLibrary;
using BNETestLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BNETest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            using (var context = new BNETestContext())
            {
                Student student = new Student
                {
                    Name = "Lucas"
                };

                context.Students.Add(student);
                context.SaveChanges();
            }

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}