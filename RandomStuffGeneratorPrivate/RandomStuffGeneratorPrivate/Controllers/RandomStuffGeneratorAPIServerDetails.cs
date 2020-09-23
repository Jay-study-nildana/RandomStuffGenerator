using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RandomStuffGeneratorPrivate.APIJSONClasses;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RandomStuffGeneratorPrivate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RandomStuffGeneratorAPIServerDetails : ControllerBase
    {

        [HttpGet]
        [Route("Hi")]
        public ActionResult<GeneralAPIResponse> ServerDetailsHi()
        {
            var tempItemViewModel = new GeneralAPIResponse();

            var tempString1 = "This is a Self Contained API Server";
            var tempString2 = "It has its own local SQLite database";
            var tempString3 = "It uses EF Core so you can modify the database from code as it pleases you";
            var tempString4 = "Docker is configured.";
            var tempString5 = "Project Started on September 23rd 2020";
            var tempString6 = "Contact the developer at jay@thechalakas.com";

            //lets add all these things to the return collection. 
            tempItemViewModel.ListOfResponses.Add(tempString1);
            tempItemViewModel.ListOfResponses.Add(tempString2);
            tempItemViewModel.ListOfResponses.Add(tempString3);
            tempItemViewModel.ListOfResponses.Add(tempString4);
            tempItemViewModel.ListOfResponses.Add(tempString5);
            tempItemViewModel.ListOfResponses.Add(tempString6);

            return tempItemViewModel;
        }
    }
}
