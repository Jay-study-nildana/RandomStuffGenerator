using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomStuffGeneratorPrivate.BaseClasses
{
    public abstract class GetQuoteCollectionBase
    {
        public int QuoteCount { set; get; }

        public GetQuoteCollectionBase()
        {
            //be default we return 10 quotes
            //TODO - not yet implemented
            QuoteCount = 10;
        }
    }
}
