using LMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Data_Access_Layer
{
    public class ApplyLeaveDb
    {
        [Required]
        [Key]
        [Display(Name = "Token")]
        public int Token { get; set; }
        
        public int LID { get; set; }
        [ForeignKey("LID")]
        public virtual Leaves Leaves { get; set; }
        
        public int EmpID { get; set; }
        [ForeignKey("EmpID")]
        public virtual Employees Employees { get; set; }
    }
}
