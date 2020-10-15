using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomStuffGeneratorPrivate.POCO
{
    //public class AllUser3
    //{
    //}

    // AllUser3 myDeserializedClass = JsonConvert.DeserializeObject<AllUser3>(myJsonResponse); 
    public class User3
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

    public class AllUser3
    {
        [JsonProperty("MyArray")]
        public List<User3> MyArray;
    }
}
