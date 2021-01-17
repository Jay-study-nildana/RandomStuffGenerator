using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RandomStuffGeneratorPrivate.APIJSONClasses;
using RandomStuffGeneratorPrivate.DatabaseClasses;
using RandomStuffGeneratorPrivate.Enums;
using RandomStuffGeneratorPrivate.HelperStuff;
using RandomStuffGeneratorPrivate.Interfaces;
using RandomStuffGeneratorPrivate.OtherClasses;
using RandomStuffGeneratorPrivate.POCO;

namespace RandomStuffGeneratorPrivate.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Policy = "User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        //here is the context

        private readonly QuoteCMSContext _context;

        public UserController(QuoteCMSContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("Hi")]
        public ActionResult<GeneralAPIResponse> ServerDetailsHi()
        {
            var generalAPIResponse = new GeneralAPIResponse();

            var tempString1 = "Okay, You have User Role";
            generalAPIResponse.ListOfResponses.Add(tempString1);
            generalAPIResponse.dateTimeOfResponse = DateTime.Now;

            return generalAPIResponse;
        }

        //I dont need this. we already have GetQuoteAlongWithItsLifeStory

        //[HttpPost]
        //[Route("GetASpecificQuote")]
        //public async Task<ActionResult<QuoteCube>> GetASpecificQuote(QuoteSpecificCubeRequest quoteCubeRequest)
        //{
        //    var tempQuoteCube = new QuoteCube();
        //    IReturnSingleQuote returnSingleQuote = new ReturnSingleQuote();
        //    OptionsSingleQuote optionsSingleQuote = new OptionsSingleQuote();

        //    //setting options
        //    optionsSingleQuote.enumSourceOfData = EnumSourceOfData.DataBaseInContext;
        //    //quote is random
        //    optionsSingleQuote.RandomQuote = false;
        //    //set the context.
        //    optionsSingleQuote.bloggingContext = _context;
        //    //set the quote identifier.
        //    optionsSingleQuote.QuoteIdentifierCompadre = quoteCubeRequest.QuoteIdentifier;

        //    tempQuoteCube = await returnSingleQuote.ReturnASingleQuote(optionsSingleQuote);

        //    //add the general response
        //    var generalAPIResponse = new GeneralAPIResponse();
        //    generalAPIResponse.dateTimeOfResponse = DateTime.Now;
        //    tempQuoteCube.generalAPIResponse = generalAPIResponse;

        //    return tempQuoteCube;
        //}
    }
}
