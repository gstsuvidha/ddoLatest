
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DDO.Domain.AdminModule;
using DDO.Domain.SupplierModule;

namespace DDO.Domain.Accounting
{
    public class AccountingUnit
    {
        [Key]
        public string Id { get; set; }

        public string Name { get; set; }
        public string Role { get; set; }
        public string BusinessName { get; set; }
        public string Subject { get; set; }
        public string GstinPassword { get; set; }
        public string AuthorizedRepresentativeName { get; set; }
        public string Contact { get; set; }
        public string LastGrossTurnOver { get; set; }
        public string CurrentGrossTurnOver { get; set; }
        public string Pan { get; set; }

        public string Address { get; set; }
        public string Gstin { get; set; }
        public string TdsGstin { get; set; }
        public string ContactNumber { get; set; }
        public string TurnOver { get; set; }
        public string IfscCode { get; set; }
        public string RegistrationType { get; set; }
        public string TermsAndCondition { get; set; }
        public string BankAccountName { get; set; }
        public string BankAccountNumber { get; set; }
        public string Email { get; set; }
        public Admin Admin { get; set; }
        public int AdminId { get; set; }
        
        
        public string PlaceOfSupply { get; set; }

        public string ImgUrl { get; set; }
        

        public int SelectedYear { get; set; }
        
        
        



        #region Getters
      
        public IEnumerable<Supplier> Suppliers { get; set; }
              //public IEnumerable<IssueNote> UnregisteredIssueNotes { get; set; }


        //public IEnumerable<PurchaseInvoice> B2CPurchaseInvoices { get; set; }



        #endregion

        public AccountingUnit()
        {
                        Suppliers = new List<Supplier>();
            
            //IssueNotes = new List<IssueNote>();
            //AdvanceReceiveds = new List<AdvanceReceived>();

            //PurchaseInvoices =new List<PurchaseInvoice>();
            //ReceiptNotes=new List<ReceiptNote>();
            //AdvancePaids=new List<AdvancePaid>();
        }
        public AccountingUnit(string businessName, string role, string placeOfSupply, string gstin, string tdsGstin, string email, string address, string contactNumber,
                            string turnOver, string bankAccountName, string bankAccountNumber, string ifscCode, string registrationType,
                            string termsAndCondition,  string currentGrossTurnOver, int selectedYear, string pan)
        {
            BusinessName = businessName;
            Role = role;
            PlaceOfSupply = placeOfSupply;
            Gstin = gstin;
            TdsGstin = tdsGstin;
            Email = email;
            Address = address;
            ContactNumber = contactNumber;
            TurnOver = turnOver;
            BankAccountName = bankAccountName;
            BankAccountNumber = bankAccountNumber;
            IfscCode = ifscCode;
            RegistrationType = registrationType;
            TermsAndCondition = termsAndCondition;
            
            CurrentGrossTurnOver = currentGrossTurnOver;
            SelectedYear = selectedYear;
            
            Pan = pan;
        }

        public void Modify(string businessName, string placeOfSupply, string gstin, 
                            string tdsGstin, string email, string address, string contactNumber,
                            string turnOver, string bankAccountName, string bankAccountNumber, 
                            string ifscCode, string registrationType,
                            string termsAndCondition,  string currentGrossTurnOver, 
                            int selectedYear, string pan)
        {

            BusinessName = businessName;
            PlaceOfSupply = placeOfSupply;
            Gstin = gstin;
            TdsGstin = tdsGstin;
            Email = email;
            Address = address;
            ContactNumber = contactNumber;
            TurnOver = turnOver;
            BankAccountName = bankAccountName;
            BankAccountNumber = bankAccountNumber;
            IfscCode = ifscCode;
            RegistrationType = registrationType;
            TermsAndCondition = termsAndCondition;
            
            CurrentGrossTurnOver = currentGrossTurnOver;
            SelectedYear = selectedYear;
            
            
            Pan = pan;
        }
        public void UpdateImageUrl(string imgUrl)
        {
            ImgUrl = imgUrl;
        }
    }
}
