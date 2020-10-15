using Newtonsoft.Json;
using RandomStuffGeneratorPrivate.Interfaces;
using RandomStuffGeneratorPrivate.POCO;
using RandomStuffGeneratorPrivate.POCO.Auth0TokenResponseManagementApi;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomStuffGeneratorPrivate.HelperStuff
{
    public class ManagementAPIHelpers
    {
        public async Task<List<AllUsers445>> GetAllUsersAsync()
        {
            var tempAllUsers = new List<AllUsers445>();

            //first, I want to test the management API token. 
            IGetAuth0ManagementToken getAuth0ManagementToken = new GetAuth0ManagementToken();
            var tempResponse1 = await getAuth0ManagementToken.GetAuth0ManagementAPITokenAsync();

            //okay, we have the token.
            //now, we do the actual getting of all users. 
            //this is the direct request URL
            //https://randomquoteexperimental.us.auth0.com/api/v2/users?fields=user_id%2Cemail%2Cusername%2Cname%2Cnickname&include_fields=true
            var tempapiendpoint = @"https://randomquoteexperimental.us.auth0.com/api/v2/users";
            var bearerstring = @"Bearer "+ tempResponse1.AccessToken;
            var specificfields = @"user_id,email,username,name,nickname";
            var header = "authorization";
            var specificfieldname = "fields";
            var includefieldname = "include_fields";
            var includetrueorfalse = "true";

            var client = new RestClient(tempapiendpoint);
            var request = new RestRequest(Method.GET);
            request.AddHeader(header, bearerstring);
            request.AddParameter(specificfieldname,specificfields);
            request.AddParameter(includefieldname, includetrueorfalse);
            IRestResponse response = await client.ExecuteAsync(request);

            //var myDeserializedClass = JsonConvert.DeserializeObject<List<SingleUser>>(response.Content);

            string jsonString = response.Content;
            var allUsers445 = AllUsers445.FromJson(jsonString);
            tempAllUsers = allUsers445;

            return tempAllUsers;
        }
    }

    //IGetAuth0ManagementToken
    //lets implement the management API token collection interface.
    public class GetAuth0ManagementToken : IGetAuth0ManagementToken
    {
        public async Task<Auth0TokenResponseManagementApi> GetAuth0ManagementAPITokenAsync()
        {
            var client = new RestClient("https://randomquoteexperimental.us.auth0.com/oauth/token");
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/json");
            request.AddParameter("application/json", "{\"client_id\":\"VkHkNEWcjov4HWefMybyr4olTFJvr1L8\",\"client_secret\":\"K6IZL4Ck3G3ZcCD8rBcrT4hKY8ECxNYt81x58lILvSPOY0o9fuc8ZhCaIod5mIag\",\"audience\":\"https://randomquoteexperimental.us.auth0.com/api/v2/\",\"grant_type\":\"client_credentials\"}", ParameterType.RequestBody);
            IRestResponse response = await client.ExecuteAsync(request);
            //var customerDto = JsonConvert.DeserializeObject<CustomerDto>(response.Content);
            var responseGet2 = JsonConvert.DeserializeObject<Auth0TokenResponseManagementApi>(response.Content);

            return responseGet2;
        }
    }
}
