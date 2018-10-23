using BNETestLibrary.DataAccessObjects;
using BNETestLibrary.Models;
using System;
using System.Collections.Generic;
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
                using (StudentsDAO repo = new StudentsDAO())
                {
                    repo.Add(student);
                    return string.Format("The student {0} was added successfully!", student.Name);
                }
            }
            return string.Format("Unfortunately some issue occurred when trying add the new student");
        }

        public string Delete(Student student)
        {
            if (student != null)
            {
                using (StudentsDAO repo = new StudentsDAO())
                {
                    repo.Delete(student);
                    return string.Format("The student {0} was removed successfully!", student.Name);
                }
            }
            return string.Format("Unfortunately some issue occurred when trying remove the selected student");
        }

        public string Update(Student student)
        {
            if (student != null)
            {
                using (StudentsDAO repo = new StudentsDAO())
                {
                    repo.Update(student);
                    return string.Format("The student {0} was updated successfully!", student.Name);
                }
            }
            return string.Format("Unfortunately some issue occurred when trying update the selected student");
        }
    }
}