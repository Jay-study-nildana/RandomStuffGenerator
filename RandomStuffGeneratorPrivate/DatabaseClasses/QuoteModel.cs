using RandomStuffGeneratorPrivate.BaseClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RandomStuffGeneratorPrivate.DatabaseClasses
{
    public class QuoteModel : QuoteBase
    {
        //this is the database ID. for database use only.
        //for some reason EF did no automatically detect, despite the Id, that this is a key.
        //Very Odd.
        [Key]
        public int QuoteId { get; set; }
    }
}
