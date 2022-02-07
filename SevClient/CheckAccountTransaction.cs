using Newtonsoft.Json;
using System.Collections.Generic;

namespace SevDeskClient
{
    public class CheckAccountTransaction : SevClientObject<CheckAccountTransaction>
    {
        [JsonProperty("objectName")]
        public override string ObjectName { get; set; } = "CheckAccountTransaction";
        public string amount { get; set; }
        public CheckAccount checkAccount { get; set; }
        public string compareHash { get; set; }
        public string create { get; set; }
        public string enshrined { get; set; }
        public string entryDate { get; set; }
        public string entryText { get; set; }
        public string feeAmount { get; set; }
        public string gvCode { get; set; }
        public List<CheckAccountTransactionLog> log { get; set; }
        public string obonoReceiptUuid { get; set; }
        public string payeePayerAcctNo { get; set; }
        public string payeePayerBankCode { get; set; }
        public string payeePayerName { get; set; }
        public string paymtPurpose { get; set; }
        public string primaNotaNo { get; set; }
        public string remainingAmount { get; set; }
        public string remainingAmountInHomeCurrency { get; set; }
        public string score { get; set; }
        public string status { get; set; }
        public string update { get; set; }
        public string valueDate { get; set; }

        public CheckAccountTransaction() { }
    }
}
