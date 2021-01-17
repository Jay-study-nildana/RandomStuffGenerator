using RandomStuffGeneratorPrivate.Interfaces;
using RandomStuffGeneratorPrivate.OtherClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomStuffGeneratorPrivate.HelperStuff
{
    //I am sure we can use Faker or similar library for better effect
    //But, I dont want to introduce a dependency if I can avoid it.
    public class GenerateRandomQuoteSimple : IGenerateRandomQuote
    {
        public QuoteCubeRandom GenerateQuoteCubeRandom()
        {
            QuoteCubeRandom quoteCubeRandom = new QuoteCubeRandom();

            quoteCubeRandom.QuoteAuthor = GenerateRandomAuthorName();
            quoteCubeRandom.QuoteContent = GenerateRandomQuote();

            return quoteCubeRandom;
        }

        public string GenerateRandomAuthorName()
        {
            string firstName = "";

            var tempfirstNameWordList = new List<string>();
            tempfirstNameWordList.Add("John");
            tempfirstNameWordList.Add("Bruce");
            tempfirstNameWordList.Add("Selina");
            tempfirstNameWordList.Add("Arthur");
            tempfirstNameWordList.Add("Indiana");
            tempfirstNameWordList.Add("James");
            tempfirstNameWordList.Add("Merry");
            tempfirstNameWordList.Add("Fox");
            tempfirstNameWordList.Add("Kit");
            tempfirstNameWordList.Add("Dick");

            Random rnd = new Random();
            int tempWordListIndex1 = rnd.Next(tempfirstNameWordList.Count);
            firstName = tempfirstNameWordList[tempWordListIndex1];

            string secondName = "";

            var tempsecondNameWordList = new List<string>();
            tempsecondNameWordList.Add("Zangadi");
            tempsecondNameWordList.Add("Wayne");
            tempsecondNameWordList.Add("Kyle");
            tempsecondNameWordList.Add("Morgan");
            tempsecondNameWordList.Add("Jones");
            tempsecondNameWordList.Add("Bond");
            tempsecondNameWordList.Add("Poppins");
            tempsecondNameWordList.Add("Raker");
            tempsecondNameWordList.Add("Walker");
            tempsecondNameWordList.Add("Grayson");

            int tempWordListIndex2 = rnd.Next(tempsecondNameWordList.Count);
            secondName = tempsecondNameWordList[tempWordListIndex2];

            string fullName = firstName + " " + secondName;

            return fullName;
        }

        public string GenerateRandomQuote()
        {
            string firstSentence = "";

            var tempfirstNameWordList = new List<string>();
            tempfirstNameWordList.Add("The sun shines,");
            tempfirstNameWordList.Add("Bird is flying,");
            tempfirstNameWordList.Add("Infinity and beyond,");
            tempfirstNameWordList.Add("Cat is pawing,");
            tempfirstNameWordList.Add("It felt like,");
            tempfirstNameWordList.Add("Are you digging,");
            tempfirstNameWordList.Add("Tears in the,");
            tempfirstNameWordList.Add("Material connector is,");
            tempfirstNameWordList.Add("Up and down goes,");
            tempfirstNameWordList.Add("Shouting the name,");

            Random rnd = new Random();
            int tempWordListIndex1 = rnd.Next(tempfirstNameWordList.Count);
            firstSentence = tempfirstNameWordList[tempWordListIndex1];

            string secondSentence = "";

            var tempsecondNameWordList = new List<string>();
            tempsecondNameWordList.Add("screaming at the time.");
            tempsecondNameWordList.Add("the moon glows.");
            tempsecondNameWordList.Add("and back again to earth.");
            tempsecondNameWordList.Add("dog is barking");
            tempsecondNameWordList.Add("eyes of the ghost.");
            tempsecondNameWordList.Add("for the grave at noon.");
            tempsecondNameWordList.Add("disconnected from system.");
            tempsecondNameWordList.Add("running without limbs.");
            tempsecondNameWordList.Add("rolling ball at the mountain.");
            tempsecondNameWordList.Add("because it makes sense.");

            int tempWordListIndex2 = rnd.Next(tempsecondNameWordList.Count);
            secondSentence = tempsecondNameWordList[tempWordListIndex2];

            string fullName = firstSentence + " " + secondSentence;

            return fullName;
        }
    }
}
