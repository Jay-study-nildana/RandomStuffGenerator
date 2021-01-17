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
    public class QuoteModelCRUD : IStandardCRUD
    {
        public async Task<Object> AddOneRow(object RowInformation, QuoteCMSContext context)
        {
            AddNewQuoteCRUDResponse addNewQuoteCRUDResponse = new AddNewQuoteCRUDResponse();
            QuoteIdentifier quoteIdentifier = new QuoteIdentifier();
            QuoteCubeForPOSTCreate quoteCubeForPOSTCreate = (QuoteCubeForPOSTCreate)RowInformation;

            QuoteModel quoteModel = new QuoteModel
            {
                QuoteAuthor = quoteCubeForPOSTCreate.QuoteAuthor,
                QuoteContent = quoteCubeForPOSTCreate.QuoteContent,
                QuoteIdentifierString = quoteIdentifier.GenerateIdentifierString("dash")
            };

            try
            {
                context.QuoteModels.Add(quoteModel);
                await context.SaveChangesAsync();
                addNewQuoteCRUDResponse.dateTimeOfResponse = DateTime.Now;
                addNewQuoteCRUDResponse.ListOfResponses.Add("New Quote has been successfully added. Identifier is " + quoteModel.QuoteIdentifierString);
                addNewQuoteCRUDResponse.QuoteIdentifierString = quoteModel.QuoteIdentifierString;

            }
            catch (Exception e)
            {
                addNewQuoteCRUDResponse.OperationSuccessful = false;
                addNewQuoteCRUDResponse.DetailsAboutOperation = " Error with Saving QuoteModel. Details here. " + e.ToString();
                addNewQuoteCRUDResponse.dateTimeOfResponse = DateTime.Now;

                return addNewQuoteCRUDResponse;
            }

            //at this point, the quote is in the system.
            //so, I will start the life of this quote, in QuoteHistoryModel

            QuoteHistoryCube quoteHistoryCube = new QuoteHistoryCube
            {
                Active = true,
                QuoteIdentifierString = quoteModel.QuoteIdentifierString,
                QuoteLifeStageIncrement = 1, //it is just born. So, 1 is its age.
                                             //TODO - randomly assign a different birth string for this.
                QuoteLifStageDescription = "Happy Birthday. A Quote is Born. Conquerer of the world! Author " + quoteCubeForPOSTCreate.QuoteAuthor + " Quote " + quoteCubeForPOSTCreate.QuoteContent
            };
            IStandardCRUD standardCRUD = new QuoteHistoryCRUD();
            var quoteHistoryCRUDResponse = (CRUDResponse) await standardCRUD.AddOneRow(quoteHistoryCube, context);

            //update the local crud response with response of the QuoteHistoryCRUD operation 
            addNewQuoteCRUDResponse.dateTimeOfResponse = DateTime.Now;
            addNewQuoteCRUDResponse.ListOfResponses.AddRange(quoteHistoryCRUDResponse.ListOfResponses);
            //if second operation has failed, then, obviously, this should indicate that things have failed
            //developer will be able to look at list of responses to see where things went wrong.
            addNewQuoteCRUDResponse.DetailsAboutOperation = quoteHistoryCRUDResponse.DetailsAboutOperation;
            addNewQuoteCRUDResponse.OperationSuccessful = quoteHistoryCRUDResponse.OperationSuccessful;

            //one last message
            addNewQuoteCRUDResponse.ListOfResponses.Add("Create and History Operations Completed. Please dont assume success. Check OperationSuccessful and ListOfResponses for more details");

            return addNewQuoteCRUDResponse;
        }

        public async Task<Object> UpdateOneRow(object RowInformation, QuoteCMSContext context)
        {
            AddNewQuoteCRUDResponse addNewQuoteCRUDResponse = new AddNewQuoteCRUDResponse();
            QuoteIdentifier quoteIdentifier = new QuoteIdentifier();
            QuoteCubeForPOSTUpdate quoteCubeForPOST = (QuoteCubeForPOSTUpdate)RowInformation;

            //first, get the quote from the table.
            QuoteModel quoteModel = await context.QuoteModels.Select(x => x).Where(x => x.QuoteIdentifierString == quoteCubeForPOST.QuoteIdentifierString).FirstOrDefaultAsync();

            if(quoteModel.QuoteIdentifierString.Equals(quoteCubeForPOST.QuoteIdentifierString) == true )
            {
                //continue with update.
                quoteModel.QuoteAuthor = quoteCubeForPOST.QuoteAuthor;
                quoteModel.QuoteContent = quoteCubeForPOST.QuoteContent;

                try
                {
                    context.Entry(quoteModel).State = EntityState.Modified;
                    await context.SaveChangesAsync();
                    addNewQuoteCRUDResponse.dateTimeOfResponse = DateTime.Now;

                    //update response list.
                    addNewQuoteCRUDResponse.ListOfResponses.Add("Quote with QuoteIdentifier " + quoteCubeForPOST.QuoteIdentifierString + " Updated Successfully");
                }
                catch (Exception e)
                {
                    addNewQuoteCRUDResponse.OperationSuccessful = false;
                    addNewQuoteCRUDResponse.DetailsAboutOperation = " Error with Saving QuoteModel. Details here. " + e.ToString();
                    addNewQuoteCRUDResponse.dateTimeOfResponse = DateTime.Now;

                    return (Object)addNewQuoteCRUDResponse;
                }
            }
            else
            {
                //its not in our system.
                addNewQuoteCRUDResponse.OperationSuccessful = false;
                addNewQuoteCRUDResponse.DetailsAboutOperation = "Unable to find Quote with identifier " + quoteCubeForPOST.QuoteIdentifierString;
                addNewQuoteCRUDResponse.dateTimeOfResponse = DateTime.Now;

                return (Object)addNewQuoteCRUDResponse;    
            }

            //if we are here, that means, update was successfull
            //lets add a history item. 

            QuoteHistoryCube quoteHistoryCube = new QuoteHistoryCube
            {
                Active = true,
                QuoteIdentifierString = quoteModel.QuoteIdentifierString,
                //TODO - if a specific item is unchanged, the description should indicate that author was not change or quote was not changed. or both were not changed.
                QuoteLifStageDescription = "Quote Updated. Author " + quoteCubeForPOST.QuoteAuthor + " Quote " + quoteCubeForPOST.QuoteContent
            };
            IStandardCRUD standardCRUD = new QuoteHistoryCRUD();
            var crudResponse2 = (CRUDResponse) await standardCRUD.AddOneRow(quoteHistoryCube, context);

            //update the local crud response with response of the QuoteHistoryCRUD operation 
            addNewQuoteCRUDResponse.dateTimeOfResponse = DateTime.Now;
            addNewQuoteCRUDResponse.ListOfResponses.AddRange(crudResponse2.ListOfResponses);
            //if second operation has failed, then, obviously, this should indicate that things have failed
            //developer will be able to look at list of responses to see where things went wrong.
            addNewQuoteCRUDResponse.DetailsAboutOperation = crudResponse2.DetailsAboutOperation;
            addNewQuoteCRUDResponse.OperationSuccessful = crudResponse2.OperationSuccessful;
            addNewQuoteCRUDResponse.QuoteIdentifierString = quoteCubeForPOST.QuoteIdentifierString;

            //one last message
            addNewQuoteCRUDResponse.ListOfResponses.Add("Create and History Operations Completed. Please dont assume success. Check OperationSuccessful and ListOfResponses for more details");

            return (Object)addNewQuoteCRUDResponse;
        }

        public Task<Object> ReadAllRows(object RowInformation, QuoteCMSContext context)
        {
            throw new NotImplementedException();
        }
    }
}
