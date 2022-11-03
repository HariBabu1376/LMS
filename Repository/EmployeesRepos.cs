using AutoMapper;
using LMS.Data_Access_Layer;
using LMS.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Repository
{
    public class EmployeesRepos : IEmployee
    {
        private readonly LMS_DbContext lMS_DbContext;
        private readonly IMapper mapper;

        public EmployeesRepos(LMS_DbContext lMS_DbContext, IMapper mapper)
        {
            this.lMS_DbContext = lMS_DbContext;
            this.mapper = mapper;
        }
        public async Task<int> AddEmployees(Employees employees)
        {
            var emp = new Employees()
            {
                EmpID=employees.EmpID,
                Fname = employees.Fname,
                Lname = employees.Lname,
                Email = employees.Email,
                Password = employees.Password,
                ConPwd = employees.ConPwd,
                Gen = employees.Gen,
                Ph = employees.Ph,
                Date = employees.Date
            };
            lMS_DbContext.Employees.Add(emp);
            await lMS_DbContext.SaveChangesAsync();
            return emp.EmpID;
        }

        public async Task<int> DeleteEmployees(int id)
        {

            var ar = lMS_DbContext.Employees.Where(x => x.EmpID == id).FirstOrDefault();
            if (ar != null)
            {
                lMS_DbContext.Employees.Remove(ar);
            }
            
            await lMS_DbContext.SaveChangesAsync();
            return ar.EmpID;
        }

        public async Task<List<Employees>> GetEmployees()
        {
            List<Employees> emplst = new List<Employees>();
            var ar = await lMS_DbContext.Employees.ToListAsync();
            foreach (Employees em in ar)
            {
                emplst.Add(new Employees
                {
                    EmpID = em.EmpID,
                    Fname = em.Fname,
                    Lname = em.Lname,
                    Email = em.Email,
                    Password = em.Password,
                    ConPwd = em.ConPwd,
                    Gen = em.Gen,
                    Ph = em.Ph,
                    Date = em.Date
                });
            }
            return emplst;
            //var ar = await lMS_DbContext.Employees.ToListAsync();
            //return mapper.Map<List<Employees>>(ar);

        }

        public async Task<int> UpdateEmployees(int id, Employees employees)
        {
            var ar = lMS_DbContext.Employees.Where(x => x.EmpID == id).FirstOrDefault();
            if(ar!=null)
            {
                ar.Email = employees.Email;
                ar.Ph = employees.Ph;
            }
            
            await lMS_DbContext.SaveChangesAsync();
            return ar.EmpID;
        }
    }
}
