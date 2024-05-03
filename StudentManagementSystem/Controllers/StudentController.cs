using StudentManagementSystem.Models;
using StudentManagementSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentManagementSystem.Controllers
{
    public class StudentController : Controller
    {
        TeacherBO tbo = new TeacherBO();
        StudentBO sbo = new StudentBO();
        CourseBO cbo = new CourseBO();
        CourseTeacherBO ctbo = new CourseTeacherBO();
        EnrollmentBO ebo = new EnrollmentBO();
        PaymentBO pbo = new PaymentBO();
        // GET: Student
        public ActionResult StudentHome()
        {
            return View();
        }
        public ActionResult GetTeachers()
        {
            List<CourseTeacher> ctlist = ctbo.GetAll();
            return View(ctlist);
        }
        public ActionResult GetProfile(string id)
        {
            Student s = sbo.Get(id);
            return View(s);
        }
        public ActionResult ViewCourse() 
        {
            List<Course> courses = cbo.GetAll();
            return View(courses);

        }
        public ActionResult EnrollForNewCourse(int id) 
        {
            string studentId = (string)Session["LoginId"];
            Enrollment enr = new Enrollment()
            {
                EnrollmentId = 0,
                EnrollmentDate = DateTime.Today,
                StudentId = studentId,
                CourseId = id
            };
            bool b = ebo.Add(enr);
            if(b)
            {
                ViewBag.Message = "Student has Enrolled for the respective course successfully.";
                return View("SuccessStudent");
            }
            else
            {
                ViewBag.Message = "Sorry, Student couldn't be able to enroll for the particular course.";
                return View("ErrorStudent");
            }
            return View();
        }
        public ActionResult ViewEnrollments()
        {
            string studentId = (string)Session["LoginId"];
            List<Enrollment> enrollments = ebo.GetAll().Where(er=>er.StudentId==studentId).ToList();
            return View(enrollments);

        }
        public ActionResult ViewPayments()
        {
            string studentId = (string)Session["LoginId"];
            List<Payment> payments = pbo.GetAll().Where(p => p.StudentId == studentId).ToList();
            return View(payments);

        }
        public ActionResult PayNow(int id)
        {
            Enrollment enr = ebo.Get(id);
            Course cr = cbo.Get(enr.CourseId);
            Payment pay = new Payment()
            {
                PaymentId = 0,
                StudentId = enr.StudentId,
                Amount = cr.CourseFee,
                PaymentDate = DateTime.Today,
                PaymentStatus = "Paid"
            };
            bool b = pbo.Add(pay);
            if(b)
            {
                ViewBag.Message = "Payment for the Particular course has been received successfully.";
                return View("SuccessStudent");
            }
            else
            {
                ViewBag.Message = "Error Occured During Payment.";
                return View("ErrorStudent");

            }
            return View();
        }
    }
}