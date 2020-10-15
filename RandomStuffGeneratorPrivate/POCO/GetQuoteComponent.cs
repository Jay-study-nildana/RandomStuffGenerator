using RandomStuffGeneratorPrivate.BaseClasses;
using RandomStuffGeneratorPrivate.DatabaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomStuffGeneratorPrivate.POCO
{
    //also look at GetQuoteCollectionComponent
    public class GetQuoteComponent : GetQuoteComponentBase
    {
        //put additional properties specific to this call
        public BloggingContext bloggingContext { set; get; }
    }
}
