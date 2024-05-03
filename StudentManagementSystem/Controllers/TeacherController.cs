using StudentManagementSystem.Models;
using StudentManagementSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentManagementSystem.Controllers
{
    public class TeacherController : Controller
    {
        TeacherBO tbo = new TeacherBO();
        StudentBO sbo = new StudentBO();
        CourseBO cbo = new CourseBO();
        EnrollmentBO ebo = new EnrollmentBO();
        PaymentBO pbo = new PaymentBO();
        GradeBO gbo = new GradeBO();
        // GET: Teacher
        public ActionResult TeacherHome()
        {
            return View();
        }
        public ActionResult GetProfile(string id)
        {
            Teacher t = tbo.Get(id);

            return View(t);
        }
        public ActionResult GetStudents()
        {
            List<Student> students = sbo.GetAll();
            return View(students);
        }
        public ActionResult GetCourses()
        {
            List<Course> courses = cbo.GetAll();
            return View(courses);
        }
        public ActionResult GetEnrollments()
        {

            List<Enrollment> enrollments = ebo.GetAll();
            return View(enrollments);

        }
        public ActionResult EnrollmentDetails(int id)
        {

            Enrollment enr = ebo.Get(id);
            return View(enr);

        }
        public ActionResult ViewPayment(int id)
        {

            Enrollment enr = ebo.Get(id);
            Course crs = cbo.Get(enr.CourseId);
            Payment pay = pbo.GetAll().Where(p=>p.StudentId==enr.StudentId && p.Amount == crs.CourseFee).FirstOrDefault();
            return View(pay);

        }
        public ActionResult AssignGrade(int id)
        {
            Grade gr = new Grade()
            {
                GradeId = 0,
                GradeName = "",
                EnrolledId = id,


            };
           
            return View(gr);

        }
        [HttpPost]
        public ActionResult AssignGrade(Grade g)
        {
            bool b = gbo.Add(g);
            if(b)
            {
                ViewBag.Message = "Grade assigned Successfully.";
                return View("SuccessTeacher");
            }
            else
            {
                ViewBag.Message = "Failed to Assign the Grade.";
                return View("ErrorTeacher");
            }
            return View();
            
        }


    }
}