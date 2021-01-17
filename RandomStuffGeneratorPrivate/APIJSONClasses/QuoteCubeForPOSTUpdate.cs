using RandomStuffGeneratorPrivate.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomStuffGeneratorPrivate.APIJSONClasses
{
    public class QuoteCubeForPOSTUpdate : QuoteCubeForPOSTCreate
    {
        public string QuoteIdentifierString { get; set; }
    }
}
