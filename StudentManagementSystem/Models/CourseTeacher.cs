using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StudentManagementSystem.Models
{
    public class CourseTeacher
    {
        [Key] //Primary key
        public int CourseTeacherId { get; set; }

        //Foreign keys
        [ForeignKey("Teacher")]
        public string TeacherId { get; set; }


        [ForeignKey("Course")]
        public int CourseId { get; set; }

        //Navigation properties(relationships)
        public Course Course { get; set; }
        public Teacher Teacher { get; set; }

    }
}