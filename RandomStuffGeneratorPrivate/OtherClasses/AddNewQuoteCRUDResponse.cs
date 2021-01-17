using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomStuffGeneratorPrivate.OtherClasses
{
    public class AddNewQuoteCRUDResponse : CRUDResponse
    {
        public string QuoteIdentifierString { get; set; }

        public AddNewQuoteCRUDResponse()
        {
            ListOfResponses = new List<string>();
            var firstmessage = "AddNewQuoteCRUDResponse Response Below";
            ListOfResponses.Add(firstmessage);
            //be default we assume things went well and only update when there is an error. 
            OperationSuccessful = true;
            DetailsAboutOperation = "Cowabanga Dude";
        }
    }
}
