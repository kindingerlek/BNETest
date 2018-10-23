using BNETestLibrary.DataAccessObjects;
using BNETestLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BNETest.Controllers
{
    public class SubjectsController : Controller
    {
        // GET: Subjects
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAll()
        {
            using (var repo = new SubjectsDAO())
            {
                return Json(repo.GetAll(), JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult Get(string id)
        {
            using (var repo = new SubjectsDAO())
            {
                return Json(repo.Get(int.Parse(id)), JsonRequestBehavior.AllowGet);
            }
        }

        public string Add(Subject subject)
        {
            if (subject != null)
            {
                using (var repo = new SubjectsDAO())
                {
                    repo.Add(subject);
                    return $"The subject {subject.Name} was added successfully!";
                }
            }
            return "Unfortunately some issue occurred when trying add the new subject";
        }

        public string Delete(Subject subject)
        {
            if (subject != null)
            {
                using (var repo = new SubjectsDAO())
                {
                    repo.Delete(subject);
                    return $"The subject {subject.Name} was removed successfully!";
                }
            }
            return "Unfortunately some issue occurred when trying remove the selected subject";
        }

        public string Update(Subject subject)
        {
            if (subject != null)
            {
                using (var repo = new SubjectsDAO())
                {
                    repo.Update(subject);
                    return $"The subject {subject.Name} was updated successfully!";
                }
            }
            return "Unfortunately some issue occurred when trying update the selected subject";
        }
    }
}