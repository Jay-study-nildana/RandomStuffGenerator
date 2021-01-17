using RandomStuffGeneratorPrivate.APIJSONClasses;
using RandomStuffGeneratorPrivate.OtherClasses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RandomStuffGeneratorPrivate.Interfaces
{
    public interface IQuoteCubeCollection
    {
        public Task<QuoteCubeCollection> GetQuoteCubeCollection(OptionsCollectionOfQuotes optionsCollectionOfQuotes);
    }
}
