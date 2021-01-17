using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomStuffGeneratorPrivate.BaseClasses
{
    //This is a response item that is part of each and every response. 

    public abstract class ResponseBase
    {
        public List<string> ListOfResponses { set; get; }
        public DateTime dateTimeOfResponse { set; get; }
        public bool OperationSuccessful { get; set; }

        //I should be able to include notes, especially if operation failed.
        public string DetailsAboutOperation { get; set; }
    }
}
