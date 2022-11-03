using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LMS.Models
{
    public class Login
    {

        [Key]
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Username{ get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
