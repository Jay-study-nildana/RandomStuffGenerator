using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomStuffGeneratorPrivate.APIJSONClasses
{
    //I wanted to use classes inherited from a base class
    //but I got this error
    //Deserialization of reference types without parameterless constructor is not supported
    //I am sure there is a solution for that error
    //Right now, lets keep it simple. use a non-abstract POST body classes until we really, really, need to have abstract POST classes
    public class QuoteCubeAddForPOSTBody
    {
        public string SecretPhrase { get; set; }
        public string QuoteTitle { get; set; }
        public string QuoteContent { get; set; }
    }
}
