using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LMS.Repository;
using LMS.Models;

namespace LMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManInfoController : ControllerBase
    {
        IManager dbmanager;
        public ManInfoController(IManager dbmanager)
        {
            this.dbmanager = dbmanager;
        }
        [HttpGet]
        public async Task<IActionResult> Display()
        {
            var ar = await dbmanager.GetManager();
            return Ok(ar);
        }
        [HttpPost]
        public async Task<IActionResult> AddManager([FromBody] Managers managers)
        {
            var ar = await dbmanager.AddManager(managers);
            return Ok(managers);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var ar = await dbmanager.DeleteManager(id);
            return Ok(ar);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Managers managers)
        {
            var ar = await dbmanager.UpdateManager(id, managers);
            return Ok(ar);
        }



    }
}
