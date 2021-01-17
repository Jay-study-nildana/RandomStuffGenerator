using Microsoft.EntityFrameworkCore;
using RandomStuffGeneratorPrivate.APIJSONClasses;
using RandomStuffGeneratorPrivate.DatabaseClasses;
using RandomStuffGeneratorPrivate.Interfaces;
using RandomStuffGeneratorPrivate.OtherClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomStuffGeneratorPrivate.HelperStuff
{
    //TODO - make it so that the QuoteHistoryModels has 4 more columns.
    //current author
    //current quote
    //previous author
    //previous quote
    //this will tell us the quote journey as it goes through modifications.
    //also, the time needs to be stored as well. Without that, we have no clue when change was introduced.
    //also, the user name should be collected as well. that column too. 

    public class QuoteHistoryCRUD : IStandardCRUD
    {
        public async Task<Object> AddOneRow(Object RowInformation, QuoteCMSContext context)
        {
            CRUDResponse cRUDResponse = new CRUDResponse();
            QuoteHistoryCube quoteHistoryCube = (QuoteHistoryCube)RowInformation;

            QuoteHistoryModel quoteHistoryModel = new QuoteHistoryModel
            {
                Active = quoteHistoryCube.Active,
                QuoteIdentifierString = quoteHistoryCube.QuoteIdentifierString
            };

            //the current age of the quote is the number of entries it has in the table.
            int ageOfQuote = context.QuoteHistoryModels.Select(x => x).Where(x => x.QuoteIdentifierString == quoteHistoryCube.QuoteIdentifierString).ToList().Count;

            quoteHistoryModel.QuoteLifeStageIncrement = ageOfQuote + 1; //the quote has aged by 1 unit.

            quoteHistoryModel.QuoteLifStageDescription = quoteHistoryCube.QuoteLifStageDescription;

            try
            {
                context.QuoteHistoryModels.Add(quoteHistoryModel);
                await context.SaveChangesAsync();
                cRUDResponse.dateTimeOfResponse = DateTime.Now;
                cRUDResponse.ListOfResponses.Add("QuoteHistoryModel was successfully added for Quote with identifier " + quoteHistoryCube.QuoteIdentifierString);
            }
            catch (Exception e)
            {
                cRUDResponse.OperationSuccessful = false;
                cRUDResponse.DetailsAboutOperation = " Error with Saving quoteHistoryModel. Details here. " + e.ToString();
                cRUDResponse.dateTimeOfResponse = DateTime.Now;

                return cRUDResponse;
            }

            return cRUDResponse;
        }

        public Task<Object> ReadAllRows(object RowInformation, QuoteCMSContext context)
        {
            CRUDResponse cRUDResponse = new CRUDResponse();
            QuoteWithHistoryItems quoteWithHistoryItems = new QuoteWithHistoryItems
            {
                quoteHistoryCubes = new List<QuoteHistoryCube>(),

                QuoteIdentifierString = (string)RowInformation
            };
            try
            {
                //TODO - I know this can be directly written into a collection of type of my choice. look into that. 
                var dbResponseList = context.QuoteHistoryModels.Select(x => x).Where(x => x.QuoteIdentifierString == (string)RowInformation).ToList();
                foreach (var x in dbResponseList)
                {
                    var tempQuoteHistoryCube = new QuoteHistoryCube
                    {
                        Active = x.Active,
                        QuoteIdentifierString = x.QuoteIdentifierString,
                        QuoteLifeStageIncrement = x.QuoteLifeStageIncrement,
                        QuoteLifStageDescription = x.QuoteLifStageDescription
                    };
                    quoteWithHistoryItems.quoteHistoryCubes.Add(tempQuoteHistoryCube);
                }
            }
            catch (Exception e)
            {
                cRUDResponse.OperationSuccessful = false;
                cRUDResponse.DetailsAboutOperation = " Error with Saving quoteHistoryModel. Details here. " + e.ToString();
                cRUDResponse.dateTimeOfResponse = DateTime.Now;

                return Task.FromResult((Object)cRUDResponse);
            }

            cRUDResponse.CRUDOperationResult = quoteWithHistoryItems;
            cRUDResponse.dateTimeOfResponse = DateTime.Now;
            return Task.FromResult((Object)cRUDResponse);
        }

        public Task<Object> UpdateOneRow(object RowInformation, QuoteCMSContext context)
        {
            //we dont actually update history. so this will remain like this.
            //we only add new items, we never update or delete.
            throw new NotImplementedException();
        }
    }

    //a quick POCO for returning a list of all history items.
    public class QuoteWithHistoryItems
    {
        public List<QuoteHistoryCube> quoteHistoryCubes { set; get; }
        public string QuoteIdentifierString { set; get; }
    }
}
