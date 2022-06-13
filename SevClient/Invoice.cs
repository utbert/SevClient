using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;



namespace SevDeskClient
{
    public class Invoice : SevClientPdfObject<Invoice>
    {
        [JsonProperty("objectName")]
        public override string ObjectName { get; set; } = "Invoice";
        public string invoiceNumber { get; set; }
        public Contact contact { get; set; }
        public string create { get; set; }
        public string update { get; set; }
        public DateTime? invoiceDate { get; set; } = DateTime.Now;
        public string header { get; set; } = "Rechnung";
        public string headText { get; set; }
        public string footText { get; set; }
        public string timeToPay { get; set; } = "7";
        public string discountTime { get; set; }
        public string discount { get; set; } = "false";
        public string addressName { get; set; }
        public string addressStreet { get; set; }
        public string addressZip { get; set; }
        public string addressCity { get; set; }
        [JsonProperty("addressCountry")]
        public StaticCountry AddressCountry { get; set; } = new StaticCountry();
        public string payDate { get; set; }
        public SevUser createUser { get; set; } = new SevUser();
        public string deliveryDate { get; set; }
        public string status { get; set; } = "200";
        public string smallSettlement { get; set; }
        public SevUser contactPerson { get; set; } = new SevUser();
        public string taxRate { get; set; } = "0";
        public string taxText { get; set; } = "Umsatzsteuer ausweisen";
        public int? dunningLevel { get; set; } = 0;
        public long? lastDunningDate { get; set; }
        public string addressParentName { get; set; }
        public string taxType { get; set; } = "default";
        public PaymentMethod paymentMethod { get; set; }
        public string sendDate { get; set; } = DateTimeOffset.Now.ToUnixTimeSeconds().ToString();
        public string originLastInvoice { get; set; }
        public string invoiceType { get; set; } = "RE";
        public string accountIntervall { get; set; }
        public string accountLastInvoice { get; set; }
        public string accountNextInvoice { get; set; }
        public string reminderTotal { get; set; }
        public string reminderDebit { get; set; }
        public string reminderDeadline { get; set; }
        public string reminderCharge { get; set; }
        public string addressParentName2 { get; set; }
        public string addressName2 { get; set; }
        public string addressGender { get; set; }
        public string accountEndDate { get; set; }
        public string address { get; set; }
        public string currency { get; set; } = "EUR";
        public string sumNet { get; set; }
        public string sumGross { get; set; } = "0";
        public string sumDiscounts { get; set; }
        public string sumNetForeignCurrency { get; set; }
        public string sumTaxForeignCurrency { get; set; }
        public string sumGrossForeignCurrency { get; set; }
        public string sumDiscountsForeignCurrency { get; set; }
        public string sumNetAccounting { get; set; }
        public string sumTaxAccounting { get; set; }
        public string sumGrossAccounting { get; set; }
        public string paidAmount { get; set; }
        public string customerInternalNote { get; set; }
        public string showNet { get; set; }
        public string enshrined { get; set; }
        public string sendType { get; set; } = "VP";
        public string deliveryDateUntil { get; set; }
        public string sendPaymentReceivedNotificationDate { get; set; }
        public string mapAll { get; } = "true";

        public List<Tag> tags { get; set; } = new List<Tag>();

        public Invoice()
        {
            // Standartwerte festlegen
            //this.headText = "<p>wir erlauben uns, unsere Lieferung/Leistung wie folgt in Rechnung zu stellen:<br/></p>";
            this.headText = SevDesk.textTemplates?.SingleOrDefault(s => s.Main == "1" & s.ObjectType == "RE" & s.TextType == "HEAD").Text ?? "";
            //this.footText = "<p><font color = \"red\">BITTE BEACHTEN:<br/>" +
            //                "Das Protokoll für diese Wartung wurde, durch uns, elektronisch an Ihren Aufgabenträger übermittelt. Leider ist es uns nicht möglich zu prüfen ob dieser die Datenübermittlung erhalten hat, oder korrekt verarbeiten konnte. Bitte setzten Sie sich dazu mit Ihrem Aufgabenträger binnen 14 Tagen in Verbindung und lassen Sie sich den Erhalt des Wartungsprotokolls bestätigen. Wir behalten uns vor, nach 14 Tagen ab Rechnungsdatum, eine Bearbeitungsgebühr für einen nachträglichen Protokollversand zu erheben.</font></p>" +
            //                "<p>Leider ist es uns vorerst aus Technischen Gründen(PSD2 Umstellung der Banken) nicht mehr möglich Lastschriften einzuziehen.Wir bitten daher um Überweisung der Rechnung.</p>" +
            //                "<p>Wir bedanken uns für Ihren Auftrag und verbleiben</p>" +
            //                "<p>mit freundlichen Grüßen</p>" +
            //                "<p>Nach dem geltenden Schwarzarbeitbekämpfungsgesetz §14 Abs.4 Satz 1 Nr.9 UStG sind wir verpflichtet, Sie darauf hinzuweisen, dass Sie unsere Rechnung und Ihren Zahlungsbeleg zwei Jahre lang aufbewahren müssen.<br/></p>" +
            //                "<p>Gelieferte Waren bleiben, auch im verbautem Zustand, bis zur vollständigen Bezahlung, unser Eigentum.</p>";
            //this.footText = "<p>Wir bedanken uns für Ihren Auftrag und verbleiben</p>" +
            //                "<p>mit freundlichen Grüßen</p>" +
            //                "<p>Nach dem geltenden Schwarzarbeitbekämpfungsgesetz §14 Abs.4 Satz 1 Nr.9 UStG sind wir verpflichtet, Sie darauf hinzuweisen, dass Sie unsere Rechnung und Ihren Zahlungsbeleg zwei Jahre lang aufbewahren müssen.<br/></p>" +
            //                "<p>Gelieferte Waren bleiben, auch im verbautem Zustand, bis zur vollständigen Bezahlung, unser Eigentum.</p>";
            //this.footText = "<p style=\"font-size: 1em;\">Wir bedanken uns für Ihren Auftrag und verbleiben mit freundlichen Grüßen.<br></p><p style=\"margin-bottom: 15px; font-size: 0.8em; font-family: helvetica, sans-serif; color: rgb(51, 51, 51); overflow-wrap: break-word;\">Nach dem geltenden Schwarzarbeitbekämpfungsgesetz §14 Abs.4 Satz 1 Nr.9 UStG sind wir verpflichtet, Sie darauf hinzuweisen, dass Sie unsere Rechnung und Ihren Zahlungsbeleg zwei Jahre lang aufbewahren müssen.&nbsp;Gelieferte Waren bleiben, auch im verbautem Zustand, bis zur vollständigen Bezahlung, unser Eigentum.</p><hr style=\"margin-top: 15px; margin-bottom: 15px; border-right-width: 0px; border-bottom-width: 0px; border-left-width: 0px; border-right-style: initial; border-bottom-style: initial; border-left-style: initial; border-top-style: solid; border-top-color: rgb(204, 204, 204); font-size: 1em; font-family: helvetica, sans-serif; color: rgb(51, 51, 51);\"><p style=\"margin-bottom: 15px; font-size: 1em; font-family: helvetica, sans-serif; color: rgb(51, 51, 51); overflow-wrap: break-word;\">SEPA Lastschriftmandat für wiederkehrende Zahlungen - Bitte abtrennen und im Original zurück, falls gewünscht.</p><p style=\"margin-bottom: 15px; font-size: 0.8em; font-family: helvetica, sans-serif; color: rgb(51, 51, 51); overflow-wrap: break-word;\">Zahlungsempfänger: Umwelttechnik Ebert - Lauenhainer Hauptstraße 18 - 08451 Crimmitschau<br>Gläubiger-ID: DE29ZZZ00001932269 - Mandatsreferenz:&nbsp;[%KUNDENNUMMER%] <br>Ich ermächtige die Firma Umwelttechnik Ebert, Zahlungen von meinem Konto mittels Lastschrifteinzuziehen. Zugleich weise ich mein Kreditinstitut an, die von Umwelttechnik Ebert (Thomas Ebert) auf mein Kontogezogenen Lastschriften einzulösen.&nbsp;Hinweis: Ich kann innerhalb von acht Wochen, beginnend mit dem Belastungsdatum, die Erstattung des belasteten Betrages verlangen. Es gelten dabei die mit meinem Kreditinstitut vereinbarten Bedingungen</p><table style=\"font-size: 1.1em;\"><colgroup><col width=\"23.77521613832853%\"><col width=\"76.0806916426513%\"></colgroup><thead></thead><tbody><tr><td>Kontoinhaber:</td><td>[%ADRESSE%]</td></tr><tr><td>Kreditinstitut:</td><td>_________________________________________________________________<br></td></tr><tr><td>IBAN:</td><td>_________________________________________________________________</td></tr><tr><td>BIC:</td><td>_________________________________________________________________<br></td></tr><tr><td>Datum/Unterschrift:</td><td>[%RECHNUNGSDATUM%] /&nbsp;<br></td></tr></tbody></table>";
            this.footText = SevDesk.textTemplates?.SingleOrDefault(s => s.Name == "Wartungsrechnung Fuß mit SEPA").Text ?? "";
        }
        //Invoice
        public HttpStatusCode FactorySaveInvoice(List<InvoicePos> positions, out Invoice invoice)
        {
            RestRequest restRequest = new RestRequest();
            restRequest.Resource = "Invoice/Factory/saveInvoice";

            // Neue Rechnungsnummervergeben wenn keine vorhanden
            if (String.IsNullOrWhiteSpace(this.invoiceNumber))
            {
                string reNr;
                if (FactoryGetNextInvoiceNumber(out reNr) == HttpStatusCode.OK)
                {
                    this.invoiceNumber = reNr;
                    this.header += $" {reNr}";
                }

            }

            restRequest.AddJsonBody(new { invoice = this, invoicePosSave = positions });
            restRequest.Method = Method.Post;

            RestResponse response = restClient.ExecuteAsync(restRequest).Result;
            invoice = JsonConvert.DeserializeAnonymousType(response.Content, new { objects = new { Invoice = new Invoice() } }, new JsonSerializerSettings() { MissingMemberHandling = MissingMemberHandling.Ignore }).objects.Invoice;
            return response.StatusCode;
        }
        public HttpStatusCode BookAmmount(CheckAccount cA = null, string sumGross = "")
        {
            sumGross = string.IsNullOrWhiteSpace(sumGross) ? this.sumGross : sumGross;
            cA = cA ?? new CheckAccount() { Id = "484485" }; // <- Kasse

            RestRequest restRequest = new RestRequest();
            restRequest.Resource = $"Invoice/{this.Id}/bookAmmount";

            restRequest.AddJsonBody(new { ammount = sumGross, date = DateTimeOffset.Now.ToUnixTimeSeconds().ToString(), type = "null", checkAccount = cA, createFeed = "true", checkAccountTransaction = "null" });
            restRequest.Method = Method.Put;

            RestResponse response = restClient.ExecuteAsync(restRequest).Result;
            // JsonConvert.DeserializeAnonymousType(response.Content, new { objects = new { Invoice = new Invoice() } }, new JsonSerializerSettings() { MissingMemberHandling = MissingMemberHandling.Ignore }).objects.Invoice;
            return response.StatusCode;
        }

        private HttpStatusCode FactoryGetNextInvoiceNumber(out string reNr, string invType = "RE", bool useNextNumber = true)
        {
            RestRequest restRequest = new RestRequest();
            restRequest.Resource = $"Invoice/Factory/getNextInvoiceNumber";

            restRequest.AddQueryParameter("invoiceType", invType);
            restRequest.AddQueryParameter("useNextNumber", useNextNumber.ToString());
            restRequest.Method = Method.Get;

            RestResponse response = restClient.ExecuteAsync(restRequest).Result;
            reNr = JsonConvert.DeserializeAnonymousType(response.Content, new { objects = "" }, new JsonSerializerSettings() { MissingMemberHandling = MissingMemberHandling.Ignore }).objects;
            return response.StatusCode;
        }
        public HttpStatusCode FactoryCreateInvoiceReminder(out Invoice dunningInvoice)
        {
            RestRequest restRequest = new RestRequest();
            restRequest.Resource = "Invoice/Factory/createInvoiceReminder";


            restRequest.AddJsonBody(new { invoice = this });
            restRequest.Method = Method.Post;

            RestResponse response = restClient.ExecuteAsync(restRequest).Result;
            Invoice invoice = JsonConvert.DeserializeAnonymousType(response.Content, new { objects = new Invoice() }, new JsonSerializerSettings() { MissingMemberHandling = MissingMemberHandling.Ignore }).objects;

            // SaveInvoice
            invoice.status = "200";
            invoice.sendDate = DateTime.Now.ToLongDateString();

            HttpStatusCode httpStatusCode = invoice.FactorySaveInvoice(null, out dunningInvoice);

            return response.StatusCode;
        }
    }
}
