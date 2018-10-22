using BNETestLibrary;
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

        /// <summary>
        /// Get All Students  
        /// </summary>  
        /// <returns>JsonResult</returns>  
        public JsonResult GetAll()
        {
            using (BNETestContext context = new BNETestContext())
            {
                List<Student> student = context.Students.ToList();
                return Json(student, JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>  
        /// Get Student by Id  
        /// </summary>  
        /// <param name="Id"></param>  
        /// <returns>JsonResult</returns>  
        public JsonResult GetById(string id)
        {
            using (BNETestContext context = new BNETestContext())
            {
                int studentId = int.Parse(id);
                return Json(context.Students.Find(studentId), JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>  
        /// Insert new Student  
        /// </summary>  
        /// <param name="student"></param>  
        /// <returns>bool</returns>  
        public bool Insert(Student student)
        {
            if (student != null)
            {
                using (BNETestContext context = new BNETestContext())
                {
                    context.Students.Add(student);
                    context.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        /// <summary>  
        /// Delete student info  
        /// </summary>  
        /// <param name="student"></param>  
        /// <returns></returns>  
        public bool Delete(Student student)
        {
            if (student != null)
            {
                using (BNETestContext context = new BNETestContext())
                {
                    if (context.Entry(student).State == Microsoft.EntityFrameworkCore.EntityState.Detached)
                    {
                        context.Students.Attach(student);
                        context.Students.Remove(student);
                    }
                    context.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        /// <summary>  
        /// Update Student Information  
        /// </summary>  
        /// <param name="updatedStudent"></param>  
        /// <returns></returns>  
        public bool Update(Student updatedStudent)
        {
            if (updatedStudent != null)
            {
                using (BNETestContext context = new BNETestContext())
                {
                    var student = context.Students.FirstOrDefault(x => x.Id == updatedStudent.Id);
                    student.Name = updatedStudent.Name;

                    context.SaveChanges();
                    return true;
                }
            }
            return false;
        }
    }
}