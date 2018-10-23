using BNETestLibrary.DataAccessObjects;
using BNETestLibrary.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BNETest.Controllers
{
    public class StudentsController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAll()
        {
            using (var repo = new StudentsDAO())
            {
                return Json(repo.GetAll(), JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult Get(string id)
        {
            using (var repo = new StudentsDAO())
            {
                return Json(repo.Get(int.Parse(id)), JsonRequestBehavior.AllowGet);
            }
        }

        public string Add(Student student)
        {
            if (student != null)
            {
                using (var repo = new StudentsDAO())
                {
                    repo.Add(student);
                    return $"The student {student.Name} was added successfully!";
                }
            }
            return "Unfortunately some issue occurred when trying add the new student";
        }

        public string Delete(Student student)
        {
            if (student != null)
            {
                using (var repo = new StudentsDAO())
                {
                    repo.Delete(student);
                    return $"The student {student.Name} was removed successfully!";
                }
            }
            return "Unfortunately some issue occurred when trying remove the selected student";
        }

        public string Update(Student student)
        {
            if (student != null)
            {
                using (var repo = new StudentsDAO())
                {
                    repo.Update(student);
                    return $"The student {student.Name} was updated successfully!";
                }
            }
            return "Unfortunately some issue occurred when trying update the selected student";
        }
    }
}