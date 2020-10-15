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
    [Authorize(Policy = "Moderator")]
    [ApiController]
    public class ModeratorController : ControllerBase
    {
        //here is the context

        private readonly BloggingContext _context;

        public ModeratorController(BloggingContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("Hi")]
        public ActionResult<GeneralAPIResponse> ServerDetailsHi()
        {
            var tempItemViewModel = new GeneralAPIResponse();

            var tempString1 = "Okay, You have Moderator Role";

            //lets add all these things to the return collection. 
            tempItemViewModel.ListOfResponses.Add(tempString1);

            return tempItemViewModel;
        }

        [HttpGet]
        [Route("GetAllQuotes")]
        public ActionResult<QuoteCubeCollectionResponse> GetAllQuotes()
        {
            //helpers and stuff 
            var tempQuoteHelpers = new QuoteHelpers();

            //at some point in the future, I expert this get all quotes to become like a search engine.
            //for that we are going to use GetQuoteCollectionComponent and fill it up with whatever i need.
            GetQuoteCollectionComponent quoteCollectionComponent = new GetQuoteCollectionComponent();
            quoteCollectionComponent.bloggingContext = _context;

            QuoteCubeCollectionResponse quoteCubeCollectionResponse = tempQuoteHelpers.GetQuoteCubeCollectionResponse(quoteCollectionComponent);

            //TODO, we probably need a better time zone implementation. this is a quick fix.
            quoteCubeCollectionResponse.TimeZone = "Timezone used by Server is UTC aka GMT aka + 0 Time";

            return quoteCubeCollectionResponse;
        }
    }



}
