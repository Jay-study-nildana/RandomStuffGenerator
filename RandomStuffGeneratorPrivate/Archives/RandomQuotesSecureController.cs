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

//the secured version of public class RandomQuotesController : ControllerBase
namespace RandomStuffGeneratorPrivate.Controllers
{

    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class RandomQuotesSecureController : ControllerBase
    {
        //here is the context

        private readonly BloggingContext _context;

        public RandomQuotesSecureController(BloggingContext context)
        {
            _context = context;
        }

        [HttpGet]

        [Route("GetHoldOfthem")]
        public async Task<ActionResult<QuoteCube>> GetASingleQuoteAsync()
        {
            var tempItemViewModel = new QuoteCube();
            var tempQuoteHelpers = new QuoteHelpers();

            //use this to return a quote from memory, when database is not there
            //tempItemViewModel = tempQuoteHelpers.ReturnASingleQuoteInMemory();

            tempItemViewModel = await tempQuoteHelpers.ReturnASingleQuoteAsync(_context);

            return tempItemViewModel;
        }


        //I am pretty sure this entire code will be endlessly modularized.
        //right now its just hacked together.
        [HttpPost]
        [Route("PutThemOn")]
        public async Task<ActionResult<GeneralAPIResponse>> PostQuote(QuoteCubeAdd quote)
        {
            var tempQuoteHelpers = new QuoteHelpers();
            var tempSecretPhrase = tempQuoteHelpers.ReturnTheSecretForAdding();
            var tempItemViewModel = new GeneralAPIResponse();

            var tempString1 = "Empty";
            var tempString2 = "Empty";

            if (quote.SecretPhrase.Equals(tempSecretPhrase) == true)
            {
                //okay secret phrase provided
                //add this up.

                //build our adding object
                var tempQuote = new Quote();
                tempQuote.QuoteContent = quote.QuoteContent;
                tempQuote.QuoteTitle = quote.QuoteTitle;

                //now the object is ready. 
                _context.Quotes.Add(tempQuote);
                await _context.SaveChangesAsync();

                tempString1 = "Okay man. Quote has been added. I really hope this is the API server owner adding all these quotes";
                tempString2 = "The id of the newly added Quote is " + tempQuote.QuoteId;

            }
            else
            {
                tempString1 = "Dude. You dont have the secret phrase. Only secret phrase knowing folks can add quotes to this sytem";
                tempString2 = "Sincere Apologies";
            }

            //lets add all these things to the return collection. 
            tempItemViewModel.ListOfResponses.Add(tempString1);
            tempItemViewModel.ListOfResponses.Add(tempString2);

            //_context.Quotes.Add(quote);
            //await _context.SaveChangesAsync();

            //return CreatedAtAction("GetQuote", new { id = quote.QuoteId }, quote);

            return tempItemViewModel;
        }

        [HttpGet]

        [Route("GetAllTheQuotes")]
        public async Task<ActionResult<List<ReturnedQuote>>> GetAllQuotes()
        {
            var tempQuoteHelpers = new QuoteHelpers();
            var tempReturningCollection = new List<ReturnedQuote>();
            tempReturningCollection = await tempQuoteHelpers.GetTheQuotesBeastMan(_context);

            return tempReturningCollection;
        }


    }
}
