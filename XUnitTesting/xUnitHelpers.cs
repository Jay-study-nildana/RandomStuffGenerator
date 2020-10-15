using RandomStuffGeneratorPrivate.DatabaseClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace XUnitTesting
{
    //some reusable components for testing.
    class xUnitHelpers
    {
        //TODO - this will be a more unchanging list
        //we could also do a randomly generated list.
        //we could have a list that is raised from another source, perhaps a unit test only interface.
        //keep it simple for now.
        public List<Quote> SampleCollectionOfQuotes()
        {
            var tempList = new List<Quote>();

            var tempQuote1 = new Quote();
            tempQuote1.QuoteId = 1;
            tempQuote1.QuoteContent = "I'm in a glass case of emotion";
            tempQuote1.QuoteTitle = "Ron";

            var tempQuote2 = new Quote();
            tempQuote2.QuoteId = 2;
            tempQuote2.QuoteContent = "Everyone just relax, all right? Believe me, if there's one thing Ron Burgundy knows, it's women";
            tempQuote2.QuoteTitle = "Ron";

            var tempQuote3 = new Quote();
            tempQuote3.QuoteId = 3;
            tempQuote3.QuoteContent = "Good evening, San Diego. I'm Veronica Corningstone. Tits McGee is on vacation";
            tempQuote3.QuoteTitle = "Veronica";

            var tempQuote4 = new Quote();
            tempQuote4.QuoteId = 4;
            tempQuote4.QuoteContent = "I have many leather-bound books and my apartment smells of rich mahogany";
            tempQuote4.QuoteTitle = "Ron";

            var tempQuote5 = new Quote();
            tempQuote5.QuoteId = 5;
            tempQuote5.QuoteContent = "By the beard of Zeus!";
            tempQuote5.QuoteTitle = "Ron";

            tempList.Add(tempQuote1);
            tempList.Add(tempQuote2);
            tempList.Add(tempQuote3);
            tempList.Add(tempQuote4);
            tempList.Add(tempQuote5);

            //the 5 items above is important for some testing. so, if you want to modify this list, DONT.

            return tempList;
        }
    }
}
