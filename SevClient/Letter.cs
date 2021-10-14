using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SevDeskClient
{
    public class Letter : SevClientPdfObject<Letter>
    {
        [JsonProperty("objectName")]
        public override string ObjectName { get; set; } = "Letter";
        public string create { get; set; }
        public string update { get; set; }
        public string letterNumber { get; set; }
        public Contact contact { get; set; }
        public string letterDate { get; set; } = DateTimeOffset.Now.ToUnixTimeSeconds().ToString();
        public string header { get; set; }
        public string status { get; set; } = "200";
        public SevUser contactPerson { get; set; } = new SevUser();
        public string addressParentName { get; set; }
        public string text { get; set; }
        public string sendDate { get; set; } = DateTimeOffset.Now.ToUnixTimeSeconds().ToString();
        public string addressParentName2 { get; set; }
        public string address { get; set; }
        public string sendType { get; set; } = "VP";

        public Letter() { }
    }
}
