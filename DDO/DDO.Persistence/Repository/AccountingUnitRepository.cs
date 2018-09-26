using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using DDO.Domain.Accounting;
using Microsoft.EntityFrameworkCore;
namespace DDO.Persistence.Repository
{
    public class AccountingUnitRepository : RepositoryBase<AccountingUnit>, IAccountingUnitRepository
    {
        private readonly ApplicationDbContext _context;

        public AccountingUnitRepository(ApplicationDbContext context) : base((DbContext)context)
        {
            _context = context;
        }


           public override Task<AccountingUnit> GetAsync(object id, string accountingUnitId)
        {
            return _context.AccountingUnits.FindAsync(id);
        }
        public Task<AccountingUnit> GetAsync(object id)
        {
            return _context.AccountingUnits.FindAsync(id);
        }

        public override Task<AccountingUnit> GetAllAsync(object id)
        {
            throw new NotImplementedException();
        }

        
    }
}