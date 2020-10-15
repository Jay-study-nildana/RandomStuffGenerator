using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//use this as a generic response to send to API calls
//we can fill this up with errors, error codes, success codes and anything
//an endless list of messages

namespace RandomStuffGeneratorPrivate.APIJSONClasses
{
    public class GeneralAPIResponse
    {
        public List<string> ListOfResponses { set; get; }

        //I want at least one message to be in the response.
        public GeneralAPIResponse()
        {
            ListOfResponses = new List<string>();
            var firstmessage = "API Response Below";
            ListOfResponses.Add(firstmessage);
        }
    }

    public class GeneralResponseModel
    {
        public List<string> ListOfResponses { set; get; }

        //I want at least one message to be in the response.
        public GeneralResponseModel()
        {
            ListOfResponses = new List<string>();
            var firstmessage = "Project WT Responses below";
            ListOfResponses.Add(firstmessage);
        }
    }
}
