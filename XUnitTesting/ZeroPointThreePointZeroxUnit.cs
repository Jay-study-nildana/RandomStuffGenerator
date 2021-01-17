using RandomStuffGeneratorPrivate.APIJSONClasses;
using RandomStuffGeneratorPrivate.HelperStuff;
using RandomStuffGeneratorPrivate.Interfaces;
using RandomStuffGeneratorPrivate.OtherClasses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace XUnitTesting
{

    //TODO - we need to attach a database context with the same schema as the main project.
    //as of now, the project is tested against that memory database
    //both the database based things and memory based things come from the same interface. 
    //so, in memory based testing is good enough.
    public class ZeroPointThreePointZeroxUnit
    {

        //Test for IGenerateRandomQuote
        [Fact]
        public void TestGenerateRandomQuoteSimple()
        {
            IGenerateRandomQuote generateRandomQuote = new GenerateRandomQuoteSimple();
            bool actual = false;

            var quoteRandom1 = generateRandomQuote.GenerateQuoteCubeRandom();
            var quoteRandom2 = generateRandomQuote.GenerateQuoteCubeRandom();

            //either the author or the quote should be different to make this quote unique.
            if (quoteRandom1.QuoteAuthor.Equals(quoteRandom2.QuoteAuthor) == false || quoteRandom1.QuoteContent.Equals(quoteRandom2.QuoteContent) == false )
            {
                actual = true;
            }
            var expected = true;

            Assert.Equal(expected, actual);
        }

        //Test for QuoteIdentifier with name 
        [Fact]
        public void TestQuoteIdentifierWithSomeString()
        {
            IIdentifier identifier = new QuoteIdentifier();
            bool actual = false;

            var quoteIdentifierString1 = identifier.GenerateIdentifierString("dash");
            var quoteIdentifierString2 = identifier.GenerateIdentifierString("dash");

            if (quoteIdentifierString1.Equals(quoteIdentifierString2) == false)
            {
                actual = true;
            }
            var expected = true;

            Assert.Equal(expected, actual);
        }

        //Test for QuoteIdentifier generator.
        [Fact]
        public void TestQuoteIdentifier()
        {
            IIdentifier identifier = new QuoteIdentifier();
            bool actual = false;

            var quoteIdentifierString1 = identifier.GenerateIdentifierString();
            var quoteIdentifierString2 = identifier.GenerateIdentifierString();

            if(quoteIdentifierString1.Equals(quoteIdentifierString2) == false)
            {
                actual = true;
            }
            var expected = true;

            Assert.Equal(expected, actual);
        }

        //Test for testing a single random quote return
        [Fact]
        public async Task TestIReturnSingleQuoteRandomAsync()
        {
            IReturnSingleQuote returnSingleQuote = new ReturnSingleQuote();
            OptionsSingleQuote optionsSingleQuote = new OptionsSingleQuote();

            //settign options
            //source is memory.
            optionsSingleQuote.enumSourceOfData = RandomStuffGeneratorPrivate.Enums.EnumSourceOfData.DataBaseInMemory;
            //quote is random
            optionsSingleQuote.RandomQuote = true;

            QuoteCube quoteCube = await returnSingleQuote.ReturnASingleQuote(optionsSingleQuote);

            var actual = quoteCube.OperationSuccessful;
            var expected = true;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public async Task TestIReturnSingleQuoteRandomKnownIdentifierAsync()
        {
            IReturnSingleQuote returnSingleQuote = new ReturnSingleQuote();
            OptionsSingleQuote optionsSingleQuote = new OptionsSingleQuote();

            //settign options
            //source is memory.
            optionsSingleQuote.enumSourceOfData = RandomStuffGeneratorPrivate.Enums.EnumSourceOfData.DataBaseInMemory;
            //quote is specific
            optionsSingleQuote.RandomQuote = false;
            //provide identifier
            optionsSingleQuote.QuoteIdentifierCompadre = "1";

            QuoteCube quoteCube = await returnSingleQuote.ReturnASingleQuote(optionsSingleQuote);

            var actual = quoteCube.OperationSuccessful;
            var expected = true;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public async Task TestIReturnSingleQuoteRandomIdentifierNotPresentAsync()
        {
            IReturnSingleQuote returnSingleQuote = new ReturnSingleQuote();
            OptionsSingleQuote optionsSingleQuote = new OptionsSingleQuote();

            //settign options
            //source is memory.
            optionsSingleQuote.enumSourceOfData = RandomStuffGeneratorPrivate.Enums.EnumSourceOfData.DataBaseInMemory;
            //quote is specific
            optionsSingleQuote.RandomQuote = false;
            //provide identifier
            optionsSingleQuote.QuoteIdentifierCompadre = "10";

            QuoteCube quoteCube = await returnSingleQuote.ReturnASingleQuote(optionsSingleQuote);

            var actual = quoteCube.OperationSuccessful;
            var expected = false;

            Assert.Equal(expected, actual);
        }
    }
}
