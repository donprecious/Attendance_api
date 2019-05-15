using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AttendanceApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Organisation/[action]")]
    public class OrganisationController : Controller
    {

        [HttpPost]
        public async Task<IActionResult> Create()
        {
            return Ok();
        }
    }
}