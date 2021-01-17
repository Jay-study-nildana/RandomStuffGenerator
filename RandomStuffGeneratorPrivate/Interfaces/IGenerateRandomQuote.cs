using RandomStuffGeneratorPrivate.OtherClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomStuffGeneratorPrivate.Interfaces
{
    //this will generate a random quote. Like, if I want to stress test this CMS, and dont want to manually enter some 
    //1 million quotes. Just build a component that generates quotes for me.
    public interface IGenerateRandomQuote
    {
        public string GenerateRandomAuthorName();
        public string GenerateRandomQuote();

        public QuoteCubeRandom GenerateQuoteCubeRandom();

    }
}
