using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomStuffGeneratorPrivate.POCO
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class SingleUser
    {
        [JsonProperty("email")]
        public string Email;

        [JsonProperty("name")]
        public string Name;

        [JsonProperty("nickname")]
        public string Nickname;

        [JsonProperty("user_id")]
        public string UserId;
    }

    public class Root
    {
        //[JsonProperty("MyArray")]
        public List<SingleUser> MyArray;
    }
}
