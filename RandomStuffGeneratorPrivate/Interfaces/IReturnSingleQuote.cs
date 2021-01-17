using RandomStuffGeneratorPrivate.APIJSONClasses;
using RandomStuffGeneratorPrivate.OtherClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomStuffGeneratorPrivate.Interfaces
{
    //This is used to return a single quote.
    public interface IReturnSingleQuote
    {
        public Task<QuoteCube> ReturnASingleQuote(OptionsSingleQuote optionsSingleQuote);
    }
    
}
