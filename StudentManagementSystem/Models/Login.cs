using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentManagementSystem.Models
{
    public class Login
    {
       [ Key]
        public string LoginId { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}