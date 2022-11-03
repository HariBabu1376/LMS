using LMS.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Data_Access_Layer
{
    public class LMS_DbContext:DbContext
    {
        public LMS_DbContext(DbContextOptions<LMS_DbContext>options):base(options)
        {

        }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Managers> Managers { get; set; }
        public DbSet<Leaves> Leaves { get; set; }
        public DbSet<ApplyLeaveDb> ApplyLeave { get; set; }
    }
}
