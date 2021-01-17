using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RandomStuffGeneratorPrivate.BaseClasses;

namespace RandomStuffGeneratorPrivate.APIJSONClasses
{
    //counterpart of QuoteCube but for collections
    public class QuoteCubeCollection : QuoteCollectionBase
    {
        //I also want a flag that indicates if the operation was successfull or not.
        public bool OperationSuccessful { get; set; }

        //I should be able to include notes, especially if operation failed.
        public string DetailsAboutOperation { get; set; }

        //additional note. each quote cube also has its own success and failure indicator
        //that works on a granular quote level
        //this, above, indicators work on a collection level.
        public QuoteCubeCollection()
        {
            //be default we assume things went well and only update when there is an error. 
            OperationSuccessful = true;
            DetailsAboutOperation = "All Good Captain";
        }

        public GeneralAPIResponse generalAPIResponse { set; get; }
    }
}
