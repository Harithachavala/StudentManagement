using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentManagementSystem.Models
{
    public class Student
    {
        [Key] //primary key
        public string StudentId { get; set; }

        [Required]
        public string FirstName { get; set; }


        [Required]
        public string LastName { get; set; }


        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [StringLength(10)]
        public string Gender { get; set; }


        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        public long PhoneNumber { get; set; }

        [MaxLength(100)]
        public string Address { get; set; }


        public string City { get; set; }
        public string State { get; set; }

        [Required]
        public DateTime EnrolledDate { get; set; }

        [MaxLength(50)]
        public string EnrolledCourse { get; set; }


        [StringLength(50)]
        public string FeeStatus { get; set; }

        //Navigation properties(relationships)
        public ICollection<Enrollment> Enrollments { get; set; }



    }
}