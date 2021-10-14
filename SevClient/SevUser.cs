using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SevDeskClient
{
    public class SevUser : SevClientObject<SevUser>
    {
        [JsonProperty("id")]
        public override string Id { get; set; } = "236508";

        [JsonProperty("objectName")]
        public override string ObjectName { get; set; } = "SevUser";
        public SevUser() { }
    }
}
