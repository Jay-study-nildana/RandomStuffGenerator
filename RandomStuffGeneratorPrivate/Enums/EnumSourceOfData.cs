using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomStuffGeneratorPrivate.Enums
{
    //As of Version 0.3.0 I am using two types of datasources
    //Quotes can come from memory - useful for unit testing
    //Quotes can come from Database 
    //the helpers and majority of app should be able to use either of them, and almost all methods
    //should be able to switch between what we need to do based on this option.
    public enum EnumSourceOfData
    {
        DataBaseInMemory,
        DataBaseInContext
    }
}
