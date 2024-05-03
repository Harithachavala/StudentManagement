using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentManagementSystem.Models
{
    public class Course
    {
        [Key] //primary key
        public int CourseId { get; set; }

        public string CourseName { get; set; }
        public int Credits { get; set; }
        public string CourseDuration { get; set; }
        public decimal CourseFee { get; set; }

        //Navigation properties(relationships)
        public ICollection<Enrollment> Enrollment { get; set; }
    }
}