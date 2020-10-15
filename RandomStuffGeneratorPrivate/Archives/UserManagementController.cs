using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RandomStuffGeneratorPrivate.HelperStuff;
using RandomStuffGeneratorPrivate.POCO;

namespace RandomStuffGeneratorPrivate.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class UserManagementController : ControllerBase
    {
        //I want to get all the users, using the management API.
        [HttpGet]
        [Route("GetAllUsers")]
        public async Task<ActionResult<List<AllUsers445>>> GetASingleQuoteAsync()
        {
            var tempManagementAPIHelpers = new ManagementAPIHelpers();

            var tempResponse = await tempManagementAPIHelpers.GetAllUsersAsync();

            return tempResponse;
        }
    }
}
