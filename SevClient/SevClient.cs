using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SevDeskClient
{

    public class SevClient
    {
        protected static RestClient restClient = new RestClient(new Uri("https://my.sevdesk.de/api/v1/"));

        public SevClient(string token)
        {
            restClient.DefaultParameters.RemoveParameter("token");
            restClient.AddDefaultParameter("token", token, ParameterType.QueryString);

            JsonSerializerSettings DefaultSettings = new JsonSerializerSettings
            {
                ContractResolver = new JsonPropertiesResolver(),
                DefaultValueHandling = DefaultValueHandling.Include,
                TypeNameHandling = TypeNameHandling.None,
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.None,
                ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor
            };

            restClient.UseNewtonsoftJson(DefaultSettings);

        }

        protected SevClient()
        {
        }
    }

}
