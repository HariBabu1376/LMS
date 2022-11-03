using LMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Repository
{
    public interface ILeave
    {
        Task<List<Leaves>> LeaveDet();
        Task<int> AddLeaves(Leaves leaves);
        Task<int> UpdateLeaves(int id, Leaves leaves);
        Task<int> DeleteLeaves(int id);
    }
}
