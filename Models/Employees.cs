using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Models
{
    public class Employees
    {
        [Required]
        [Key]
        [Display(Name ="EmployeeID")]
        public int EmpID { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string Fname { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string Lname { get; set; }
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Display(Name = "Confirm Password")]
        [Compare("Password")]
        [DataType(DataType.Password)]
        public string ConPwd { get; set; }
        [Required]
        [Display(Name = "Gender")]
        public string Gen { get; set; }
        [Required]
        [Display(Name = "Phone")]
        public long Ph { get; set; }
        [Required]
        [Display(Name = "DOB")]
        [DataType(DataType.Date)]
        public string Date { get; set; }
    }
}

