using System;
using DDO.WebApp.Mappings;

namespace DDO.WebApp.Api.SupplierApi
{
    public class TdsResource
    {
        public int Id { get; set; }

        public int SupplierId { get; set; }
        public DateTime Date { get; set; }

        public string PlaceOfSupply { get; set; }

        public double AmountPaid { get; set; }
        public double NetAmount { get; set; }
        public double CgstAmount { get; set; }
        public double SgstAmount { get; set; }
        public double IgstAmount { get; set; }
        public double TdsAmount { get; set; }
        public KeyValuePairResource Supplier { get; set; }



        public string AccountingUnitId { get; set; }

    }
}