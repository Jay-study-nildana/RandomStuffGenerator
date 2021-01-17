using RandomStuffGeneratorPrivate.DatabaseClasses;
using RandomStuffGeneratorPrivate.OtherClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomStuffGeneratorPrivate.Interfaces
{
    //of course, I will have many CRUD for database.
    //all of them should use this.
    public interface IStandardCRUD
    {
        public Task<Object>  ReadAllRows(Object RowInformation, QuoteCMSContext context);

        public Task<Object> AddOneRow(Object RowInformation, QuoteCMSContext context);

        public Task<Object> UpdateOneRow(Object RowInformation, QuoteCMSContext context);
    }
}
