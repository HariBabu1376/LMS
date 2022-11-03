using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Models
{
    public class Leaves
    {
        [Required]
        [Key]
        [Display(Name = "LeaveID")]
        public int LID { get; set; }
        [Required]
        [Display(Name = "Leave Status")]
        public string LStatus { get; set; }
    }
}
