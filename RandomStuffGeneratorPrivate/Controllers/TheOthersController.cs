using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RandomStuffGeneratorPrivate.APIJSONClasses;
using RandomStuffGeneratorPrivate.DatabaseClasses;
using RandomStuffGeneratorPrivate.HelperStuff;

namespace RandomStuffGeneratorPrivate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TheOthersController : ControllerBase
    {
        //here is the context

        private readonly QuoteCMSContext _context;

        public TheOthersController(QuoteCMSContext context)
        {
            _context = context;
        }

        //TODO, can be put all this in a proper class
        //instead of return it raw.
        [HttpGet("claims")]
        [Authorize]
        public IActionResult Claims()
        {
            return Ok(User.Claims.Select(c =>
                new
                {
                    c.Type,
                    c.Value
                }));
        }

    }
}
