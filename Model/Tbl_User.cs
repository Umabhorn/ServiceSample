//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WcfBankingService.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tbl_User
    {
        public Tbl_User()
        {
            this.Tbl_Account = new HashSet<Tbl_Account>();
            this.Tbl_Transaction = new HashSet<Tbl_Transaction>();
            this.Tbl_Statement = new HashSet<Tbl_Statement>();
        }
    
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CitizenID { get; set; }
        public string PassportID { get; set; }
        public string MobileNo { get; set; }
        public string EmailAddress { get; set; }
        public Nullable<bool> IsActive { get; set; }
    
        public virtual ICollection<Tbl_Account> Tbl_Account { get; set; }
        public virtual ICollection<Tbl_Transaction> Tbl_Transaction { get; set; }
        public virtual ICollection<Tbl_Statement> Tbl_Statement { get; set; }
    }
}
