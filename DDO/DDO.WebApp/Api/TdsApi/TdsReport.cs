namespace DDO.WebApp.Api.SupplierApi
{
    public class TdsReport
    {
        public double AmountPaid { get; set; }
        public double CgstAmount { get; set; }
        public double SgstAmount { get; set; }
        public double IgstAmount { get; set; }
        public double TotalTds { get; set; }
        public double NetAmount { get; set; }
    }
}