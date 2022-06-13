using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SevDeskClient
{
    public class ContactCustomFieldSetting : SevClientObject<ContactCustomFieldSetting>
    {
        [JsonProperty("objectName")]
        public override string ObjectName { get; set; } = "ContactCustomFieldSetting";

        [JsonProperty("additionalInformation")]
        public object AdditionalInformation { get; set; }

        [JsonProperty("create")]
        public DateTime? Create { get; set; }

        [JsonProperty("update")]
        public DateTime? _Update { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("identifier")]
        public string Identifier { get; set; }

        [JsonProperty("description")]
        public object Description { get; set; }

        [JsonProperty("placeholder")]
        public string Placeholder { get; set; }
    }
}
