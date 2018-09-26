using AutoMapper;
using DDO.Domain.Accounting;
using DDO.Domain.SupplierModule;
using DDO.Domain.TdsModule;
using DDO.WebApp.Api.AccountingUnitApi;
using DDO.WebApp.Api.SupplierApi;

namespace DDO.WebApp.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AccountingUnit, AccountingUnitResource>();
            CreateMap<Supplier, SupplierResource>();
            CreateMap<Supplier, SaveSupplierResource>();
            CreateMap<Tds, TdsResource>();
            CreateMap<Tds, SaveTdsResource>();
            CreateMap<Supplier, KeyValuePairResource>();

         
         






        }
    }
}