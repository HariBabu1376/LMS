using LMS.Models;
using LMS.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveInfoController : ControllerBase
    {
        ILeave dbleave;
        public LeaveInfoController(ILeave dbleave)
        {
            this.dbleave = dbleave;
        }
        [HttpGet]
        public async Task<IActionResult> Display()
        {
            var ar = await dbleave.LeaveDet();
            return Ok(ar);
        }
        [HttpPost]
        public async Task<IActionResult> AddLeaves([FromBody] Leaves leaves)
        {
            var ar = await dbleave.AddLeaves(leaves);
            return Ok(leaves);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var ar = await dbleave.DeleteLeaves(id);
            return Ok(ar);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Leaves leaves)
        {
            var ar = await dbleave.UpdateLeaves(id, leaves);
            return Ok(ar);
        }
    }
}
