

using DDO.Domain.Accounting;
using DDO.Domain.SupplierModule;
using DDO.Domain.TdsModule;
using Microsoft.EntityFrameworkCore;
using System.Linq;
namespace DDO.Persistence
{
    public interface IQueryModelDatabase
    {
        DbSet<AccountingUnit> AccountingUnits { get; }
               IQueryable<Tds> TdssFor(string accountingUnitId);
               IQueryable<Supplier> SuppliersFor(string accountingUnitId);
       
    }
    public class QueryModelDatabase : IQueryModelDatabase
    {
        private readonly ApplicationDbContext _context;

        public QueryModelDatabase(ApplicationDbContext context)
        {
            _context = context;
        }
        public DbSet<AccountingUnit> AccountingUnits => _context.AccountingUnits;
        public IQueryable<Supplier> SuppliersFor(string accountingUnitId)
        {
            return _context.Suppliers.ForAccountingUnit(accountingUnitId);
        }
      
        public IQueryable<Tds> TdssFor(string accountingUnitId)
        {
            return _context.Tdss.ForAccountingUnit(accountingUnitId);
        }

         }
}