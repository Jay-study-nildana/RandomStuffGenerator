using RandomStuffGeneratorPrivate.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomStuffGeneratorPrivate.APIJSONClasses
{
    //TODO - we have some naming violations becuase of the way I put variable names
    //may be they will need db changes, migrations and so on. 
    //lets look into it. 

    public class QuoteCube : QuoteBase
    {
        //the JSON version of Quote ID.
        public string QuoteIdentifierCompadre { get; set; }
        //I also want a flag that indicates if the operation was successfull or not.
        public bool OperationSuccessful { get; set; }

        //I should be able to include notes, especially if operation failed.
        public string DetailsAboutOperation { get; set; }

        public QuoteCube()
        {
            //be default we assume things went well and only update when there is an error. 
            OperationSuccessful = true;
            DetailsAboutOperation = "All Good Captain";
        }

        public GeneralAPIResponse generalAPIResponse { set; get; }
    }
}
