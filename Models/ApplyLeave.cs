using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Models
{
    public class ApplyLeave
    {
        [Required]
        [Key]
        [Display(Name = "Token")]
        public int Token { get; set; }
        public int LID { get; set; }
        public int EmpID { get; set; }
        
        

    }
}
