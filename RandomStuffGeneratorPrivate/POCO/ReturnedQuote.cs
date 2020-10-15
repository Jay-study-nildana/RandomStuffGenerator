using RandomStuffGeneratorPrivate.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomStuffGeneratorPrivate.POCO
{
    //this is the quote that is returned when the quote API calls
    public class ReturnedQuote : QuoteBase
    {
        public int QuoteId { get; set; }
    }
}
