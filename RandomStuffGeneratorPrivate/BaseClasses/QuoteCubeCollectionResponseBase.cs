﻿using RandomStuffGeneratorPrivate.APIJSONClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomStuffGeneratorPrivate.BaseClasses
{
    public abstract class QuoteCubeCollectionResponseBase : ResponseBase
    {
        //I need a list of Quotes
        //count of quotes
        //date this response was called

        public List<QuoteCube> quoteCubes { set; get; }
        //here, I know, its not hard to get the count of items from the collection
        //but, i think, it will make it one less code for the developer when he is building the app
        public int totalQuotesReturned { set; get; }
    }
}
