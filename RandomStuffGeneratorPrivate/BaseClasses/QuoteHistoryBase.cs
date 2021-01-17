using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomStuffGeneratorPrivate.BaseClasses
{
    public abstract class QuoteHistoryBase
    {
        //this is the actual quote identifier used by the CMS.
        public string QuoteIdentifierString { get; set; }
        //the quote goes through its life. each life is a count of modification
        //when it is born, its 1. when its updated (deletion, modification, any operation on any of its values)
        //this increases by one.
        public int QuoteLifeStageIncrement { get; set; }
        //what was done to require a change in life stage. Those details come here.
        public string QuoteLifStageDescription { get; set; }
        //active or not. essentially, support for soft delete.
        public bool Active { get; set; }
    }
}
