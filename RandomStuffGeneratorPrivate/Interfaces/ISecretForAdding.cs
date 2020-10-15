using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomStuffGeneratorPrivate.Interfaces
{
    //As of now, I am not adding an auth system to this API server
    //if you are looking for a auth based token issuing OAuth enabled API server
    //look at this
    //https://github.com/Jay-study-nildana/ProjectWTPublicRepos/tree/master/apiservers/dotnetcoreapiserverwithauth0
    //and this 
    //https://github.com/Jay-study-nildana/APIServerDotNetCoreWithAuth0
    //So, I am adding a simple secret phrase hardcoded to this project
    //without this phrase in the POST for adding quotes
    //noone can add a quote. obviously, this is easily hackable but this is done on purpose
    public interface ISecretForAdding
    {
        public Object ReturnTheSecretForAdding();
    }
}
