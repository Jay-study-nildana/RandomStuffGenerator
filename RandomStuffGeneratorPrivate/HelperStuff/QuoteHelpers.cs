using RandomStuffGeneratorPrivate.APIJSONClasses;
using RandomStuffGeneratorPrivate.DatabaseClasses;
using RandomStuffGeneratorPrivate.Interfaces;
using RandomStuffGeneratorPrivate.POCO;
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

        internal QuoteCubeResponse GetquoteCubeResponse(GetQuoteComponent getQuoteComponent)
        {
            var tempQuoteCubeResponse = new QuoteCubeResponse();

            //the time of run
            tempQuoteCubeResponse.dateTimeOfRun = GetCurrentTime();

            //the actual quote.
            tempQuoteCubeResponse.quoteCube = GetSpecificQuoteCube(getQuoteComponent);

            return tempQuoteCubeResponse;
        }

        private QuoteCube GetSpecificQuoteCube(GetQuoteComponent getQuoteComponent)
        {
            IGetQuoteDetail getQuoteDetail = new GetQuoteDetailWithDBContext();

            Quote quote = (Quote)getQuoteDetail.GetQuote(getQuoteComponent);

            QuoteCube quoteCube = new QuoteCube
            {
                QuoteContent = quote.QuoteContent,
                QuoteIdentifierCompadre = quote.QuoteId.ToString(),
                QuoteTitle = quote.QuoteTitle
            };

            return quoteCube;
        }

        internal QuoteCubeCollectionResponse GetQuoteCubeCollectionResponse(GetQuoteCollectionComponent quoteCollectionComponent)
        {
            var tempQuoteCubeCollectionResponse = new QuoteCubeCollectionResponse();

            //the time of run
            tempQuoteCubeCollectionResponse.dateTimeOfRun = GetCurrentTime();

            //the actual quotes to return
            tempQuoteCubeCollectionResponse.quoteCubes = GetQuoteCubes(quoteCollectionComponent);

            //now the count.
            tempQuoteCubeCollectionResponse.totalQuotesReturned = tempQuoteCubeCollectionResponse.quoteCubes.Count;


            return tempQuoteCubeCollectionResponse;
        }

        private List<QuoteCube> GetQuoteCubes(GetQuoteCollectionComponent quoteCollectionComponent)
        {
            IGetCollectionOfQuotes getCollectionOfQuotes = new GetCollectionOfQuotesWithDBContext();

            List<object> list = getCollectionOfQuotes.QuoteCollection(quoteCollectionComponent);

            //convert generic list to preferred format
            //IEnumerable<Object> listObject1 = dbResponse.Cast<Object>();
            IEnumerable<QuoteCube> quoteCubes = list.Cast<QuoteCube>();

            return quoteCubes.ToList();
        }

        //TODO - is this another candidate to be wrapped in an interface? 
        private string GetCurrentTime()
        {
            //I like the standard en-US format.
            //change formats here - https://docs.microsoft.com/en-us/dotnet/api/system.datetime.tostring?view=netcore-3.1#System_DateTime_ToString_System_String_
            var timestring = DateTime.UtcNow.ToString("F");
            return timestring;
        }

        //public string ReturnTheSecretForAdding()
        //{
        //    var tempSecretPhrase = "its69man";

        //    return tempSecretPhrase;
        //}

        internal List<ReturnedQuote> GetTheQuotesBeastMan(BloggingContext context)
        {
            IGetCollectionOfQuotes getTheQuotesBeastMan = new GetCollectionOfQuotesWithDBContext();
            List<object> lists = getTheQuotesBeastMan.QuoteCollection(context);
            List<ReturnedQuote> returningCollection = (List<ReturnedQuote>)lists.Cast<ReturnedQuote>();

            return returningCollection;
        }

        // a simple random quote collection.
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

    internal class GetQuoteDetailWithDBContext : IGetQuoteDetail
    {
        public object GetQuote(object context)
        {
            GetQuoteComponent getQuoteComponent = (GetQuoteComponent)context;

            BloggingContext bloggingContext = getQuoteComponent.bloggingContext;

            try
            {
                //now, pick the specific quote.
                var foundQuote = bloggingContext.Quotes.Where(quote => quote.QuoteId == Convert.ToInt32(getQuoteComponent.QuoteIdentifier)).FirstOrDefault();
                Object returnObject = (Object)foundQuote;
                return returnObject;
            }
            catch(Exception e)
            {
                //now, pick the specific quote.
                var foundQuote = bloggingContext.Quotes.FirstOrDefault();
                foundQuote.QuoteContent = "Something went wrong. Quote Not Found";
                foundQuote.QuoteId = 0;
                foundQuote.QuoteTitle = "Zilch";
                Object returnObject = (Object)foundQuote;
                return returnObject;
            }
        }
    }

    public class GetCollectionOfQuotesWithDBContext : IGetCollectionOfQuotes
    {
        //TODO - i want to stress test this part. what if I have like a million quotes?
        //build a helper that will generate and add a million quotes to the database
        //see if this still works as expected.
        //public async Task<List<ReturnedQuote>> ReturnTheQuotesAll(BloggingContext context)
        //{
        //    //get all quotes
        //    //convert them to my return type
        //    //return the returned enumerable as a list.
        //    var dbResponse = from quote in context.Quotes.ToList()
        //                     //where quote.QuoteId == 1
        //                     select new ReturnedQuote
        //                     {
        //                         QuoteContent = quote.QuoteContent,
        //                         QuoteId = quote.QuoteId,
        //                         QuoteTitle = quote.QuoteTitle
        //                     }
        //                     ;
        //    return dbResponse.ToList();
        //}

        public List<object> QuoteCollection(object context)
        {
            GetQuoteCollectionComponent quoteCollectionComponent = (GetQuoteCollectionComponent)context;

            //TODO - add a null check for db context and return a default sample list, already available in this helper.

            BloggingContext bloggingContext = quoteCollectionComponent.bloggingContext;
            //get all quotes
            //convert them to my return type
            //return the returned enumerable as a list.
            //TODO - this is query syntax. change this to method syntax - look at ZeroPointTwoPointZeroxUnit
            //TODO - the default limit - return only QuoteCount number of quotes is not implemented.
            var dbResponse = from quote in bloggingContext.Quotes.ToList()
                             select new QuoteCube
                             {
                                 QuoteContent = quote.QuoteContent,
                                 QuoteIdentifierCompadre = quote.QuoteId.ToString(),
                                 QuoteTitle = quote.QuoteTitle
                             }
                             ;
            //convert list to generic objects.
            IEnumerable<Object> listObject1 = dbResponse.Cast<Object>();
            List<object> lists = listObject1.ToList();
            return lists;
        }
    }

    public class SecretForAdding : ISecretForAdding
    {
        public object ReturnTheSecretForAdding()
        {
            var tempSecretPhrase = "its69man";
            return tempSecretPhrase;
        }
    }
}
