using RandomStuffGeneratorPrivate.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomStuffGeneratorPrivate.OtherClasses
{
    //used as a response for every CRUD operation.
    public class CRUDResponse : ResponseBase
    {
        //we put the CRUD operation result here.
        //it can be of any type. 
        //a single row, a collection of rows...whatever you need
        public Object CRUDOperationResult;
        public CRUDResponse()
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
