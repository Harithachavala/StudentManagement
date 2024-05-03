using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StudentManagementSystem.Models
{
    public class StudentContext:DbContext
    {
        public StudentContext():base("dbconnect")
        {

        }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<CourseTeacher> CourseTeachers { get; set; }
        public virtual DbSet<Enrollment> Enrollments { get; set; }
        public virtual DbSet<Grade> Grades { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<Login> Logins { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
    }
}