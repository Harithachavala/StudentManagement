using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentManagementSystem.Models
{
    public class Teacher
    {
        [Key] //Primary key
        public string TeacherId { get; set; }

        public string TeacherName { get; set; }
        public string TeacherQualification { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Username cannot be longer than 50 characters.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Password should be minimum 8 characters and a maximum of 100 characters.")]
        public string Password { get; set; }

        public string AssignedCourse { get; set; }

        //Navigation Properties(relationships)
        public ICollection<CourseTeacher> AssignedCourses { get; set; }

    }
}