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
    public class ApplyInfoController : ControllerBase
    {
        IApply dbapply;
        public ApplyInfoController(IApply dbapply)
        {
            this.dbapply = dbapply;
        }
        [HttpGet]
        public async Task<IActionResult> Display()
        {
            var ar = await dbapply.ApplyDet();
            return Ok(ar);
        }
        [HttpPost]
        public async Task<IActionResult> AddApply([FromBody] ApplyLeave applyLeave)
        {
            var ar = await dbapply.AddApply(applyLeave);
            return Ok(applyLeave);
        }
        [HttpDelete("{token}")]
        public async Task<IActionResult> Delete([FromRoute] int token)
        {
            var ar = await dbapply.DeleteApply(token);
            return Ok(ar);
        }
        [HttpPut("{token}")]
        public async Task<IActionResult> Update([FromRoute] int token, [FromBody] ApplyLeave applyLeave)
        {
            var ar = await dbapply.UpdateApply(token, applyLeave);
            return Ok(ar);
        }
    }
}
