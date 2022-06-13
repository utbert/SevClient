using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace SevDeskClient
{
    public class CheckAccount : SevClientObject<CheckAccount>
    {
        [JsonProperty("objectName")]
        public override string ObjectName { get; set; } = "CheckAccount";

        [JsonProperty("create")]
        public DateTime Create { get; set; }

        [JsonProperty("update")]
        public DateTime _Update { get; set; }

        //[JsonProperty("sevClient")]
        //public SevClient SevClient { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("importType")]
        public string ImportType { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("checkAccId")]
        public string CheckAccId { get; set; }

        [JsonProperty("pin")]
        public string Pin { get; set; }

        [JsonProperty("defaultAccount")]
        public string DefaultAccount { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("translationCode")]
        public string TranslationCode { get; set; }

        [JsonProperty("bankServer")]
        public string BankServer { get; set; }

        [JsonProperty("balance")]
        public string Balance { get; set; }

        [JsonProperty("accountingNumber")]
        public string AccountingNumber { get; set; }

        [JsonProperty("iban")]
        public string Iban { get; set; }

        [JsonProperty("bic")]
        public string Bic { get; set; }

        [JsonProperty("baseAccount")]
        public string BaseAccount { get; set; }

        [JsonProperty("priority")]
        public string Priority { get; set; }

        [JsonProperty("countryCode")]
        public string CountryCode { get; set; }

        [JsonProperty("autoMapTransaction")]
        public string AutoMapTransaction { get; set; }

        [JsonProperty("lastSync")]
        public DateTime LastSync { get; set; }

        [JsonProperty("connection")]
        public object Connection { get; set; }

        public CheckAccount() { }

        public HttpStatusCode MapTransactions(out MapTransactionsResult result)
        {
            RestRequest restRequest = new RestRequest();
            restRequest.Resource = $"{ObjectName}/{Id}/mapTransactions";
            restRequest.AddParameter("embed", "openReminderCharge");
            restRequest.Method = Method.Post;

            RestResponse response = restClient.ExecuteAsync(restRequest).Result;
            result = JsonConvert.DeserializeAnonymousType(response.Content, new { objects = new MapTransactionsResult() }, new JsonSerializerSettings() { MissingMemberHandling = MissingMemberHandling.Ignore }).objects;


            HttpStatusCode httpStatusCode = response.StatusCode;
            return httpStatusCode;
        }


    }
    public class MapTransactionsResult
    {
        [JsonProperty("successCount")]
        public int SuccessCount { get; set; }

        [JsonProperty("suggestionCount")]
        public int SuggestionCount { get; set; }

        [JsonProperty("suggestions")]
        public List<Suggestion> Suggestions { get; set; }
    }
    public class Suggestion
    {
        [JsonProperty("transaction")]
        public CheckAccountTransaction Transaction { get; set; }

        [JsonProperty("transactionRemainingAmount")]
        public string TransactionRemainingAmount { get; set; }

        [JsonProperty("document")]
        public SevClientObject Document { get; set; }

        [JsonProperty("documentDebit")]
        public string DocumentDebit { get; set; }
    }
}
