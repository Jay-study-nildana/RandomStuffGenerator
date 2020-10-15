using RandomStuffGeneratorPrivate.DatabaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomStuffGeneratorPrivate.Interfaces
{
    //TODO how do i build an interface and an implementation that allows me to collect the context from anywhere in the project
    public interface IGetTheDBContext
    {
        public BloggingContext GetTheContext();
    }
}
