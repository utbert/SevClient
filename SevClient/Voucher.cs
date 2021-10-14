using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace SevDeskClient
{
    public class Voucher : SevClientPdfObject<Voucher>
    {

        [JsonProperty("objectName")]
        public override string ObjectName { get; set; } = "Voucher";

        [JsonProperty("create")]
        public DateTime Create { get; set; }

        [JsonProperty("update")]
        public DateTime update { get; set; }

        [JsonProperty("createUser")]
        public object CreateUser { get; set; }

        [JsonProperty("voucherDate")]
        public DateTime VoucherDate { get; set; }

        [JsonProperty("supplierName")]
        public string SupplierName { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("resultDisdar")]
        public object ResultDisdar { get; set; }

        [JsonProperty("payDate")]
        public DateTime PayDate { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("sumNet")]
        public string SumNet { get; set; }

        [JsonProperty("sumTax")]
        public string SumTax { get; set; }

        [JsonProperty("sumGross")]
        public string SumGross { get; set; }

        [JsonProperty("sumNetAccounting")]
        public string SumNetAccounting { get; set; }

        [JsonProperty("sumTaxAccounting")]
        public string SumTaxAccounting { get; set; }

        [JsonProperty("sumGrossAccounting")]
        public string SumGrossAccounting { get; set; }

        [JsonProperty("showNet")]
        public string ShowNet { get; set; }

        [JsonProperty("paidAmount")]
        public string PaidAmount { get; set; }

        [JsonProperty("taxType")]
        public string TaxType { get; set; }

        [JsonProperty("creditDebit")]
        public string CreditDebit { get; set; }

        [JsonProperty("hidden")]
        public string Hidden { get; set; }

        [JsonProperty("voucherType")]
        public string VoucherType { get; set; }

        [JsonProperty("recurringIntervall")]
        public object RecurringIntervall { get; set; }

        [JsonProperty("recurringStartDate")]
        public DateTime RecurringStartDate { get; set; }

        [JsonProperty("recurringNextVoucher")]
        public DateTime RecurringNextVoucher { get; set; }

        [JsonProperty("recurringLastVoucher")]
        public object RecurringLastVoucher { get; set; }

        [JsonProperty("recurringEndDate")]
        public object RecurringEndDate { get; set; }

        [JsonProperty("enshrined")]
        public object Enshrined { get; set; }

        [JsonProperty("sendType")]
        public object SendType { get; set; }

        [JsonProperty("inSource")]
        public object InSource { get; set; }

        [JsonProperty("iban")]
        public object Iban { get; set; }

        [JsonProperty("accountingSpecialCase")]
        public object AccountingSpecialCase { get; set; }

        [JsonProperty("paymentDeadline")]
        public DateTime PaymentDeadline { get; set; }

        [JsonProperty("tip")]
        public string Tip { get; set; }

        [JsonProperty("mileageRate")]
        public string MileageRate { get; set; }

        [JsonProperty("selectedForPaymentFile")]
        public string SelectedForPaymentFile { get; set; }

        [JsonProperty("supplierNameAtSave")]
        public string SupplierNameAtSave { get; set; }

        [JsonProperty("taxmaroStockAccount")]
        public object TaxmaroStockAccount { get; set; }

        [JsonProperty("vatNumber")]
        public object VatNumber { get; set; }

        [JsonProperty("deliveryDate")]
        public DateTime DeliveryDate { get; set; }

        [JsonProperty("deliveryDateUntil")]
        public object DeliveryDateUntil { get; set; }

        [JsonProperty("sumDiscountNet")]
        public string SumDiscountNet { get; set; }

        [JsonProperty("sumDiscountGross")]
        public string SumDiscountGross { get; set; }

        [JsonProperty("sumNetForeignCurrency")]
        public string SumNetForeignCurrency { get; set; }

        [JsonProperty("sumTaxForeignCurrency")]
        public string SumTaxForeignCurrency { get; set; }

        [JsonProperty("sumGrossForeignCurrency")]
        public string SumGrossForeignCurrency { get; set; }

        [JsonProperty("sumDiscountNetForeignCurrency")]
        public string SumDiscountNetForeignCurrency { get; set; }

        [JsonProperty("sumDiscountGrossForeignCurrency")]
        public string SumDiscountGrossForeignCurrency { get; set; }
    }
}
