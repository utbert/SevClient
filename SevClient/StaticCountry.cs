using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Text;

namespace SevDeskClient
{
    public class StaticCountry : SevClientObject<StaticCountry>
    {
        [JsonProperty("id")]
        public override string Id { get; set; } = "1";

        [JsonProperty("objectName")]
        public override string ObjectName { get; set; } = "StaticCountry";

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("nameEn")]
        public string NameEn { get; set; }

        [JsonProperty("translationCode")]
        public string TranslationCode { get; set; }

        [JsonProperty("locale")]
        public string Locale { get; set; }

        [JsonProperty("priority")]
        public string Priority { get; set; }


        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Not Supported", true)]
        public new HttpStatusCode Update()
        {
            throw new NotSupportedException();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Not Supported", true)]
        public new HttpStatusCode Add(out StaticCountry returnvalue)
        {
            throw new NotSupportedException();
            
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Not Supported", true)]
        public new HttpStatusCode Delete()
        {
            throw new NotSupportedException();
        }
    }
}
