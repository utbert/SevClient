using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SevDeskClient
{
    public class response
    {
        [JsonProperty("total")]
        public int total { get; set; }

        [JsonProperty("objects", ItemConverterType = typeof(SevClientDataConverter))]
        public List<object> objects { get; set; }
    }
}
