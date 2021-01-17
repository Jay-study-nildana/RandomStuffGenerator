using RandomStuffGeneratorPrivate.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomStuffGeneratorPrivate.OtherClasses
{
    public class OptionsSingleQuote : OptionsBase
    {
        //indicates if a specific or a random quote needs to be returned.
        public bool RandomQuote { set; get; }

        //the JSON version of Quote ID.
        //only required if an specific quote is being requested.
        public string QuoteIdentifierCompadre { get; set; }
    }
}
