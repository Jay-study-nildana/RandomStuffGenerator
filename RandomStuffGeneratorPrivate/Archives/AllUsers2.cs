using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomStuffGeneratorPrivate.POCO
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Identity
    {
        [JsonProperty("user_id")]
        public string UserId;

        [JsonProperty("provider")]
        public string Provider;

        [JsonProperty("connection")]
        public string Connection;

        [JsonProperty("isSocial")]
        public bool IsSocial;

        [JsonProperty("access_token")]
        public string AccessToken;

        [JsonProperty("expires_in")]
        public int? ExpiresIn;
    }

    public class MyArray
    {
        [JsonProperty("created_at")]
        public DateTime CreatedAt;

        [JsonProperty("email")]
        public string Email;

        [JsonProperty("email_verified")]
        public bool EmailVerified;

        [JsonProperty("identities")]
        public List<Identity> Identities;

        [JsonProperty("name")]
        public string Name;

        [JsonProperty("nickname")]
        public string Nickname;

        [JsonProperty("picture")]
        public string Picture;

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt;

        [JsonProperty("user_id")]
        public string UserId;

        [JsonProperty("last_login")]
        public DateTime LastLogin;

        [JsonProperty("last_ip")]
        public string LastIp;

        [JsonProperty("logins_count")]
        public int LoginsCount;

        [JsonProperty("family_name")]
        public string FamilyName;

        [JsonProperty("given_name")]
        public string GivenName;

        [JsonProperty("locale")]
        public string Locale;
    }

    public class AllUsers2
    {
        [JsonProperty("MyArray")]
        public List<MyArray> MyArray;
    }


}
