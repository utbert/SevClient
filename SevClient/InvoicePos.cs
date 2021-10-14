using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SevDeskClient
{
    public class InvoicePos : SevClientObject<InvoicePos>
    {
        [JsonProperty("objectName")]
        public override string ObjectName { get; set; } = "InvoicePos";
        public string create { get; set; }
        public string update { get; set; }
        public Invoice invoice { get; set; }
        public Part part { get; set; }
        public string quantity { get; set; } = "1";
        public string price { get; set; }
        public string name { get; set; }
        public string priority { get; set; } = "0";
        public Unity unity { get; set; } = new Unity();
        public string positionNumber { get; set; }
        public string text { get; set; }
        public string discount { get; set; }
        public string taxRate { get; set; } = DateTime.Now > new DateTime(2020,7,1) & DateTime.Now < new DateTime(2020,12,31) ? "16" : "19";
        public string temporary { get; set; }
        public string sumNet { get; set; }
        public string sumGross { get; set; }
        public string sumDiscount { get; set; }
        public string sumTax { get; set; }
        public string sumNetAccounting { get; set; }
        public string sumTaxAccounting { get; set; }
        public string sumGrossAccounting { get; set; }
        public string priceNet { get; set; }
        public string priceGross { get; set; }
        public string priceTax { get; set; }
        public string sumNetForeignCurrency { get; set; }
        public string sumTaxForeignCurrency { get; set; }
        public string sumGrossForeignCurrency { get; set; }
        public string sumDiscountForeignCurrency { get; set; }
        public string createNextPart { get; set; }
        public string mapAll { get; } = "true";

        public InvoicePos() { }

    }
}
