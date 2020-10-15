using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomStuffGeneratorPrivate.BaseClasses
{
    public abstract class ResponseBase
    {
        public string dateTimeOfRun { set; get; }

        public string TimeZone { set; get; }
    }
}
