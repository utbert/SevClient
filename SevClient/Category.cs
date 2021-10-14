using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SevDeskClient
{
    public class Category : SevClientObject<Category>
    {
        [JsonProperty("objectName")]
        public override string ObjectName { get; set; } = "Category";

        [JsonProperty("additionalInformation")]
        public object AdditionalInformation;

        [JsonProperty("create")]
        public DateTime? Create;

        [JsonProperty("update")]
        public DateTime? _Update;

        [JsonProperty("name")]
        public string Name;

        [JsonProperty("objectType")]
        public string ObjectType;

        [JsonProperty("priority")]
        public string Priority;

        [JsonProperty("code")]
        public string Code;

        [JsonProperty("color")]
        public string Color;

        [JsonProperty("postingAccount")]
        public object PostingAccount;

        [JsonProperty("type")]
        public string Type;

        [JsonProperty("translationCode")]
        public string TranslationCode;

    }
}
