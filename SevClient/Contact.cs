using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace SevDeskClient
{

    public class Contact : SevClientObject<Contact>
    {
        [JsonProperty("objectName")]
        public override string ObjectName { get; set; } = "Contact";
        [JsonProperty("create")]
        public DateTime Create { get; set; }

        [JsonProperty("update")]
        public DateTime _Update { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("customerNumber")]
        public string CustomerNumber { get; set; }

        [JsonProperty("surename")]
        public string Surename { get; set; }

        [JsonProperty("familyname")]
        public string Familyname { get; set; }

        [JsonProperty("titel")]
        public string Titel { get; set; }

        [JsonProperty("category")]
        public Category Category { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("academicTitle")]
        public string AcademicTitle { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        //[JsonProperty("sevClient")]
        //public SevClient SevClient { get; set; }

        [JsonProperty("name2")]
        public string Name2 { get; set; }

        [JsonProperty("birthday")]
        public string Birthday { get; set; }

        [JsonProperty("vatNumber")]
        public string VatNumber { get; set; }

        [JsonProperty("bankAccount")]
        public string BankAccount { get; set; }

        [JsonProperty("bankNumber")]
        public string BankNumber { get; set; }
        
        [JsonProperty("paymentMethod")]
        public PaymentMethod PaymentMethod { get; set; }

        [JsonProperty("defaultCashbackTime")]
        public string DefaultCashbackTime { get; set; }

        [JsonProperty("defaultCashbackPercent")]
        public string DefaultCashbackPercent { get; set; }

        [JsonProperty("defaultTimeToPay")]
        public string DefaultTimeToPay { get; set; }

        [JsonProperty("taxNumber")]
        public string TaxNumber { get; set; }

        [JsonProperty("taxOffice")]
        public object TaxOffice { get; set; }

        [JsonProperty("exemptVat")]
        public string ExemptVat { get; set; }

        [JsonProperty("taxType")]
        public string TaxType { get; set; }

        [JsonProperty("defaultDiscountAmount")]
        public string DefaultDiscountAmount { get; set; }

        [JsonProperty("defaultDiscountPercentage")]
        public string DefaultDiscountPercentage { get; set; }

        [JsonProperty("buyerReference")]
        public string BuyerReference { get; set; }

        [JsonProperty("governmentAgency")]
        public string GovernmentAgency { get; set; }

        [JsonProperty("addresses"), JsonIgnoreSerialization]
        public List<ContactAddress> Addresses { get; set; }

        [JsonProperty("tags"), JsonIgnoreSerialization]
        public List<Tag> Tags { get; set; }

        /// <summary>
        /// Represents a list of communication ways
        /// </summary>
        [JsonProperty("communicationWays"), JsonIgnoreSerialization]
        public List<CommunicationWay> CommunicationWays { get; set; }
        public Contact() { }
    }
}
