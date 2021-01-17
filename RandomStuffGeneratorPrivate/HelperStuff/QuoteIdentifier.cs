using RandomStuffGeneratorPrivate.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomStuffGeneratorPrivate.HelperStuff
{
    //I am building a quote history tracker and in general, 
    //I wish to replace the quote ID 
    //as of Version 0.2.0, I was using the DB generated ID numbers has the quote unique ID
    //Of course, I would like to not depend on that for practical purposes.
    public class QuoteIdentifier : IIdentifier
    {
        //This specific implementation works on solo quote creator
        //but it fails to work when I create some 100 or 1000 quotes at once. 
        //so, using GenerateIdentifierString(string QuoteAuthor)
        public string GenerateIdentifierString()
        {
            string sectionOne = GetSectionOne();

            string sectionTwo = GetSectionTwo();

            string sectionThree = GetSectionThree();

            string quoteIdentifierString = sectionOne + sectionTwo + sectionThree;
            return quoteIdentifierString;
        }

        public string GenerateIdentifierString(string somethingtoinclude)
        {
            string sectionOne = GetSectionOne();

            string sectionTwo = GetSectionTwo();

            string sectionThree = GetSectionThree();

            string quoteIdentifierString = sectionOne + sectionTwo + sectionThree + somethingtoinclude + Guid.NewGuid();
            return quoteIdentifierString;
        }

        private string GetSectionThree()
        {
            var tempWordList = new List<string>
            {
                "Batman",
                "Robin",
                "PoisonIvy",
                "Huntress",
                "Joker",
                "GreyGhost",
                "Alfred",
                "Fox",
                "CatWoman",
                "BatMobile"
            };

            Random rnd = new Random();
            int tempWordListIndex = rnd.Next(tempWordList.Count);
            string sectionThree = tempWordList[tempWordListIndex];
            return sectionThree;
        }

        private string GetSectionTwo()
        {
            DateTime dateTime = DateTime.Now;
            //var date1 = DateTime.Now;
            //Console.WriteLine(date1.ToString("yyyy_MM_dd_T_HH_mm_ss"));
            //// Displays 2020_12_29_T_05_20_32

            string sectionTwo = dateTime.ToString("yyyy_MM_dd_T_HH_mm_ss");
            return sectionTwo;
        }

        private string GetSectionOne()
        {
            string sectionOne = "RQ";

            return sectionOne;
        }
    }
}
