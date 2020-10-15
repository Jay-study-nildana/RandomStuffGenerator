using RandomStuffGeneratorPrivate.BaseClasses;
using RandomStuffGeneratorPrivate.DatabaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomStuffGeneratorPrivate.POCO
{
    public class GetQuoteCollectionComponent : GetQuoteCollectionBase
    {
        public BloggingContext bloggingContext { set; get; }


    }
}
