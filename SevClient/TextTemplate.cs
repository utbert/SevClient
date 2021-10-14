using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SevDeskClient
{
    public class TextTemplate : SevClientObject<TextTemplate>
    {
        [JsonProperty("objectName")]
        public override string ObjectName { get; set; } = "TextTemplate";


        [JsonProperty("create")]
        public DateTime Create { get; set; }

        [JsonProperty("update")]
        public DateTime update { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("objectType")]
        public string ObjectType { get; set; }

        [JsonProperty("textType")]
        public string TextType { get; set; }

        [JsonProperty("sevUser")]
        public SevUser SevUser { get; set; }

        [JsonProperty("main")]
        public string Main { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }
    }
}
