using RandomStuffGeneratorPrivate.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomStuffGeneratorPrivate.APIJSONClasses
{
    //I wanted to use this generic - see Object below - returning class
    //but looks like objects dont get serialized - which makes sense as serialization needs type information.
    //so keeping this for testing purpose.
    public class CRUDAPIResponse : ResponseBase
    {
        //we put the CRUD operation result here.
        //it can be of any type. 
        //a single row, a collection of rows...whatever you need
        public Object CRUDOperationResult;
        public CRUDAPIResponse()
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
