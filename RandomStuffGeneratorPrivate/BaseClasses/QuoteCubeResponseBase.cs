using RandomStuffGeneratorPrivate.APIJSONClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomStuffGeneratorPrivate.BaseClasses
{
    //also look at - QuoteCubeCollectionResponseBase
    public class QuoteCubeResponseBase : ResponseBase
    {
        public QuoteCube quoteCube { set; get; }
    }
}
