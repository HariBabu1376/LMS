using LMS.Data_Access_Layer;
using LMS.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Repository
{
    public class ManagerRepos : IManager
    {
        private readonly LMS_DbContext lMS_DbContext;

        public ManagerRepos(LMS_DbContext lMS_DbContext)
        {
            this.lMS_DbContext = lMS_DbContext;
        }
        public async Task<int> AddManager(Managers managers)
        {
            var man = new Managers()
            {
                ManID = managers.ManID,
                Fname = managers.Fname,
                Lname = managers.Lname,
                Email = managers.Email,
                Password = managers.Password,
                ConPwd = managers.ConPwd,
                Gen = managers.Gen,
                Ph = managers.Ph,
                Date = managers.Date
            };
            lMS_DbContext.Managers.Add(man);
            await lMS_DbContext.SaveChangesAsync();
            return man.ManID;
        }

        public async Task<int> DeleteManager(int id)
        {
            var ar = lMS_DbContext.Managers.Where(x => x.ManID == id).FirstOrDefault();
            if (ar != null)
            {
                lMS_DbContext.Managers.Remove(ar);
            }

            await lMS_DbContext.SaveChangesAsync();
            return ar.ManID;
        }

        public async Task<List<Managers>> GetManager()
        {
            List<Managers> manlst = new List<Managers>();
            var ar = await lMS_DbContext.Managers.ToListAsync();
            foreach (Managers m in ar)
            {
                manlst.Add(new Managers
                {
                    ManID = m.ManID,
                    Fname = m.Fname,
                    Lname = m.Lname,
                    Email = m.Email,
                    Password = m.Password,
                    ConPwd = m.ConPwd,
                    Gen = m.Gen,
                    Ph = m.Ph,
                    Date = m.Date
                });
            }
            return manlst;
        }

        public async Task<int> UpdateManager(int id, Managers managers)
        {
            var ar = lMS_DbContext.Managers.Where(x => x.ManID == id).FirstOrDefault();
            if (ar != null)
            {
                ar.Email = managers.Email;
                ar.Ph = managers.Ph;
            }

            await lMS_DbContext.SaveChangesAsync();
            return ar.ManID;
        }
    }
}
