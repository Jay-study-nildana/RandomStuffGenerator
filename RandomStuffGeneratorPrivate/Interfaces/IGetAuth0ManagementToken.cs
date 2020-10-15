using RandomStuffGeneratorPrivate.POCO;
using RandomStuffGeneratorPrivate.POCO.Auth0TokenResponseManagementApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomStuffGeneratorPrivate.Interfaces
{
    public interface IGetAuth0ManagementToken
    {
        public Task<Auth0TokenResponseManagementApi> GetAuth0ManagementAPITokenAsync();
    }
}
