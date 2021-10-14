using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SevDeskClient
{
    public class PaymentMethod : SevClientObject<PaymentMethod>
    {
        [JsonProperty("objectName")]
        public override string ObjectName { get; set; } = "PaymentMethod";
        public string create { get; set; }
        public string update { get; set; }
        public string name { get; set; }
        public string text { get; set; }

        public PaymentMethod() { }
    }
}
