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
using RandomStuffGeneratorPrivate.POCO;

namespace RandomStuffGeneratorPrivate.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Policy = "User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        //here is the context

        private readonly BloggingContext _context;

        public UserController(BloggingContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("Hi")]
        public ActionResult<GeneralAPIResponse> ServerDetailsHi()
        {
            var tempItemViewModel = new GeneralAPIResponse();

            var tempString1 = "Okay, You have User Role";

            //lets add all these things to the return collection. 
            tempItemViewModel.ListOfResponses.Add(tempString1);

            return tempItemViewModel;
        }

        [HttpPost]
        [Route("GetASpecificQuote")]
        public ActionResult<QuoteCubeResponse> GetASpecificQuote(QuoteSpecificCubeRequest quoteCubeRequest)
        {
            //helpers and stuff 
            var tempQuoteHelpers = new QuoteHelpers();

            //a quote return customization component.
            //as of now, we are not really providing any specific features but this is a placeholder for future.
            GetQuoteComponent getQuoteComponent = new GetQuoteComponent();
            getQuoteComponent.QuoteIdentifier = quoteCubeRequest.QuoteIdentifier;
            getQuoteComponent.bloggingContext = _context;


            QuoteCubeResponse quoteCubeResponse = tempQuoteHelpers.GetquoteCubeResponse(getQuoteComponent);

            return quoteCubeResponse;
        }
    }
}
