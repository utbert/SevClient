using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SevDeskClient
{
    public static class SevDesk
    {
        public static List<Category> categories;
        public static List<CheckAccount> checkAccounts;
        public static List<CheckAccountTransaction> checkAccountTransactions;
        public static List<CheckAccountTransactionLog> checkAccountTransactionLogs;
        public static List<CommunicationWay> communicationWays;
        public static List<Contact> contacts;
        public static List<ContactAddress> contactAddresses;
        public static List<StaticCountry> countries;
        public static List<Invoice> invoices;
        public static List<InvoicePos> invoicePositions;
        public static List<Letter> letters;
        public static List<Part> parts;
        public static List<PaymentMethod> paymentMethods;
        public static List<Tag> tags;
        public static List<TagRelation> tagRelations;
        public static List<Unity> unities;
        public static List<Voucher> vouchers;
        public static List<Invoice> reminders;
        public static List<TextTemplate> textTemplates;
        public static List<Document> documents;
        public static List<DocumentFolder> documentFolders;

        public static void LoadData()
        {
            categories = Category.GetList();
            checkAccounts = CheckAccount.GetList();
            //checkAccountTransactions = CheckAccountTransaction.GetList();
            //checkAccountTransactionLogs;
            textTemplates = TextTemplate.GetList();
            contacts = Contact.GetList();
            communicationWays = CommunicationWay.GetList();
            contactAddresses = ContactAddress.GetList();
            countries = StaticCountry.GetList();
            invoices = Invoice.GetList();
            invoicePositions = InvoicePos.GetList();
            letters = Letter.GetList();
            parts = Part.GetList();
            paymentMethods = PaymentMethod.GetList();
            tags = Tag.GetList();
            tagRelations = TagRelation.GetList();
            unities = Unity.GetList();
            vouchers = Voucher.GetList();

            documents = Document.GetList();
            documentFolders = DocumentFolder.GetList();


            tagRelations.ForEach(f =>
            {
                f.Tag = tags.SingleOrDefault(s => f.Tag.Id == s.Id);
            });

            contactAddresses.ForEach(f =>
            {
                f.category = categories.SingleOrDefault(s => s.Id == f.category.Id);
            });

            contacts.ForEach(f =>
            {
                f.Category = categories.SingleOrDefault(s => s.Id == f.Category.Id);
                f.PaymentMethod = paymentMethods.SingleOrDefault(s => s.Id == f.PaymentMethod?.Id) ?? paymentMethods.SingleOrDefault(s => s.name == "SEPA Überweisung");

                f.Addresses = contactAddresses.Where(w => w.contact.Id == f.Id).ToList();
                f.CommunicationWays = communicationWays.Where(w => w.contact.Id == f.Id).ToList();
                f.Tags = tagRelations.Where(w => w.Object.ObjectName == f.ObjectName).Where(w => w.Object.Id == f.Id).Select(s => s.Tag).ToList();

                if (f.Tags.Exists(e => e.name == "Lastschrift") & f.PaymentMethod.name != "SEPA Lastschrift")
                {
                    f.PaymentMethod = paymentMethods.SingleOrDefault(s => s.name == "SEPA Lastschrift");
                    f.Update();
                }
                else if (!f.Tags.Exists(e => e.name == "Lastschrift") & f.PaymentMethod.name == "SEPA Lastschrift")
                {
                    f.PaymentMethod = paymentMethods.SingleOrDefault(s => s.name == "SEPA Überweisung");
                    f.Update();
                }
            });

            invoices.ForEach(f =>
            {
                if (f.paymentMethod != null) f.paymentMethod = paymentMethods.SingleOrDefault(s => s.Id == f.paymentMethod.Id) ?? f.paymentMethod;

                f.contact = contacts.SingleOrDefault(s => s.Id == f.contact.Id) ?? f.contact;

                f.tags = tagRelations.Where(w => w.Object.ObjectName == f.ObjectName).Where(w => w.Object.Id == f.Id).Select(s => s.Tag).ToList();

            });

        }

        public static List<Invoice> GetDeliquentInvoices() {

            return Invoice.GetList(embed: new string[] { "lastDunningDate", "tags" }, filter: new KeyValuePair<string, string>[] { new KeyValuePair<string, string>("delinquent", "true"), new KeyValuePair<string, string>("status", "200") })
                .Where(w => (w.lastDunningDate is null ? w.invoiceDate : DateTimeOffset.FromUnixTimeSeconds(w.lastDunningDate.Value).DateTime) < DateTime.Now.AddDays(-18)
                & w.dunningLevel < 3
                & !w.tags.Any(a => a.name.Contains("keine-Mahnung")))
                .Select(s => s).ToList();
        }
    }
}
