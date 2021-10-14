using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SevDeskClient
{
    public class Tag : SevClientObject<Tag>
    {
        [JsonProperty("objectName")]
        public override string ObjectName { get; set; } = "Tag";
        public string create { get; set; }
        public string name { get; set; }
        public string objectType { get; set; }
        public string color { get; set; }

        public Tag() { }
    }
}
