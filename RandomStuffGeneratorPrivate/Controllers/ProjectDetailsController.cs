using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RandomStuffGeneratorPrivate.APIJSONClasses;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RandomStuffGeneratorPrivate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectDetailsController : ControllerBase
    {

        [HttpGet]
        [Route("Hi")]
        public ActionResult<GeneralAPIResponse> ServerDetailsHi()
        {
            var generalAPIResponse = new GeneralAPIResponse();

            var tempString1 = "This is a Self Contained API Server";
            var tempString2 = "It has its own local SQLite database";
            var tempString3 = "It uses EF Core so you can modify the database from code as it pleases you";
            var tempString4 = "Docker is configured.";
            var tempString5 = "Project Started on September 23rd 2020";
            var tempString6 = "Contact the developer at jay@thechalakas.com";

            //lets add all these things to the return collection. 
            generalAPIResponse.ListOfResponses.Add(tempString1);
            generalAPIResponse.ListOfResponses.Add(tempString2);
            generalAPIResponse.ListOfResponses.Add(tempString3);
            generalAPIResponse.ListOfResponses.Add(tempString4);
            generalAPIResponse.ListOfResponses.Add(tempString5);
            generalAPIResponse.ListOfResponses.Add(tempString6);
            generalAPIResponse.dateTimeOfResponse = DateTime.Now;

            return generalAPIResponse;
        }

        //[HttpGet]
        //[Route("PenScope1")]
        //[Authorize(Policy = "penquotes")]
        //public ActionResult<GeneralAPIResponse> PenScope1()
        //{
        //    var tempItemViewModel = new GeneralAPIResponse();
        //    var tempString1 = "You have the PEN Scope as per the rules"; 
        //    tempItemViewModel.ListOfResponses.Add(tempString1);
        //    return tempItemViewModel;
        //}

        //[HttpGet]
        //[Route("CapScope1")]
        //[Authorize(Policy = "capquotes")]
        //public ActionResult<GeneralAPIResponse> CapScope1()
        //{
        //    var tempItemViewModel = new GeneralAPIResponse();

        //    var tempString1 = "You have the CAP Scope as per the rules";
        //    //var tempString2 = "It has its own local SQLite database";
        //    //var tempString3 = "It uses EF Core so you can modify the database from code as it pleases you";
        //    //var tempString4 = "Docker is configured.";
        //    //var tempString5 = "Project Started on September 23rd 2020";
        //    //var tempString6 = "Contact the developer at jay@thechalakas.com";

        //    //lets add all these things to the return collection. 
        //    tempItemViewModel.ListOfResponses.Add(tempString1);
        //    //tempItemViewModel.ListOfResponses.Add(tempString2);
        //    //tempItemViewModel.ListOfResponses.Add(tempString3);
        //    //tempItemViewModel.ListOfResponses.Add(tempString4);
        //    //tempItemViewModel.ListOfResponses.Add(tempString5);
        //    //tempItemViewModel.ListOfResponses.Add(tempString6);

        //    return tempItemViewModel;
        //}

        //// This is a helper action. It allows you to easily view all the claims of the token.
        ////borrowed from https://github.com/auth0-samples/auth0-aspnetcore-webapi-samples/blob/master/Quickstart/01-Authorization/Controllers/ApiController.cs
        //[HttpGet("claims")]
        //public IActionResult Claims()
        //{
        //    return Ok(User.Claims.Select(c =>
        //        new
        //        {
        //            c.Type,
        //            c.Value
        //        }));
        //}
    }
}
