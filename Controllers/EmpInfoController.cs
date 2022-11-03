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
    public class EmpInfoController : ControllerBase
    {
        private readonly IEmployee dbemployee;
        public EmpInfoController(IEmployee dbemployee)
        {
            this.dbemployee = dbemployee;
        }
        [HttpGet]
        public async Task<IActionResult>Display()
        {
            var ar = await dbemployee.GetEmployees();
            return Ok(ar);
        }
        [HttpPost]
        public async Task<IActionResult> AddEmployees([FromBody] Employees employees)
        {
            var ar = await dbemployee.AddEmployees(employees);
            return Ok(employees);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var ar = await dbemployee.DeleteEmployees(id);
            return Ok(ar);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Employees employees)
        {
            var ar = await dbemployee.UpdateEmployees(id,employees);
            return Ok(ar);
        }
    }
}
