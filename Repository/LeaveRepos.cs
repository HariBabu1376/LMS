using LMS.Data_Access_Layer;
using LMS.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Repository
{
    public class LeaveRepos : ILeave
    {
        private readonly LMS_DbContext lMS_DbContext;

        public LeaveRepos(LMS_DbContext lMS_DbContext)
        {
            this.lMS_DbContext = lMS_DbContext;
        }
        public async Task<int> AddLeaves(Leaves leaves)
        {
            var le = new Leaves()
            {
                LID = leaves.LID,
                LStatus = leaves.LStatus
            };
            lMS_DbContext.Leaves.Add(le);
            await lMS_DbContext.SaveChangesAsync();
            return le.LID;
        }

        public async Task<int> DeleteLeaves(int id)
        {
            var ar = lMS_DbContext.Leaves.Where(x => x.LID == id).FirstOrDefault();
            if (ar != null)
            {
                lMS_DbContext.Leaves.Remove(ar);
            }

            await lMS_DbContext.SaveChangesAsync();
            return ar.LID;
        }

        public async Task<List<Leaves>> LeaveDet()
        {
            List<Leaves> leavelst = new List<Leaves>();
            var ar = await lMS_DbContext.Leaves.ToListAsync();
            foreach (Leaves le in ar)
            {
                leavelst.Add(new Leaves
                {
                    LID = le.LID,
                    LStatus = le.LStatus
                }) ;
            }

            return leavelst;
        }

        public async Task<int> UpdateLeaves(int id, Leaves leaves)
        {
            var ar = lMS_DbContext.Leaves.Where(x => x.LID == id).FirstOrDefault();
            if (ar != null)
            {
                
                ar.LStatus = leaves.LStatus;
            }

            await lMS_DbContext.SaveChangesAsync();
            return ar.LID;
        }
    }
}
