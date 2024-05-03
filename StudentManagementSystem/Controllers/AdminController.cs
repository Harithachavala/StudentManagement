using StudentManagementSystem.Models;
using StudentManagementSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentManagementSystem.Controllers
{
    public class AdminController : Controller
    {
        TeacherBO tbo = new TeacherBO();
        LoginBO lbo = new LoginBO();
        StudentBO sbo = new StudentBO();
        PaymentBO pbo = new PaymentBO();
        CourseBO cbo = new CourseBO();
        CourseTeacherBO ctbo = new CourseTeacherBO();
        EnrollmentBO ebo = new EnrollmentBO();
        // GET: Admin
        public ActionResult AdminHome()
        {
            return View();
        }
        public ActionResult AssignCourse(string id)
        {
            Teacher t = tbo.Get(id);
            Course c = cbo.GetAll().Where(crs => crs.CourseName.ToLower().Contains(t.AssignedCourse.ToLower())).FirstOrDefault();
            if(c==null)
            {
                ViewBag.Message = "The desired course is not available for the available teacher!";
                return View("ErrorAdmin");
            }
            
            CourseTeacher ct = new CourseTeacher()
            {
                CourseTeacherId = 0,
                CourseId = c.CourseId,
                TeacherId = t.TeacherId

            };
            bool b = ctbo.Add(ct);
            if(b)
            {
                ViewBag.Message = "The particular teacher is assigned with respective course.";
                return View("SuccessAdmin");
            }
            else
            {
                ViewBag.Message = "Teacher couldn't be assigned with the respective course.";
                return View("ErrorAdmin");
            }
            return View();
        }
        public ActionResult GetTeachers()
        {
            List<Teacher> teachers = tbo.GetAll();
            return View(teachers);
        }
        public ActionResult AddTeacher()
        {
            Teacher t = new Teacher();
            t.TeacherId = "Teach" + (new Random()).Next(1000, 99999);
            return View(t);

        }
        [HttpPost]
        public ActionResult AddTeacher(Teacher t)
        {
            try
            {
                bool b = tbo.Add(t);
                if (b)
                {

                    Login login = new Login()
                    {
                        LoginId = t.TeacherId,
                        Password = t.Password,
                        Role = "Teacher"
                    };
                    b = lbo.Add(login);

                    if (b)
                    {
                        ViewBag.Message = "Teacher Registration Success";
                        return View("SuccessAdmin");
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Teacher Registration Failed";
                return View("ErrorAdmin");
            }

            return View();

        }
        public ActionResult EditTeacher(string id)
        {
            Teacher t = tbo.Get(id);
            return View(t);
        }
        [HttpPost]
        public ActionResult EditTeacher(Teacher t)
        {
            try
            {
                bool b = tbo.Update(t);
                if (b)
                {

                    Login login = new Login()
                    {
                        LoginId = t.TeacherId,
                        Password = t.Password,
                        Role = "Teacher"
                    };
                    b = lbo.Update(login);

                    if (b)
                    {
                        ViewBag.Message = "Teacher Updation Details Modified Successfully";
                        return View("SuccessAdmin");
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Teacher Details Updation Failed";
                return View("ErrorAdmin");
            }

            return View();
        }
        public ActionResult TeacherDetail(string id)
        {
            Teacher t = tbo.Get(id);
            return View(t);
        }
        public ActionResult DeleteTeacher(string id)
        {
            Teacher t = tbo.Get(id);
            Login l = lbo.Get(t.TeacherId);
            bool b1 = lbo.Delete(l);
            bool b = tbo.Delete(t);
            if (b && b1)
            {
                return RedirectToAction("GetTeachers", "Admin");
            }
            else
            {
                ViewBag.Message = "Teacher Record Could not be Deleted.";
                return View("ErrorAdmin");
            }
            return View();
        }
        public ActionResult GetStudents()
        {
            List<Student> students = sbo.GetAll();
            return View(students);
        }
        public ActionResult StudentDetail(string id)
        {
            Student s = sbo.Get(id);
            return View(s);
        }
        public ActionResult DeleteStudent(string id)
        {
            Student s = sbo.Get(id);
            Login l = lbo.Get(s.StudentId);
            bool b1 = lbo.Delete(l);
            bool b = sbo.Delete(s);
            if (b && b1)
            {
                return RedirectToAction("GetStudents", "Admin");
            }
            else
            {
                ViewBag.Message = "Student Record Could not be Deleted.";
                return View("ErrorAdmin");
            }
            return View();
        }
        public ActionResult ViewPayments()
        {
            List<Payment> payments = pbo.GetAll();
            return View(payments);

        }
        public ActionResult AddPayment()
        {
            Payment p = new Payment();
            p.PaymentDate = DateTime.Today;
            p.PaymentStatus = "Due";
            p.PaymentId = 0;
            return View(p);

        }
        [HttpPost]
        public ActionResult AddPayment(Payment p)
        {
            try
            {
                p.PaymentStatus = "Paid";
                bool b = pbo.Add(p);
                if (b)
                {
                    ViewBag.Message = "Payment Details Added Successfully.";
                    return View("SuccessAdmin");
                }
                else
                {
                    ViewBag.Message = "Failed to Add Payment Details!";
                    return View("ErrorAdmin");
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Error: " + ex.Message;
                return View("ErrorAdmin");
            }
            return View();
        }
        public ActionResult EditPayment(int id)
        {
            Payment p = pbo.Get(id);
            return View(p);
        }

        [HttpPost]
        public ActionResult EditPayment(Payment p)
        {
            try
            {
                bool b = pbo.Update(p);
                if (b)
                {
                    ViewBag.Message = "Payment Details Updated Successfully";
                    return RedirectToAction("ViewPayments");
                }
                else
                {
                    ViewBag.Message = "Payment Details Updation Failed";
                    return View(p);
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = "An error occurred while updating the payment details: " + ex.Message;
                return View("ErrorAdmin");
            }
            return View();

        }
        public ActionResult PaymentDetail(int id)
        {
            Payment p = pbo.Get(id);
            return View(p);
        }
        public ActionResult DeletePayment(int id)
        {
            Payment p = pbo.Get(id);
            bool b = pbo.Delete(p);
            if (b)
            {
                ViewBag.Message = "Payment Details Deleted Successfully";
                return View("SuccessAdmin");
            }
            return View();
        }
        public ActionResult GetCourses()
        {
            List<Course> courses = cbo.GetAll();
            return View(courses);
        }
        public ActionResult AddCourses()
        {
            Course c = new Course()
            {
                CourseId = (new Random()).Next(1000, 99999),
                CourseName = "Course" + (new Random()).Next(1000, 99999)
            };
            return View(c);
        }
        [HttpPost]
        public ActionResult AddCourses(Course c)
        {
            bool b = cbo.Add(c);
            if (b)
            {
                ViewBag.Message = "Course Details Added.";
                return View("SuccessAdmin");
            }
            else
            {
                ViewBag.Message = "Error Occurred while adding Course Details.";
                return View("ErrorAdmin");
            }
        }
        public ActionResult EditCourse(int id)
        {
            Course c = cbo.Get(id);
            return View(c);
        }
        [HttpPost]
        public ActionResult EditCourse(Course c)
        {
            try
            {
                bool b = cbo.Update(c);
                if (b)
                {
                    // ViewBag.Message = "Course Details Updated Successfully";
                    return RedirectToAction("GetCourses", "Admin");
                }
                else
                {
                    ViewBag.Message = "Course Details Updation Failed";
                    return View("ErrorAdmin");
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = "An error occurred while updating the course details: " + ex.Message;
                return View("ErrorAdmin");
            }
        }
        public ActionResult CourseDetail(int id)
        {
            Course c = cbo.Get(id);
            return View(c);
        }
        public ActionResult ViewMapTeacher(int id)
        {
            List<CourseTeacher> ctlist = ctbo.GetAll().Where(o=>o.CourseId==id).ToList();
            return View(ctlist);
        }
        public ActionResult DeleteCourse(int id)
        {
            Course c = cbo.Get(id);
            bool b = cbo.Delete(c);
            if (b)
            {
                ViewBag.Message = "Course Details Deleted Successfully";
                return View("SuccessAdmin");
            }
            return View();
        }
        public ActionResult ViewEnrollments()
        {

            List<Enrollment> enrollments = ebo.GetAll();
            return View(enrollments);

        }
       






















    }
}