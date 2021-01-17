using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomStuffGeneratorPrivate.APIJSONClasses
{
    //class that is used when sending a request for a specific quote
    //TODO - we need to upgrade all request POST related classses to use base classes
    public class QuoteSpecificCubeRequest
    {
        public string QuoteIdentifier { set; get; }
    }
}
