using RandomStuffGeneratorPrivate.APIJSONClasses;
using RandomStuffGeneratorPrivate.DatabaseClasses;
using RandomStuffGeneratorPrivate.Interfaces;
using RandomStuffGeneratorPrivate.OtherClasses;
using RandomStuffGeneratorPrivate.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomStuffGeneratorPrivate.HelperStuff
{

    #region old quote helper stuff.
    public class QuoteHelpers
    {
    
        //This used to have a lot of things
        //they were all moved to interfaces as class as part of the Version 0.3.0 update

    }


    #endregion

    #region revamped helper classes and methods

    //as part of the revision of Version 0.3.0, I strated replacing all classes that were standing on their own
    //with classes that are dependent on an interface. 
    //When this transition is completed, I expected the entire project to be SOLID compliant, one of which is interface usage.

    //public QuoteCube ReturnASingleQuoteInMemory()
    //{
    //    var tempQuoteCube = new QuoteCube();

    //    tempQuoteCube.QuoteContent = "Exciting Times Lie Ahead Of Us";
    //    tempQuoteCube.QuoteTitle = "Exciting";

    //    return tempQuoteCube;
    //}

    public class ReturnSingleQuote : IReturnSingleQuote
    {
        //this one returns a single quote.
        //the type of quote is indicate in the options parameters
        //public async Task DoOperationAsync()
        public async Task<QuoteCube> ReturnASingleQuote(OptionsSingleQuote optionsSingleQuote)
        {
            QuoteCube quoteCube = new QuoteCube();

            if(optionsSingleQuote.enumSourceOfData == Enums.EnumSourceOfData.DataBaseInMemory)
            {
                //get quote from memory.
                quoteCube = await ReturnQuoteFromMemory(optionsSingleQuote);
            }
            else if (optionsSingleQuote.enumSourceOfData == Enums.EnumSourceOfData.DataBaseInContext)
            {
                if(optionsSingleQuote.bloggingContext == null)
                {
                    quoteCube.DetailsAboutOperation = "db context is null";
                    quoteCube.OperationSuccessful = false;

                    return quoteCube;
                }
                //get quote from database context
                quoteCube = await ReturnQuoteFromDatabase(optionsSingleQuote);
            }
            else
            {
                quoteCube.DetailsAboutOperation = "optionsSingleQuote contains unknown data source.";
                quoteCube.OperationSuccessful = false;
            }

            return quoteCube;

        }

        private async Task<QuoteCube> ReturnQuoteFromDatabase(OptionsSingleQuote optionsSingleQuote)
        {
            QuoteCube quoteCube = new QuoteCube();
            OptionsCollectionOfQuotes optionsCollectionOfQuotes = new OptionsCollectionOfQuotes();
            IQuoteCubeCollection quoteCubeCollection = new ReturnQuoteCubeCollection();

            //now, look at options, if it is random, pick any one.
            //TODO - both the if and else have some common statements.
            //perhaps we can merge and keep only the unique things.
            if (optionsSingleQuote.RandomQuote == true)
            {
                //set up collection options.

                optionsCollectionOfQuotes.enumSourceOfData = optionsSingleQuote.enumSourceOfData;
                optionsCollectionOfQuotes.bloggingContext = optionsSingleQuote.bloggingContext;

                var TempCubeCollection = await quoteCubeCollection.GetQuoteCubeCollection(optionsCollectionOfQuotes);

                if (TempCubeCollection.OperationSuccessful == false)
                {
                    quoteCube.DetailsAboutOperation = "There was a problem getting the source collection";
                    quoteCube.OperationSuccessful = false;
                }
                else
                {
                    //our collection is good.
                    try
                    {
                        //lets pick a random quote.
                        // Instantiate random number generator using system-supplied value as seed.
                        var rand = new Random();
                        var quoteRandomNumber = rand.Next(TempCubeCollection.numberOfQuotes);
                        quoteCube = TempCubeCollection.quoteCubes[quoteRandomNumber];
                    }
                    catch (Exception e)
                    {
                        quoteCube.DetailsAboutOperation = "Exception Error " + e.ToString();
                        quoteCube.OperationSuccessful = false;
                    }

                }
            }
            //if it is specific, see if it is there in the list.
            else
            {
                if (String.IsNullOrEmpty(optionsSingleQuote.QuoteIdentifierCompadre) == true)
                {
                    quoteCube.DetailsAboutOperation = "QuoteIdentifierCompadre is missing or empty";
                    quoteCube.OperationSuccessful = false;
                }
                else
                {
                    //set up collection options.

                    optionsCollectionOfQuotes.enumSourceOfData = optionsSingleQuote.enumSourceOfData;
                    optionsCollectionOfQuotes.bloggingContext = optionsSingleQuote.bloggingContext;

                    var TempCubeCollection = await quoteCubeCollection.GetQuoteCubeCollection(optionsCollectionOfQuotes);

                    if (TempCubeCollection.OperationSuccessful == false)
                    {
                        quoteCube.DetailsAboutOperation = "There was a problem getting the source collection";
                        quoteCube.OperationSuccessful = false;
                    }
                    else
                    {
                        //our collection is good.
                        try
                        {
                            //lets pick a specific quote
                            var tempquoteCube = TempCubeCollection.quoteCubes.Select(x => x).Where(x => x.QuoteIdentifierCompadre == optionsSingleQuote.QuoteIdentifierCompadre).First();
                            if (tempquoteCube == null)
                            {
                                quoteCube.DetailsAboutOperation = "No quote with " + optionsSingleQuote.QuoteIdentifierCompadre + "exists in our system";
                                quoteCube.OperationSuccessful = false;
                            }
                            else
                            {
                                quoteCube = tempquoteCube;
                            }
                        }
                        catch (Exception e)
                        {
                            quoteCube.DetailsAboutOperation = "Exception Error " + e.ToString();
                            quoteCube.OperationSuccessful = false;
                        }

                    }
                }
            }

            return quoteCube;
        }

        private async Task<QuoteCube> ReturnQuoteFromMemory(OptionsSingleQuote optionsSingleQuote)
        {
            QuoteCube quoteCube = new QuoteCube();
            OptionsCollectionOfQuotes optionsCollectionOfQuotes = new OptionsCollectionOfQuotes();
            IQuoteCubeCollection quoteCubeCollection = new ReturnQuoteCubeCollection();

            //now, look at options, if it is random, pick any one.
            //TODO - both the if and else have some common statements.
            //perhaps we can merge and keep only the unique things.
            if(optionsSingleQuote.RandomQuote == true)
            {
                //set up collection options.

                optionsCollectionOfQuotes.enumSourceOfData = optionsSingleQuote.enumSourceOfData;

                var TempCubeCollection = await quoteCubeCollection.GetQuoteCubeCollection(optionsCollectionOfQuotes);

                if(TempCubeCollection.OperationSuccessful == false)
                {
                    quoteCube.DetailsAboutOperation = "There was a problem getting the source collection";
                    quoteCube.OperationSuccessful = false;
                }
                else
                {
                    //our collection is good.
                    try
                    {
                        //lets pick a random quote.
                        // Instantiate random number generator using system-supplied value as seed.
                        var rand = new Random();
                        var quoteRandomNumber = rand.Next(TempCubeCollection.numberOfQuotes);
                        quoteCube = TempCubeCollection.quoteCubes[quoteRandomNumber];
                    }
                    catch(Exception e)
                    {
                        quoteCube.DetailsAboutOperation = "Exception Error " + e.ToString();
                        quoteCube.OperationSuccessful = false;
                    }

                }
            }
            //if it is specific, see if it is there in the list.
            else
            {
                if(String.IsNullOrEmpty(optionsSingleQuote.QuoteIdentifierCompadre) == true)
                {
                    quoteCube.DetailsAboutOperation = "QuoteIdentifierCompadre is missing or empty" ;
                    quoteCube.OperationSuccessful = false;
                }
                else
                {
                    //set up collection options.

                    optionsCollectionOfQuotes.enumSourceOfData = optionsSingleQuote.enumSourceOfData;

                    var TempCubeCollection = await quoteCubeCollection.GetQuoteCubeCollection(optionsCollectionOfQuotes);

                    if (TempCubeCollection.OperationSuccessful == false)
                    {
                        quoteCube.DetailsAboutOperation = "There was a problem getting the source collection";
                        quoteCube.OperationSuccessful = false;
                    }
                    else
                    {
                        //our collection is good.
                        try
                        {
                            //lets pick a specific quote
                            var tempquoteCube = TempCubeCollection.quoteCubes.Select(x => x).Where(x => x.QuoteIdentifierCompadre == optionsSingleQuote.QuoteIdentifierCompadre).First();
                            if(tempquoteCube == null)
                            {
                                quoteCube.DetailsAboutOperation = "No quote with " + optionsSingleQuote.QuoteIdentifierCompadre + "exists in our system";
                                quoteCube.OperationSuccessful = false;
                            }
                            else
                            {
                                quoteCube = tempquoteCube;
                            }
                        }
                        catch (Exception e)
                        {
                            quoteCube.DetailsAboutOperation = "Exception Error " + e.ToString();
                            quoteCube.OperationSuccessful = false;
                        }

                    }
                }
            }

            return quoteCube;
        }
    }

    public class ReturnQuoteCubeCollection : IQuoteCubeCollection
    {
        public async Task<QuoteCubeCollection> GetQuoteCubeCollection(OptionsCollectionOfQuotes optionsCollectionOfQuotes)
        {
            QuoteCubeCollection quoteCubeCollection = new QuoteCubeCollection();

            if (optionsCollectionOfQuotes.enumSourceOfData == Enums.EnumSourceOfData.DataBaseInMemory)
            {
                quoteCubeCollection = await GetCollectionOfQuotesFromMemory();
            }
            else if(optionsCollectionOfQuotes.enumSourceOfData == Enums.EnumSourceOfData.DataBaseInContext)
            {
                quoteCubeCollection = await GetCollectionOfQuotesFromContext(optionsCollectionOfQuotes);
            }
            else
            {
                quoteCubeCollection.DetailsAboutOperation = "optionsSingleQuote contains unknown data source.";
                quoteCubeCollection.OperationSuccessful = false;
            }

            return quoteCubeCollection;
        }

        private async Task<QuoteCubeCollection> GetCollectionOfQuotesFromContext(OptionsCollectionOfQuotes optionsCollectionOfQuotes)
        {
            QuoteCubeCollection quoteCubeCollection = new QuoteCubeCollection
            {
                quoteCubes = await SimpleCollectionOfQuoteCubesFromContext(optionsCollectionOfQuotes)
            };
            quoteCubeCollection.numberOfQuotes = quoteCubeCollection.quoteCubes.Count;

            return quoteCubeCollection;
        }

        private async Task<List<QuoteCube>> SimpleCollectionOfQuoteCubesFromContext(OptionsCollectionOfQuotes optionsCollectionOfQuotes)
        {
            //at this point, I am assuming that the context is already checked for
            //dude, we cannot just send the entire 1000s of quotes.
            var limitOfQuotes = 100;
            var tempListOriginal = optionsCollectionOfQuotes.bloggingContext.QuoteModels.ToList().Take(limitOfQuotes);

            var tempList = new List<QuoteCube>();

            //the database tables use the schema tables
            //my API uses JSON classes that are separate from the schema classes
            //this is the conversion happening
            //TODO - can we move this to a interface + class that does the conversion? 
            foreach(var x in tempListOriginal)
            {
                var tempQuoteCube = new QuoteCube
                {
                    QuoteContent = x.QuoteContent,
                    QuoteIdentifierCompadre = x.QuoteId.ToString(),
                    QuoteAuthor = x.QuoteAuthor,
                    QuoteIdentifierString = x.QuoteIdentifierString
                };

                var generalAPIResponse = new GeneralAPIResponse
                {
                    dateTimeOfResponse = DateTime.Now
                };
                tempQuoteCube.generalAPIResponse = generalAPIResponse;

                tempList.Add(tempQuoteCube);
            }

            //here, adding this await because, I am using an async Task based interface.
            //this being a memory based implementation, it does not actually have to wait for anything.
            //so, just wrapping this simple result in a task to avoid getting 'lack of async' error.
            return await Task.FromResult(tempList);
        }

        private async Task<List<QuoteCube>> SimpleCollectionOfQuoteCubes()
        {
            var tempList = new List<QuoteCube>();

            var tempQuote1 = new QuoteCube
            {
                QuoteIdentifierString = "1",
                QuoteContent = "I'm in a glass case of emotion",
                QuoteAuthor = "Ron"
            };

            var tempQuote2 = new QuoteCube
            {
                QuoteIdentifierString = "2",
                QuoteContent = "Everyone just relax, all right? Believe me, if there's one thing Ron Burgundy knows, it's women",
                QuoteAuthor = "Ron"
            };

            var tempQuote3 = new QuoteCube
            {
                QuoteIdentifierString = "3",
                QuoteContent = "Good evening, San Diego. I'm Veronica Corningstone. Tits McGee is on vacation",
                QuoteAuthor = "Veronica"
            };

            var tempQuote4 = new QuoteCube
            {
                QuoteIdentifierString = "4",
                QuoteContent = "I have many leather-bound books and my apartment smells of rich mahogany",
                QuoteAuthor = "Ron"
            };

            var tempQuote5 = new QuoteCube
            {
                QuoteIdentifierString = "5",
                QuoteContent = "By the beard of Zeus!",
                QuoteAuthor = "Ron"
            };

            tempList.Add(tempQuote1);
            tempList.Add(tempQuote2);
            tempList.Add(tempQuote3);
            tempList.Add(tempQuote4);
            tempList.Add(tempQuote5);

            //the 5 items above is important for some testing. so, if you want to modify this list, DONT.

            //here, adding this await because, I am using an async Task based interface.
            //this being a memory based implementation, it does not actually have to wait for anything.
            //so, just wrapping this simple result in a task to avoid getting 'lack of async' error.
            return await Task.FromResult(tempList);
        }

        private async Task<QuoteCubeCollection> GetCollectionOfQuotesFromMemory()
        {
            QuoteCubeCollection quoteCubeCollection = new QuoteCubeCollection
            {
                quoteCubes = await SimpleCollectionOfQuoteCubes()
            };
            quoteCubeCollection.numberOfQuotes = quoteCubeCollection.quoteCubes.Count;

            return quoteCubeCollection;
        }
    }

    #endregion
}
