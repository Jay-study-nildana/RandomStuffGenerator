using RandomStuffGeneratorPrivate.DatabaseClasses;
using RandomStuffGeneratorPrivate.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomStuffGeneratorPrivate.Interfaces
{
    //this interface will collect all the quotes and return it for viewing.
    public interface IGetCollectionOfQuotes
    {
        public List<Object> QuoteCollection(Object context);
    }
}
