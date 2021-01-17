using RandomStuffGeneratorPrivate.BaseClasses;
using RandomStuffGeneratorPrivate.HelperStuff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomStuffGeneratorPrivate.APIJSONClasses
{
    public class CRUDAPIResponseQuoteWithHistory : ResponseBase
    {
        //we put the CRUD operation result here.
        //it can be of any type. 
        //a single row, a collection of rows...whatever you need
        public QuoteWithHistoryItems QuoteWithHistoryItems { set; get; }
        public CRUDAPIResponseQuoteWithHistory()
        {
            ListOfResponses = new List<string>();
            var firstmessage = "CRUD Response Below";
            ListOfResponses.Add(firstmessage);
            //be default we assume things went well and only update when there is an error. 
            OperationSuccessful = true;
            DetailsAboutOperation = "Cowabanga Dude";
        }
    }
}
