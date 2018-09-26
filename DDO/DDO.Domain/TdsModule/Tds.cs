using System;
using DDO.Domain.Accounting;
using DDO.Domain.AdminModule;
using DDO.Domain.Inferface;
using DDO.Domain.SupplierModule;

namespace DDO.Domain.TdsModule
{
    public class Tds: IHaveAccountingUnit, IHaveDateFilter
    {
        public int Id { get; set; }
        public Supplier Supplier { get; set; }

        public int SupplierId { get; set; }
        public DateTime Date { get; set; }

        

        public string PlaceOfSupply { get; set; }

        public double AmountPaid { get; set; }

        public double CgstAmount { get; set; }
        public double SgstAmount { get; set; }
        public double IgstAmount { get; set; }
        public double TdsAmount  { get; set; }
        public double NetAmount  { get; set; }

        public bool IsActive { get; set; }  

        public AccountingUnit AccountingUnit {get; set;}

        public string AccountingUnitId {get; set;}
        public Admin Admin { get; set; }
        public int AdminId { get; set; }

    public Tds()
    {
        
    }


    public Tds(int supplierId, DateTime date, string placeOfSupply, double amountPaid, double cgstAmount,
                double sgstAmount, double igstAmount, double tdsAmount, double netAmount, string accountingUnitId, int adminId)
    {
        SupplierId = supplierId;
        Date = date;
        PlaceOfSupply = placeOfSupply;
        AmountPaid = amountPaid;
        CgstAmount = cgstAmount;
        SgstAmount = sgstAmount;
        IgstAmount = igstAmount;
        TdsAmount = tdsAmount;
        NetAmount = netAmount;
        AccountingUnitId = accountingUnitId;
        AdminId = adminId;
            IsActive = true;

  }

     public void Modify(int supplierId, DateTime date, string placeOfSupply, double amountPaid, double cgstAmount,
                double sgstAmount, double igstAmount, double tdsAmount, double netAmount, string accountingUnitId)
    {
        SupplierId = supplierId;
        Date = date;
        PlaceOfSupply = placeOfSupply;
        AmountPaid = amountPaid;
        CgstAmount = cgstAmount;
        SgstAmount = sgstAmount;
        IgstAmount = igstAmount;
        TdsAmount = tdsAmount;
        NetAmount = netAmount;
        AccountingUnitId = accountingUnitId;
        IsActive = true;

  }
     
        public void Delete()
        {
            IsActive = false;
        }

    }
}