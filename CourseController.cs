using ABC_University.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ABC_University.Controllers
{
    public class CourseController : Controller
    {
        ABCDbContext myDB = new ABCDbContext();

        public ActionResult GetCourses()
        {

            List<Course> courseLst = new List<Course>();

            courseLst = (from obj in myDB.courses
                         select obj).ToList();

            return View("Courses");

        }

        public ActionResult GetCourse(int id)
        {
            Course obj = new Course();

            obj = (from xyz in myDB.courses
                   where xyz.courseID == id
                   select xyz).FirstOrDefault();

            return View("Details");

        }

        public ActionResult InsertCourse()
        {
            Course obj = new Course();
            obj.courseName = "Test";
            obj.isAvailable = true;

            myDB.courses.Add(obj);

            myDB.SaveChanges();

            return View("Courses");

        }

        public ActionResult DeleteCourse( int id )
        {
            Course obj = new Course();
            obj = (from course in myDB.courses
                   where course.courseID == id
                   select course).FirstOrDefault();
            myDB.courses.Remove(obj);
            myDB.SaveChanges();

            return View("Courses");

        }

        public ActionResult UpdateCourse(int id)
        {
            Course obj = new Course();
            obj = (from course in myDB.courses
                   where course.courseID == id
                   select course).FirstOrDefault();

            obj.courseName = "Test2";
            obj.isAvailable = false;

            myDB.SaveChanges();
            return View("Courses");

        }
    }
}