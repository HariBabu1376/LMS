using LMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Repository
{
    public interface IEmployee
    {
        Task<List<Employees>> GetEmployees();
        Task<int> AddEmployees(Employees employees);
        Task<int> UpdateEmployees(int id, Employees employees);
        Task<int> DeleteEmployees(int id);
    }
}
