using RandomStuffGeneratorPrivate.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//use this as a generic response to send to API calls
//we can fill this up with errors, error codes, success codes and anything
//an endless list of messages

namespace RandomStuffGeneratorPrivate.APIJSONClasses
{
    public class GeneralAPIResponse : ResponseBase
    {
        //I want at least one message to be in the response.
        public GeneralAPIResponse()
        {
            ListOfResponses = new List<string>();
            var firstmessage = "API Response Below";
            ListOfResponses.Add(firstmessage);
            //be default we assume things went well and only update when there is an error. 
            OperationSuccessful = true;
            DetailsAboutOperation = "Clean as a whistle";
        }
    }
}
