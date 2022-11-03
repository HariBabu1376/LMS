using LMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Repository
{
    public interface IManager
    {
        Task<List<Managers>> GetManager();
        Task<int> AddManager(Managers managers);
        Task<int> UpdateManager(int id, Managers managers);
        Task<int> DeleteManager(int id);
    }
}
