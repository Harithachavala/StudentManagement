using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StudentManagementSystem.Models
{
    public class Enrollment
    {
        [Key] //primary key
        public int EnrollmentId { get; set; }

        //Foreign keys
        [ForeignKey("Course")]
        public int CourseId { get; set; }

        [ForeignKey("Student")]
        public string StudentId { get; set; }

        public DateTime EnrollmentDate { get; set; }

        //navigation properties(relationships)
        public Student Student { get; set; }
        public Course Course { get; set; }

    }
}