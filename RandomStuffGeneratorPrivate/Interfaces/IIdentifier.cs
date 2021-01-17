using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomStuffGeneratorPrivate.Interfaces
{
    //the project will have many identifiers. use this for all of them.
    public interface IIdentifier
    {
        public string GenerateIdentifierString();
        public string GenerateIdentifierString(string fullname);
    }
}
