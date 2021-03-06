﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RandomStuffGeneratorPrivate.APIJSONClasses;
using RandomStuffGeneratorPrivate.DatabaseClasses;
using RandomStuffGeneratorPrivate.HelperStuff;
using RandomStuffGeneratorPrivate.Interfaces;

namespace RandomStuffGeneratorPrivate.QuickCheckControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckAndDeleteController : ControllerBase
    {
        private readonly QuoteCMSContext _context;


        public CheckAndDeleteController(QuoteCMSContext context)
        {
            _context = context;
        }

        ////use this for testing. You dont need to enter a quote and author everytime.
        //[HttpPost]
        //[Route("AddAutoGeneratedQuotePlural")]
        //public async Task<ActionResult<GeneralAPIResponse>> AddAutoGeneratedQuote(int NumberOfQuotes)
        //{
        //    var generalAPIResponse = new GeneralAPIResponse();
        //    IStandardCRUD standardCRUD = new QuoteModelCRUD();

        //    QuoteCubeForPOSTCreate quoteCubeForPOST = new QuoteCubeForPOSTCreate();
        //    IGenerateRandomQuote generateRandomQuote = new GenerateRandomQuoteSimple();

        //    Stopwatch stopWatch = new Stopwatch();
        //    stopWatch.Start();

        //    for (int i =0;i<NumberOfQuotes;i++)
        //    {
        //        var autogeneratedRandomQuote = generateRandomQuote.GenerateQuoteCubeRandom();
        //        quoteCubeForPOST.QuoteAuthor = autogeneratedRandomQuote.QuoteAuthor;
        //        quoteCubeForPOST.QuoteContent = autogeneratedRandomQuote.QuoteContent;

        //        var crudResponse = await standardCRUD.AddOneRow(quoteCubeForPOST, _context);

        //        generalAPIResponse.dateTimeOfResponse = crudResponse.dateTimeOfResponse;
        //        generalAPIResponse.DetailsAboutOperation = crudResponse.DetailsAboutOperation;
        //        generalAPIResponse.ListOfResponses.AddRange(crudResponse.ListOfResponses);
        //        generalAPIResponse.OperationSuccessful = crudResponse.OperationSuccessful;
        //    }

        //    stopWatch.Stop();

        //    // Get the elapsed time as a TimeSpan value.
        //    TimeSpan ts = stopWatch.Elapsed;

        //    generalAPIResponse.ListOfResponses.Add("Total time Taken " + ts.TotalSeconds);

        //    return generalAPIResponse;
        //}

        //[HttpPost]
        //[Route("AddQuoteModel")]
        //public async Task<ActionResult<GeneralAPIResponse>> AddQuoteModel(QuoteCubeForPOSTCreate quoteCubeForPOST)
        //{
        //    var generalAPIResponse = new GeneralAPIResponse();
        //    IStandardCRUD standardCRUD = new QuoteModelCRUD();

        //    var crudResponse = await standardCRUD.AddOneRow(quoteCubeForPOST,_context);

        //    generalAPIResponse.dateTimeOfResponse = crudResponse.dateTimeOfResponse;
        //    generalAPIResponse.DetailsAboutOperation = crudResponse.DetailsAboutOperation;
        //    generalAPIResponse.ListOfResponses = crudResponse.ListOfResponses;
        //    generalAPIResponse.OperationSuccessful = crudResponse.OperationSuccessful;

        //    return generalAPIResponse;
        //}


        ////use this for testing. You dont need to enter a quote and author everytime.
        //[HttpPost]
        //[Route("AddAutoGeneratedQuote")]
        //public async Task<ActionResult<GeneralAPIResponse>> AddAutoGeneratedQuote()
        //{
        //    var generalAPIResponse = new GeneralAPIResponse();
        //    IStandardCRUD standardCRUD = new QuoteModelCRUD();

        //    QuoteCubeForPOSTCreate quoteCubeForPOST = new QuoteCubeForPOSTCreate();
        //    IGenerateRandomQuote generateRandomQuote = new GenerateRandomQuoteSimple();
        //    var autogeneratedRandomQuote = generateRandomQuote.GenerateQuoteCubeRandom();
        //    quoteCubeForPOST.QuoteAuthor = autogeneratedRandomQuote.QuoteAuthor;
        //    quoteCubeForPOST.QuoteContent = autogeneratedRandomQuote.QuoteContent;

        //    var crudResponse = await standardCRUD.AddOneRow(quoteCubeForPOST, _context);

        //    generalAPIResponse.dateTimeOfResponse = crudResponse.dateTimeOfResponse;
        //    generalAPIResponse.DetailsAboutOperation = crudResponse.DetailsAboutOperation;
        //    generalAPIResponse.ListOfResponses = crudResponse.ListOfResponses;
        //    generalAPIResponse.OperationSuccessful = crudResponse.OperationSuccessful;

        //    return generalAPIResponse;
        //}

        //[HttpPost]
        //[Route("UpdateQuoteModel")]
        //public async Task<ActionResult<GeneralAPIResponse>> UpdateQuoteModel(QuoteCubeForPOSTUpdate quoteCubeForPOST)
        //{
        //    var generalAPIResponse = new GeneralAPIResponse();
        //    IStandardCRUD standardCRUD = new QuoteModelCRUD();

        //    var crudResponse = await standardCRUD.UpdateOneRow(quoteCubeForPOST, _context);

        //    generalAPIResponse.dateTimeOfResponse = crudResponse.dateTimeOfResponse;
        //    generalAPIResponse.DetailsAboutOperation = crudResponse.DetailsAboutOperation;
        //    generalAPIResponse.ListOfResponses = crudResponse.ListOfResponses;
        //    generalAPIResponse.OperationSuccessful = crudResponse.OperationSuccessful;

        //    return generalAPIResponse;
        //}

        //[HttpPost]
        //[Route("GetQuoteWithHistory")]
        //public async Task<ActionResult<CRUDAPIResponseQuoteWithHistory>> GetQuoteWithHistory(QuoteSpecificCubeRequest quoteSpecificCubeRequest)
        //{
        //    var cRUDAPIResponseQuoteWithHistory = new CRUDAPIResponseQuoteWithHistory();
        //    IStandardCRUD standardCRUD = new QuoteHistoryCRUD();

        //    var crudResponse = await standardCRUD.ReadAllRows(quoteSpecificCubeRequest.QuoteIdentifier, _context);

        //    cRUDAPIResponseQuoteWithHistory.dateTimeOfResponse = crudResponse.dateTimeOfResponse;
        //    cRUDAPIResponseQuoteWithHistory.DetailsAboutOperation = crudResponse.DetailsAboutOperation;
        //    cRUDAPIResponseQuoteWithHistory.ListOfResponses = crudResponse.ListOfResponses;
        //    cRUDAPIResponseQuoteWithHistory.OperationSuccessful = crudResponse.OperationSuccessful;
        //    cRUDAPIResponseQuoteWithHistory.QuoteWithHistoryItems = (QuoteWithHistoryItems)crudResponse.CRUDOperationResult;

        //    return cRUDAPIResponseQuoteWithHistory;
        //}

        //// GET: api/CheckAndDelete
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<QuoteModel>>> GetQuoteModels()
        //{
        //    return await _context.QuoteModels.ToListAsync();
        //}

        //// GET: api/CheckAndDelete/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<QuoteModel>> GetQuoteModel(int id)
        //{
        //    var quoteModel = await _context.QuoteModels.FindAsync(id);

        //    if (quoteModel == null)
        //    {
        //        return NotFound();
        //    }

        //    return quoteModel;
        //}

        //// PUT: api/CheckAndDelete/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for
        //// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutQuoteModel(int id, QuoteModel quoteModel)
        //{
        //    if (id != quoteModel.QuoteId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(quoteModel).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!QuoteModelExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/CheckAndDelete
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for
        //// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPost]
        //public async Task<ActionResult<QuoteModel>> PostQuoteModel(QuoteModel quoteModel)
        //{
        //    _context.QuoteModels.Add(quoteModel);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetQuoteModel", new { id = quoteModel.QuoteId }, quoteModel);
        //}

        //// DELETE: api/CheckAndDelete/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<QuoteModel>> DeleteQuoteModel(int id)
        //{
        //    var quoteModel = await _context.QuoteModels.FindAsync(id);
        //    if (quoteModel == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.QuoteModels.Remove(quoteModel);
        //    await _context.SaveChangesAsync();

        //    return quoteModel;
        //}

        //private bool QuoteModelExists(int id)
        //{
        //    return _context.QuoteModels.Any(e => e.QuoteId == id);
        //}
    }
}
