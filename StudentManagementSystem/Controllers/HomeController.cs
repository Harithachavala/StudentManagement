using StudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        StudentContext context = new StudentContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult Gallery()
        {
            return View();
        }
        public ActionResult Register()
        {
            Student student = new Student();
            student.StudentId = "Stud" + (new Random()).Next(1000, 99999);
            student.EnrolledDate = DateTime.Now;
            student.EnrolledCourse = String.Empty;
            Session.Add("ID", student.StudentId);
            return View(student);
        }
        [HttpPost]
        public ActionResult Register(Student student)
        {

            try
            {
                context.Students.Add(student);
                int r = context.SaveChanges();

                if (r > 0)
                {
                    string password = "Psw" + (new Random()).Next(1000, 99999);
                    Login login = new Login()
                    {
                        LoginId = student.StudentId,
                        Password = password,
                        Role = "Student"
                    };
                    context.Logins.Add(login);
                    r = context.SaveChanges();
                    if (r > 0)
                    {
                        ViewBag.Message = "Registration Success";
                        return View("Success");
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Registration Failed";
                return View("Error");
            }

            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection frmc)
        {

            string loginId = frmc["LoginId"];
            string password = frmc["Password"];
            string role = frmc["Role"];

            Login login = context.Logins
                .Where(l => l.LoginId == loginId && l.Password == password && l.Role == role)
                .FirstOrDefault();
            if (login != null)
            {
                Session.Add("LoginId", login.LoginId);
                if (login.Role == "Teacher")
                {
                    return RedirectToAction("TeacherHome", "Teacher");
                }
                if (login.Role == "Student")
                {
                    return RedirectToAction("StudentHome", "Student");
                }
                if (login.Role == "admin")
                {
                    return RedirectToAction("AdminHome", "Admin");

                }
            }
            else
            {
                ViewBag.Message = "Login Credentials Invalid";
                return View("Error");
            }
            return RedirectToAction("Index");
        }


    }

    
}