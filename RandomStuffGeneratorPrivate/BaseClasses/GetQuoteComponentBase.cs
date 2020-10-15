using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomStuffGeneratorPrivate.BaseClasses
{
    //similar to GetQuoteCollectionBase
    public abstract class GetQuoteComponentBase
    {
        //for instance, the user might indicate they need additional quote detail along with the standard detail
        //and ask for specific quote details like a filter.
        //further, this may be reused in the collection return.
        public bool extradetail { set; get; }

        //of course, the user identifier needs to be specified.
        public string QuoteIdentifier { set; get; }
    }
}
