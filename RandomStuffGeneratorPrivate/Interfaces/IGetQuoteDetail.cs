using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomStuffGeneratorPrivate.Interfaces
{
    //this interface is all about a getting a specific quote using a specific identifier.

    //QuoteIdentifier
    //I imaging as the project develops, there will be many ways to identify it.
    //for instance, right now, i have the auto generated quote ID
    //i already have plans to build a quote ID later

    //the return type is also vague. I have plans to have different return types depending on the role
    //controller being used and so on.
    public interface IGetQuoteDetail
    {
        public Object GetQuote(Object context);
    }
}
