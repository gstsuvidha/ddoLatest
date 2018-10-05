using System.Linq;
using AutoMapper;
using DDO.Domain.Accounting;
using DDO.Persistence;
using DDO.WebApp.Api.AccountingUnitApi;
using Microsoft.AspNetCore.Mvc;

namespace DDO.WebApp.Api.SupplierApi
{
    [Produces("application/json")]
    [Route("api/TdsReport")]

    public class TdsReportController : AccountingUnitResolverController
    {
        private readonly IQueryModelDatabase _database;
        
        public TdsReportController(IQueryModelDatabase database, IMapper mapper, IUnitOfWork unitOfWork,
                                     IAccountingUnitRepository accountingUnitRepository) :
                                     base(database, mapper, unitOfWork, accountingUnitRepository)
        {
            
            _database = database;
        }

        [HttpGet]

        public IActionResult GetTotalTdsSummary ()
        {
            var amountPaid = _database.TdssFor(AccountingUnitId).Where(a=>a.IsActive==true)
            .Sum(a=>a.AmountPaid);
            var cgstAmount = _database.TdssFor(AccountingUnitId).Where(a=>a.IsActive==true)
            .Sum(a=>a.CgstAmount);
            var sgstAmount = _database.TdssFor(AccountingUnitId).Where(a=>a.IsActive==true)
            .Sum(a=>a.SgstAmount);
            var igstAmount = _database.TdssFor(AccountingUnitId).Where(a=>a.IsActive==true)
            .Sum(a=>a.IgstAmount);
            var totalTds = _database.TdssFor(AccountingUnitId).Where(a=>a.IsActive==true)
            .Sum(a=>a.TdsAmount);
            var netAmount = _database.TdssFor(AccountingUnitId).Where(a=>a.IsActive==true)
            .Sum(a=>a.NetAmount);

            return Ok(new TdsReport {
                AmountPaid = amountPaid,
                CgstAmount = cgstAmount,
                SgstAmount = sgstAmount,
                IgstAmount = igstAmount,
                TotalTds = totalTds,
                NetAmount = netAmount
  });
        }
    }
}

// CgstAmount { get; set; }
//         public double SgstAmount { get; set; }
//         public double IgstAmount { get; set; }
//         public double TotalTds { get; set; }
//         public double NetAmount { get; set; }