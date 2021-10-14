using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SevDeskClient
{
    public class Part : SevClientObject<Part>
    {

        [JsonProperty("objectName")]
        public override string ObjectName { get; set; } = "Part";
        public string create { get; set; }
        public string update { get; set; }
        public string name { get; set; }
        public string partNumber { get; set; }
        public string text { get; set; }
        public object category { get; set; }
        public string stock { get; set; }
        public string stockEnabled { get; set; }
        public Unity unity { get; set; }
        public string pricePartner { get; set; }
        public string priceCustomer { get; set; }
        public string price { get; set; }
        public string secondUnityFactor { get; set; }
        public string pricePurchase { get; set; }
        public string taxRate { get; set; }
        public string image { get; set; }
        public string status { get; set; }
        public string internalComment { get; set; }
        public string priceNet { get; set; }
        public string priceGross { get; set; }

        public Part() { }
    }
}
