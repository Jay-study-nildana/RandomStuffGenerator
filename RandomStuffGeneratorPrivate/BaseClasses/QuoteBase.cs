using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomStuffGeneratorPrivate.BaseClasses
{
    //at a bare minimum, every quote must have a title and a content.
    public abstract class QuoteBase
    {
        public string QuoteTitle { get; set; }
        public string QuoteContent { get; set; }
    }
}
