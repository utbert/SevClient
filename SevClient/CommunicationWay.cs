using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SevDeskClient
{
    public class CommunicationWay : SevClientObject<CommunicationWay>
    {
        [JsonProperty("objectName")]
        public override string ObjectName { get; set; } = "CommunicationWay";
        public string create { get; set; }
        public string update { get; set; }
        public Contact contact { get; set; }
        public string type { get; set; }
        public string value { get; set; }
        public string main { get; set; }


        public CommunicationWay() { }
    }
}
