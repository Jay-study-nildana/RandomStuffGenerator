using RandomStuffGeneratorPrivate.APIJSONClasses;
using RandomStuffGeneratorPrivate.Interfaces;
using System;
using System.Threading.Tasks;
using Xunit;
using System.Collections.Generic;
using System.Linq;
using RandomStuffGeneratorPrivate.DatabaseClasses;

namespace XUnitTesting
{
    public class ZeroPointTwoPointZeroxUnit
    {
        [Fact]
        public void TestISecretForAdding()
        {
            ISecretForAdding secretForAdding = new SecretForAdding();

            var actual = secretForAdding.ReturnTheSecretForAdding();
            var expected = "testsecretphrase";

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestIGetQuoteDetail()
        {
            IGetQuoteDetail getQuoteDetail = new GetQuoteDetail();
            var quoteid = 2;
            Quote quote = (Quote) getQuoteDetail.GetQuote(quoteid);

            var actual = quote.QuoteContent;
            var expected = "Everyone just relax, all right? Believe me, if there's one thing Ron Burgundy knows, it's women";

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestIGetCollectionOfQuotes()
        {
            IGetCollectionOfQuotes collectionOfQuotes = new xUnitQuoteCollection();
            //here 2 is irrelevant. the context that the function is expecting, 
            //is for future purposes.
            List<object> list = collectionOfQuotes.QuoteCollection(2);
            //convert list back to type I want to consume.
            IEnumerable<Quote> listObject1 = list.Cast<Quote>();
            var actual = list.Count;
            var expected = 5; //as of now, I have 5 items in the sample collection.

            Assert.Equal(expected, actual);
        }
    }

    internal class xUnitQuoteCollection : IGetCollectionOfQuotes
    {
        public List<object> QuoteCollection(object context)
        {
            //I dont have any advanced Quote filtering attributes yet
            //so, ignoring the context. as of now, it is a placeholder.
            var tempxUnitHelpers = new xUnitHelpers();
            var tempList = tempxUnitHelpers.SampleCollectionOfQuotes();

            //convert list to generic objects.
            IEnumerable<Object> listObject1 = tempList.Cast<Object>();
            List<object> lists = listObject1.ToList();
            return lists;
        }
    }

    internal class GetQuoteDetail : IGetQuoteDetail
    {
        public object GetQuote(object QuoteIdentifier)
        {
            var tempxUnitHelpers = new xUnitHelpers();
            var tempList = tempxUnitHelpers.SampleCollectionOfQuotes();
            var quoteID = (int)QuoteIdentifier;
            var foundQuote = tempList.Where(quote => quote.QuoteId == quoteID).FirstOrDefault();
            Object returnObject = (Object)foundQuote;
            return returnObject;
        }
    }

    internal class SecretForAdding : ISecretForAdding
    {
        public object ReturnTheSecretForAdding()
        {
            var tempSecretPhrase = "testsecretphrase";
            return tempSecretPhrase;
        }
    }
}
