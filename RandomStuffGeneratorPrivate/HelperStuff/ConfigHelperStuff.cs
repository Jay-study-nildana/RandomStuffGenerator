using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomStuffGeneratorPrivate.HelperStuff
{
    public class ConfigHelperStuff
    {
        //constructor. put all your values here. 
        //I have put some example values but change them as per your convenience
        public ConfigHelperStuff()
        {
            SwaggerDocname = @"v1";
            SwaggerDocVersion = @"v1";
            SwaggerDocTitle = @"Random Stuff Generator API Documentation";
            SwaggerDocDescription = @"an api server that randomly generates things.";
            SwaggerDocTermsOfService = @"https://baribasic.com/";
            SwaggerDocContactName = @"Jay";
            SwaggerDocContactEmail = @"jay@thechalakas.com";
            SwaggerDocContactUrl = @"https://thechalakas.com";
            //I dont have a license file. but I do want to point to my repo.
            SwaggerDocLicenseName = @"GitHub Repo";
            SwaggerDocLicenseUrl = @"https://jay-study-nildana.github.io/RandomStuffDocs/";
            UseSwaggerUISwaggerEndpointTitle = @"an api server that randomly returns quotes.";
        }

        //related to AddSwaggerGen in Startup

        //c.SwaggerDoc("v1", new OpenApiInfo
        public string SwaggerDocname { set; get; }
        //Version = "v1",
        public string SwaggerDocVersion { set; get; }
        //Title = "Project WT API Server",
        public string SwaggerDocTitle { set; get; }
        //Description = "a simple dot net
        public string SwaggerDocDescription { set; get; }
        //TermsOfService = new Uri("https://baribasic.com/"),
        public string SwaggerDocTermsOfService { set; get; }
        //Name = "Jay",
        public string SwaggerDocContactName { set; get; }
        //Email = "jay@thechalakas.com",
        public string SwaggerDocContactEmail { set; get; }
        //Url = new Uri("https://thechalakas.com"),
        public string SwaggerDocContactUrl { set; get; }
        //Name = "No License. Made For Students. Use as needed",
        public string SwaggerDocLicenseName { set; get; }
        //Url = new Uri("https://baribasic.com/"),
        public string SwaggerDocLicenseUrl { set; get; }

        //related to UseSwaggerUI in Startup
        //c.SwaggerEndpoint("/swagger/v1/swagger.json", "bari basic dot net core api server");
        public string UseSwaggerUISwaggerEndpointTitle { set; get; }
    }
}
