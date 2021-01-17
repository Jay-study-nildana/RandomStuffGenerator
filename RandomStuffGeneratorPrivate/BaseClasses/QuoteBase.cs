using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomStuffGeneratorPrivate.BaseClasses
{
    //at a bare minimum, every quote must have a title and a content.
    public abstract class QuoteBase : QuoteCoreBase
    {
        //this is the actual quote identifier used by the CMS.
        public string QuoteIdentifierString { get; set; }
    }
}
