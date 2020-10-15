using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RandomStuffGeneratorPrivate.APIJSONClasses;

namespace RandomStuffGeneratorPrivate.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Policy = "Admin")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        [HttpGet]
        [Route("Hi")]
        public ActionResult<GeneralAPIResponse> ServerDetailsHi()
        {
            var tempItemViewModel = new GeneralAPIResponse();

            var tempString1 = "Okay, You have Admin Role";

            //lets add all these things to the return collection. 
            tempItemViewModel.ListOfResponses.Add(tempString1);

            return tempItemViewModel;
        }
    }
}
