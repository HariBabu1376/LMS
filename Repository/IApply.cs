using LMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Repository
{
    public interface IApply
    {
        Task<List<ApplyLeave>> ApplyDet();
        Task<int> AddApply(ApplyLeave applyLeave);
        Task<int> UpdateApply(int token, ApplyLeave applyLeave);
        Task<int> DeleteApply(int token);
    }
}
