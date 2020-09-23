using RandomStuffGeneratorPrivate.APIJSONClasses;
using RandomStuffGeneratorPrivate.DatabaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomStuffGeneratorPrivate.HelperStuff
{
    public class QuoteHelpers
    {
        public QuoteCube ReturnASingleQuoteInMemory()
        {
            var tempQuoteCube = new QuoteCube();

            tempQuoteCube.QuoteContent = "Exciting Times Lie Ahead Of Us";
            tempQuoteCube.QuoteTitle = "Exciting";

            return tempQuoteCube;
        }

        public QuoteCube ReturnASingleQuote()
        {
            var tempQuoteCube = new QuoteCube();

            tempQuoteCube.QuoteContent = "Exciting Times Lie Ahead Of Us";
            tempQuoteCube.QuoteTitle = "Exciting";

            return tempQuoteCube;
        }

        //I am sure we will further modularize this. 
        internal async Task<QuoteCube> ReturnASingleQuoteAsync(BloggingContext context)
        {
            // Instantiate random number generator using system-supplied value as seed.
            var rand = new Random();
            var tempQuoteCube = new QuoteCube();

            //first get all the quotes and the count
            var tempFullList = context.Quotes.ToList();
            var totalQuoteCount = tempFullList.Count;
            var tempFirstID = tempFullList.First().QuoteId;
            var tempLastID = tempFullList.Last().QuoteId;

           if(totalQuoteCount == 0)
            {
                tempQuoteCube.QuoteContent = "Exciting Times Lie Ahead Of Us";
                tempQuoteCube.QuoteTitle = "Database Empty";
            }
           else
            {
                var tempRandomQuoteToReturn = rand.Next(tempFirstID,tempLastID);
                var quote = await context.Quotes.FindAsync(tempRandomQuoteToReturn);

                if (quote == null)
                {
                    tempQuoteCube.QuoteContent = "Exciting Times Lie Ahead Of Us";
                    tempQuoteCube.QuoteTitle = "Quote could not be Obtained";
                }
                else
                {
                    tempQuoteCube.QuoteContent = quote.QuoteContent;
                    tempQuoteCube.QuoteTitle = quote.QuoteTitle;
                }
            }

            return tempQuoteCube;
        }

        //As of now, I am not adding an auth system to this API server
        //if you are looking for a auth based token issuing OAuth enabled API server
        //look at this
        //https://github.com/Jay-study-nildana/ProjectWTPublicRepos/tree/master/apiservers/dotnetcoreapiserverwithauth0
        //and this 
        //https://github.com/Jay-study-nildana/APIServerDotNetCoreWithAuth0
        //So, I am adding a simple secret phrase hardcoded to this project
        //without this phrase in the POST for adding quotes
        //noone can add a quote. obviously, this is easily hackable but this is done on purpose
        public string ReturnTheSecretForAdding()
        {
            var tempSecretPhrase = "addyoursecretphrasehere";

            return tempSecretPhrase;
        }
    }
}
