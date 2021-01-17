using RandomStuffGeneratorPrivate.BaseClasses;
using RandomStuffGeneratorPrivate.DatabaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomStuffGeneratorPrivate.OtherClasses
{
    public class OptionsCollectionOfQuotes : OptionsBase
    {
        public int NumberOfQuotes { set; get; }

        public OptionsCollectionOfQuotes()
        {
            //default number of quotes is 5;
            NumberOfQuotes = 5;
        }
    }
}
