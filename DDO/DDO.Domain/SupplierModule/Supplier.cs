using System;
using System.Collections.Generic;
using System.Text;
using DDO.Domain.Accounting;
using DDO.Domain.AdminModule;
using DDO.Domain.Enums;
using DDO.Domain.Inferface;

namespace DDO.Domain.SupplierModule
{
    public class Supplier : IHaveAccountingUnit, IHaveActiveFilter
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Gstin { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public RegistrationType RegistrationType { get; set; }

        public bool IsActive { get; set; }


        //foreign key
        public string AccountingUnitId { get; set; }
        public AccountingUnit AccountingUnit { get; set; }
        public Admin Admin { get; set; }
        public int AdminId { get; set; }



        protected Supplier()
        {

        }

        public Supplier(string name, string gstin, string address, string state, string contactNumber, string accountingUnitId,
                        RegistrationType registrationType, string email, int adminId)
        {
            
            Name = name;
            Gstin = gstin;
            Address = address;
            State = state;
            ContactNumber = contactNumber;
            AccountingUnitId = accountingUnitId;
            IsActive = true;
            RegistrationType = registrationType;
            Email = email;
            AdminId = adminId;

        }


        public void Modify(string name, string gstin, string address, string state, string contactNumber,
                            RegistrationType registrationType, string email)
        {
            Name = name;
            Gstin = gstin;
            Address = address;
            State = state;
            ContactNumber = contactNumber;
            IsActive = true;
            RegistrationType = registrationType;
            Email = email;

        }



        public void Delete()
        {
            IsActive = false;
        }

    }
}
