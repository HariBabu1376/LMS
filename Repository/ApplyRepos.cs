using LMS.Data_Access_Layer;
using LMS.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Repository
{
    public class ApplyRepos : IApply
    {
        private readonly LMS_DbContext lMS_DbContext;

        public ApplyRepos(LMS_DbContext lMS_DbContext)
        {
            this.lMS_DbContext = lMS_DbContext;
        }
        public async Task<int> AddApply(ApplyLeave applyLeave)
        {
            var apl = new ApplyLeaveDb()
            {
                Token = applyLeave.Token,
                LID = applyLeave.LID,
                EmpID = applyLeave.EmpID
            };
            lMS_DbContext.ApplyLeave.Add(apl);
            await lMS_DbContext.SaveChangesAsync();
            return apl.Token;
        }


        public async Task<List<ApplyLeave>> ApplyDet()
        {
            List<ApplyLeave> applst = new List<ApplyLeave>();
            var ar = await lMS_DbContext.ApplyLeave.ToListAsync();
            foreach (ApplyLeaveDb al in ar)
            {
                applst.Add(new ApplyLeave
                {
                    Token = al.Token,
                    LID = al.LID,
                    EmpID = al.EmpID
                });
            }
            return applst;

        }

        public async Task<int> DeleteApply(int token)
        {
            var ar = lMS_DbContext.ApplyLeave.Where(x => x.Token== token).FirstOrDefault();
            if (ar != null)
            {
                lMS_DbContext.ApplyLeave.Remove(ar);
            }

            await lMS_DbContext.SaveChangesAsync();
            return ar.Token;
        }

        public async Task<int> UpdateApply(int token, ApplyLeave applyLeave)
        {
            var ar = lMS_DbContext.ApplyLeave.Where(x => x.Token == token).FirstOrDefault();
            if (ar != null)
            {
                ar.LID = applyLeave.LID;
                ar.EmpID = applyLeave.EmpID;
            }

            await lMS_DbContext.SaveChangesAsync();
            return ar.Token;
        }
    }
}
