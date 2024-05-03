using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StudentManagementSystem.Models
{
    public class Grade
    {
        [Key] //primary key
        public int GradeId { get; set; }
        public string GradeName { get; set; }

        //Foreign key
        [ForeignKey("Enrollment")]
        public int EnrolledId { get; set; }

        //Navigation property(relationship)
        public Enrollment Enrollment { get; set; }


    }
}