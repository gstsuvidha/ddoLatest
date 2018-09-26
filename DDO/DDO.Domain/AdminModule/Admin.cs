using System.Collections.Generic;
using DDO.Domain.Accounting;
using DDO.Domain.SupplierModule;
using DDO.Domain.TdsModule;

namespace DDO.Domain.AdminModule
{
    public class Admin
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<AccountingUnit> AccountingUnits { get; set; }
        public IEnumerable<Supplier> Suppliers { get; set; }
        public IEnumerable<Tds> Tdss { get; set; }
    }
}