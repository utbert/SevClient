using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SevDeskClient
{
    public class CheckAccountTransactionLog : SevClientObject<CheckAccountTransaction>
    {

        [JsonProperty("objectName")]
        public override string ObjectName { get; set; } = "CheckAccountTransactionLog";

        [JsonProperty("create")]
        public DateTime Create { get; set; }

        [JsonProperty("checkAccountTransaction")]
        public CheckAccountTransaction CheckAccountTransaction { get; set; }

        [JsonProperty("fromStatus")]
        public string FromStatus { get; set; }

        [JsonProperty("toStatus")]
        public string ToStatus { get; set; }

        [JsonProperty("amountPaid")]
        public string AmountPaid { get; set; }

        [JsonProperty("bookingDate")]
        public DateTime BookingDate { get; set; }

        [JsonProperty("object"), JsonConverter(typeof(SevClientDataConverter))]
        public Object Object { get; set; }

        [JsonProperty("unlinkableError")]
        public int UnlinkableError { get; set; }

        public CheckAccountTransactionLog() { }
    }
}
