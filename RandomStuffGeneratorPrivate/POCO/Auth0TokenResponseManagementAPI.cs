using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace RandomStuffGeneratorPrivate.POCO.Auth0TokenResponseManagementApi
{
    //this is a POCO used to collect the response from the management API.
    //if Auth0 should ever change the response format, then, we probably should change this too.
    public partial class Auth0TokenResponseManagementApi
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; }
    }

    public partial class Auth0TokenResponseManagementApi
    {
        public static Auth0TokenResponseManagementApi FromJson(string json) => JsonConvert.DeserializeObject<Auth0TokenResponseManagementApi>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Auth0TokenResponseManagementApi self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
