using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDO.Domain.Accounting
{
    public interface IAccountingUnitRepository : IRepositoryBase<AccountingUnit>
    {
        //Task<Gstr1> GetGstr1Data(string tenantId, int month);

        Task<AccountingUnit> GetAsync(object id);
        
    }
}