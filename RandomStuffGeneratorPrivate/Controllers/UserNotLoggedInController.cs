using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RandomStuffGeneratorPrivate.APIJSONClasses;
using RandomStuffGeneratorPrivate.DatabaseClasses;
using RandomStuffGeneratorPrivate.Enums;
using RandomStuffGeneratorPrivate.HelperStuff;
using RandomStuffGeneratorPrivate.Interfaces;
using RandomStuffGeneratorPrivate.OtherClasses;

namespace RandomStuffGeneratorPrivate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserNotLoggedInController : ControllerBase
    {
        //here is the context

        private readonly QuoteCMSContext _context;

        public UserNotLoggedInController(QuoteCMSContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("GetHoldOfthem")]
        public async Task<ActionResult<QuoteCube>> GetASingleQuoteAsync()
        {
            var tempQuoteCube = new QuoteCube();
            IReturnSingleQuote returnSingleQuote = new ReturnSingleQuote();
            OptionsSingleQuote optionsSingleQuote = new OptionsSingleQuote();

            //setting options
            optionsSingleQuote.enumSourceOfData = EnumSourceOfData.DataBaseInContext;
            //quote is random
            optionsSingleQuote.RandomQuote = true;
            //set the context.
            optionsSingleQuote.bloggingContext = _context;

            tempQuoteCube = await returnSingleQuote.ReturnASingleQuote(optionsSingleQuote);

            //add the general response
            var generalAPIResponse = new GeneralAPIResponse();
            generalAPIResponse.dateTimeOfResponse = DateTime.Now;
            tempQuoteCube.generalAPIResponse = generalAPIResponse;

            return tempQuoteCube;
        }
    }
}
