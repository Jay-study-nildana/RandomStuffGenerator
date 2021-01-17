using RandomStuffGeneratorPrivate.DatabaseClasses;
using RandomStuffGeneratorPrivate.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomStuffGeneratorPrivate.BaseClasses
{
    public abstract class OptionsBase
    {
        //used to indicate the source of data.
        public EnumSourceOfData enumSourceOfData { set; get; }

        //if source is database, we need context information to be provided.
        public QuoteCMSContext bloggingContext { set; get; }
    }

    
}
