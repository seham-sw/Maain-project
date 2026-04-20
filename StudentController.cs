using ABC_University.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ABC_University.Controllers
{
    public class StudentController : Controller
    {
        ABCDbContext myDB = new ABCDbContext();
        public ActionResult Index()
        {
            List<Student> studentLst = new List<Student>();
            studentLst = (from student in myDB.students
                          select student).ToList();
            return View(studentLst);
        }
        [HttpGet]
        public ActionResult InsertStudent()
        {
            return View();
        }

        [HttpPost]
        public ActionResult InsertStudent(Student student)
        {
            myDB.students.Add(student);
            myDB.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteStudent(int id)
        {
            Student obj = new Student();
            obj = (from data in myDB.students
                   where data.studentID == id
                   select data).FirstOrDefault();

            myDB.students.Remove(obj);
            myDB.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateStudent(int  id)
        {

            Student obj = new Student();
            obj = (from data in myDB.students
                   where data.studentID == id
                   select data).FirstOrDefault();
            return View(obj);
        }

        [HttpPost]
        public ActionResult UpdateStudent(Student updatedStudent)
        {
            Student obj = (from data in myDB.students
                           where data.studentID == updatedStudent.studentID
                           select data).FirstOrDefault();

            obj.studentName = updatedStudent.studentName;
            obj.studentNo = updatedStudent.studentNo;

            myDB.SaveChanges();

            return RedirectToAction("Index");
        }
    }
    }



    
